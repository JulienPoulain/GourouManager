using System.Collections.Generic;
using UnityEngine;

public class RoundManager : Singleton<RoundManager>
{
    private Dictionary<SyncIntSO, int> pendingChanges = new Dictionary<SyncIntSO, int>();
    
    public void NextTurn()
    {
        // Ajout des nouveaux events actifs
        GameManager.Instance.AddEvent();

        // Retirer les évènements fini de la liste
        foreach (Event evenement in GameManager.Instance.m_activeEvents)
        {
            if (evenement.Duration == 0)
            {
                GameManager.Instance.m_activeEvents.Remove(evenement);
            }
        }

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

            //Reduction du compteur d'events
            evenement.AdvanceTime(1);
        }

        // Applique les changements de valeurs des ressources
        foreach (SyncIntSO ressource in pendingChanges.Keys)
        {
            ressource.m_value += pendingChanges[ressource];
        }
        pendingChanges.Clear();
    }

}
