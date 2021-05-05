using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConditionInt", menuName = "GourouManager/Condition/ConditionInt")]
public class ConditionIntSO : ConditionSO
{
    [SerializeField] private SyncIntSO m_ressource;
    [SerializeField] private ConditionType m_conditionType;
    [SerializeField] private int m_value;

    public override bool IsOneValid()
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
                return m_ressource.Value < m_value;
                break;
            case ConditionType.Equal:
                return m_ressource.Value == m_value;
                break;
            case ConditionType.Greater:
                return m_ressource.Value > m_value;
                break;
            default:
                Debug.LogError("<color=red>ERROR :</color> ConditionType Inconnue.");
                break;
        }
        return false;
    }
}
