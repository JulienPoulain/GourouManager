using UnityEngine;

[CreateAssetMenu(fileName = "NewImpact", menuName = "GourouManager/Evenement/Impact")]
public class ImpactSO : ScriptableObject, IInitializable
{
    [SerializeField] private SyncIntSO m_syncInt;
    [SerializeField] private OperationSO m_magnitude;

    public SyncIntSO SyncInt => m_syncInt;
    public OperationSO Magnitude => m_magnitude;
    
    public void Initialize()
    {
        if (m_syncInt == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} SyncInt manquant.");
        }
        else
        {
            m_syncInt.Initialize();
        }
        
        m_magnitude.Initialize();
    }
}
