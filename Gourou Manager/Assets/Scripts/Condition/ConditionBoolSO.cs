using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "NewConditionBool", menuName = "GourouManager/Condition/ConditionBool")]
public class ConditionBoolSO : ConditionSO
{
    [SerializeField] private SyncBoolSO m_ressource;
    
    public override void Initialize()
    {
        m_ressource.Initialize();
    }
    
    public override bool IsValid()
    {
        return m_ressource.Value;
    }
}
