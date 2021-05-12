using System.Collections.Generic;

public class RoundManager : Singleton<RoundManager>
{
    private Dictionary<SyncIntSO, int> pendingChanges;
    
    public void NextTurn()
    {
        // Ajout des nouveaux events actifs
        GameManager.Instance.AddEvent();
        
        // Calcul des effets des events
        foreach (Event evenement in GameManager.Instance.m_activeEvents)
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
            //Reduction du compteur d'events et retire les events "finis" de la liste
            evenement.AdvanceTime(1);
            if (evenement.Duration == 0)
            {
                GameManager.Instance.m_activeEvents.Remove(evenement);
            }
        }
        
        // Applique les changements de valeurs des ressources
        foreach (SyncIntSO ressource in pendingChanges.Keys)
        {
            ressource.m_value += pendingChanges[ressource];
        }
        
        pendingChanges.Clear();
    }

}
