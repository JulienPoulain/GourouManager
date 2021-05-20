using UnityEngine;

[CreateAssetMenu(fileName = "NewImpact", menuName = "GourouManager/Evenement/Impact")]
public class ImpactSO : ScriptableObject, IInitializable
{
    [SerializeField] private SyncIntSO m_ressource;
    [SerializeField] private OperationSO m_magnitude;

    public SyncIntSO Ressource => m_ressource;
    public OperationSO Magnitude => m_magnitude;
    
    public void Initialize()
    {
        m_ressource.Initialize();
        m_magnitude.Initialize();
    }
}
