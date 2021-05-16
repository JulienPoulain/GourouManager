using System.Collections.Generic;

public class RoundManager : Singleton<RoundManager>
{
    //private Dictionary<SyncIntSO, int> m_pendingChanges = new Dictionary<SyncIntSO, int>();
    
    public void NextTurn()
    {
        // Ajout des nouveaux évènements et exécution des évènements actifs
        
        AddEvent(GameManager.Instance.PendingExactions, GameManager.Instance.ActiveEvents);

        GameManager.Instance.PendingExactions.Clear();
        
        ClearFinishedEvent(GameManager.Instance.ActiveEvents);
        
        ComputeEvent(GameManager.Instance.ActiveEvents);

        // Calcul et effet des TriggeredExactions

        foreach (InstitutionSO institution in GameManager.Instance.Institutions)
        {
            List<ExactionSO> newTriggeredExactions = new List<ExactionSO>();
            List<Event> newTriggeredEvents = new List<Event>();
            
            do
            {
                newTriggeredEvents.Clear();
                foreach (ExactionSO exaction in institution.RemainingTriggeredExactions)
                {
                    if (exaction.IsValid())
                    {
                        newTriggeredExactions.Add(exaction);
                    }
                }
                
                AddEvent(newTriggeredExactions, newTriggeredEvents);
                ComputeEvent(newTriggeredEvents);
                
                GameManager.Instance.ActiveEvents.AddRange(newTriggeredEvents);
                ClearFinishedEvent(GameManager.Instance.ActiveEvents);
                
                foreach (ExactionSO exaction in newTriggeredExactions)
                {
                    institution.RemainingTriggeredExactions.Remove(exaction);
                }
            } while (newTriggeredEvents.Count > 0);
        }
    }

    public void AddEvent(List<ExactionSO> p_exactions, List<Event> p_events)
    {
        foreach (ExactionSO exactionSO in p_exactions)
        {
            foreach (EventSO eventSO in exactionSO.EventList)
            {
                p_events.Add(new Event(eventSO));
            }
        }
    }

    public void ClearFinishedEvent(List<Event> p_events)
    {
        foreach (Event evenement in p_events)
        {
            if (evenement.Duration == 0)
            {
                p_events.Remove(evenement);
            }
        }
    }

    public void ComputeEvent(List<Event> p_events)
    {
        Dictionary<SyncIntSO, int> pendingChanges = new Dictionary<SyncIntSO, int>();
        
        // 1. Stocke les modifications futures de valeurs des ressources
        foreach (Event evenement in p_events)
        {
            // Stockage des modifications futures
            foreach (Impact impact in evenement.Impacts)
            {
                int magnitude = impact.Magnitude.Compute();
                if (pendingChanges.ContainsKey(impact.Ressource))
                {
                    pendingChanges[impact.Ressource] += magnitude;
                }
                else
                {
                    pendingChanges.Add(impact.Ressource, magnitude);
                }
            }
            
            // Ajout des informations obtenues
            foreach (InfoSO info in evenement.InfoGained)
            {
                info.obtain();
            }
            evenement.InfoGained.Clear();

            //Reduction du compteur d'events (sa durée d'activité)
            evenement.AdvanceTime(1);
        }
        
        // 2. Applique les changements de valeurs des ressources
        foreach (SyncIntSO ressource in pendingChanges.Keys)
        {
            ressource.m_value += pendingChanges[ressource];
        }
    }
}
