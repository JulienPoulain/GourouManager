using UnityEngine;

[CreateAssetMenu(fileName = "NewConditionBool", menuName = "GourouManager/Condition/ConditionBool")]
public class ConditionBoolSO : ConditionSO
{
    [SerializeField] private SyncBoolSO m_ressource;
    public override bool IsOneValid()
    {
        return m_ressource.Value;
    }
}
