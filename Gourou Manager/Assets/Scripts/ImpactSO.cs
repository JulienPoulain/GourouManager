using UnityEngine;

[CreateAssetMenu(fileName = "NewImpact", menuName = "GourouManager/Event/Impact")]
public class ImpactSO : ScriptableObject
{
    [SerializeField] private SyncIntSO m_ressource;
    [SerializeField] private OperationSO m_magnitude;
    [SerializeField] private int m_duration;

    public SyncIntSO Ressource => m_ressource;
    public OperationSO Magnitude => m_magnitude;
    public int Duration => m_duration;

    public void OnEnable()
    {
        if (m_ressource == null)
            Debug.LogError($"<color=red>ERROR :</color> Ressource manquante dans {this.name}.");
    }
}
