using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConditionInt", menuName = "GourouManager/Condition/ConditionInt")]
public class ConditionIntSO : ConditionSO<SyncIntSO>
{
    [SerializeField] private ConditionType m_conditionType;
    [SerializeField] private int m_value;

    public override bool IsValid()
    {
        Array conditionTypeValues = Enum.GetValues(typeof(ConditionType));
        foreach (ConditionType cd in conditionTypeValues)
        {
            if ((cd & m_conditionType) == cd)
            {
                if (Resolve(cd)) return true;
            }
        }
        return false;
    }
    
    private bool Resolve(ConditionType p_conditionType)
    {
        switch (p_conditionType)
        {
            case ConditionType.Lesser:
                if(m_ressource.Value < m_value) return true;
                break;
            case ConditionType.Equal:
                if(m_ressource.Value == m_value) return true;
                break;
            case ConditionType.Greater:
                if(m_ressource.Value > m_value) return true;
                break;
            default:
                Debug.LogError("<color=red>ERROR :</color> ConditionType Inconnue.");
                break;
        }
        return false;
    }
}
