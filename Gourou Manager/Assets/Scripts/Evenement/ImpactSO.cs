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
        if (m_ressource == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Ressource manquante.");
        }
        else
        {
            m_ressource.Initialize();
        }
        
        if (m_magnitude == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} Magnitude manquante.");
        }
        else
        {
            m_magnitude.Initialize();
        }
    }
}
