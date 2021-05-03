using UnityEngine;

[CreateAssetMenu(fileName = "NewImpact", menuName = "GourouManager/Event/Impact")]
public class ImpactSO : ScriptableObject
{
    [SerializeField] private SyncIntSO m_ressource;
    [SerializeField] private int m_magnitude;
    
    public void OnEnable()
    {
        if (m_ressource == null)
            Debug.LogError($"<color=red>ERROR :</color> Ressource manquante dans {this.name}.");
    }

    public void Apply()
    {
        m_ressource.Value += m_magnitude;
    }
}
