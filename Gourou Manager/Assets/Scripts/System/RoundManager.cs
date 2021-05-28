using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine;

public class RoundManager : Singleton<RoundManager>
{
    private void Awake()
    {
        name = "RoundManager";
    }

    public void NextTurn()
    {
        List<EventSO> newActiveEvents = new List<EventSO>();
        
        // Ajout d'une nouvelle entrée dans le registre des évènements.
        EventRegister.Instance.Add(GameManager.Instance.Turn, GameManager.Instance.PendingExactions);

        // 1. Ajout des nouveaux évènements d'exactions puis exécution des évènements actifs.
        AddEvent(newActiveEvents, GameManager.Instance.PendingExactions);
        
        foreach (EventSO evenement in newActiveEvents)
        {
            if (GameManager.Instance.ActiveEvents.Contains(evenement))
            {
                newActiveEvents.Remove(evenement);
            }
        }
        
        GameManager.Instance.ActiveEvents.AddRange(newActiveEvents);
        
        ComputeEvents(GameManager.Instance.ActiveEvents);
        
        GameManager.Instance.PendingExactions.Clear();

        // 2. Calcul et effet des TriggeredEvents
        List<TriggeredEventSO> newTEvents = new List<TriggeredEventSO>();
        do
        {
            newTEvents.Clear();
            foreach (InstitutionSO institution in GameManager.Instance.Institutions)
            {
                foreach (TriggeredEventSO tEventSO in institution.m_triggeredEvents)
                {
                    if (!GameManager.Instance.ActiveEvents.Contains(tEventSO)
                        && !tEventSO.IsExhausted()
                        && tEventSO.IsTriggerable())
                    {
                        newTEvents.Add(tEventSO);
                        tEventSO.UseOnce();
                    }
                }
            }
            ComputeEvents(newTEvents);
            GameManager.Instance.ActiveEvents.AddRange(newTEvents);
        } while (newTEvents.Count > 0);
        
        EventRegister.Instance.Add(GameManager.Instance.Turn, GameManager.Instance.ActiveEvents);
        
        ClearFinishedEvent(GameManager.Instance.ActiveEvents);
    }
    
    /// <summary>
    /// Ajoute l'évènement p_event à la liste d'évènement p_events sans doublon.
    /// </summary>
    /// <param name="p_events">Liste d'évènements</param>
    /// <param name="p_event">Évènement</param>
    public void AddEvent(List<EventSO> p_events, EventSO p_event)
    {
        if (!p_events.Contains(p_event))
            p_events.Add(p_event);
    }
    
    /// <summary>
    /// Ajoute à la liste d'évènements p_events les évènements contenus dans les exactions de la liste d'exactions p_exactions sans doublon.
    /// </summary>
    /// <param name="p_events">Liste d'évènements</param>
    /// <param name="p_exactions">Liste d'exactions</param>
    public void AddEvent(List<EventSO> p_events, List<ExactionSO> p_exactions)
    {
        foreach (ExactionSO exaction in p_exactions)
        {
            foreach (EventSO evenement in exaction.EventList)
            {
                AddEvent(p_events, evenement);
            }
        }
    }
    
    /// <summary>
    /// Réinitialise les évènements finis puis les supprime de la liste p_events.
    /// </summary>
    /// <param name="p_events">Liste d'évènements à clear</param>
    public void ClearFinishedEvent(List<EventSO> p_events)
    {
        foreach (EventSO evenement in p_events.ToList())
        {
            if (evenement.Duration == 0)
            {
                p_events.Remove(evenement);
                evenement.Reset();
            }
        }
    }

    // Stocke les effets des évènements puis les applique d'un coup à la fin.
    public void ComputeEvents(IEnumerable<EventSO> p_events)
    {
        Dictionary<SyncIntSO, int> pendingChanges = new Dictionary<SyncIntSO, int>();
        
        // 1. Stocke les futures modifications de valeurs des ressources
        foreach (EventSO evenement in p_events)
        {
            if (!evenement.IsFinished())
            {
                if (!evenement.IsDelayed())
                {
                    // Stockage des futures modifications
                    foreach (ImpactSO impact in evenement.Impacts)
                    {
                        int magnitude = impact.Magnitude.Compute();

                        if (pendingChanges.ContainsKey(impact.SyncInt))
                        {
                            pendingChanges[impact.SyncInt] += magnitude;
                        }
                        else
                        {
                            pendingChanges.Add(impact.SyncInt, magnitude);
                        }
                    }

                    // Ajout des informations obtenues
                    foreach (InfoSO info in evenement.InfoGained)
                    {
                        info.obtain();
                    }
                    evenement.InfoGained.Clear();
                }

                //Reduction du compteur d'events (sa durée d'activité)
                evenement.AdvanceTime(1);
            }
        }
        
        // 2. Applique les changements de valeurs des ressources
        foreach (SyncIntSO ressource in pendingChanges.Keys)
        {
            ressource.Value += pendingChanges[ressource];
        }
    }
}
