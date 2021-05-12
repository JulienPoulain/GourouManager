using UnityEngine;

[CreateAssetMenu(fileName = "NewImpact", menuName = "GourouManager/Event/Impact")]
public class ImpactSO : ScriptableObject
{
    [SerializeField] private SyncIntSO m_ressource;
    [SerializeField] private OperationSO m_magnitude;

    public SyncIntSO Ressource => m_ressource;
    public OperationSO Magnitude => m_magnitude;
}
