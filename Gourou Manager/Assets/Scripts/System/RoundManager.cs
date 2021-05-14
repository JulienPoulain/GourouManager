using System.Collections.Generic;
using UnityEngine;

public class RoundManager : Singleton<RoundManager>
{
    private Dictionary<SyncIntSO, int> pendingChanges = new Dictionary<SyncIntSO, int>();
    
    public void NextTurn()
    {
        Debug.Log("AVANT ADD EVENT");
        // Ajout des nouveaux events actifs
        GameManager.Instance.AddEvent();
        Debug.Log("après add event");
        // Calcul des effets des events
        foreach (Event evenement in GameManager.Instance.m_activeEvents)
        {
            Debug.Log("0");
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

            Debug.Log("1");
            //Reduction du compteur d'events et retire les events "finis" de la liste
            evenement.AdvanceTime(1);
            if (evenement.Duration == 0)
            {
                GameManager.Instance.m_activeEvents.Remove(evenement);
            }
            Debug.Log("2");
        }

        Debug.Log("3");
        // Applique les changements de valeurs des ressources
        foreach (SyncIntSO ressource in pendingChanges.Keys)
        {
            ressource.m_value += pendingChanges[ressource];
        }

        Debug.Log("4");

        pendingChanges.Clear();
        Debug.Log("FIN");
    }

}
