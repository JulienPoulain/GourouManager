using UnityEngine;

[CreateAssetMenu(fileName = "NewConditionBool", menuName = "GourouManager/Condition/ConditionBool")]
public class ConditionBoolSO : ConditionSO<SyncBoolSO>
{
    public override bool IsValid()
    {
        return m_ressource.Value;
    }
}
