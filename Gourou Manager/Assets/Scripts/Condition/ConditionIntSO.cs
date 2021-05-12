using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConditionInt", menuName = "GourouManager/Condition/ConditionInt")]
public class ConditionIntSO : ConditionSO
{
    [SerializeField] public RessourceSO m_ressource;    // utiliser dans TextInterlocutor
    [SerializeField] public ConditionType m_conditionType;  // utiliser dans TextInterlocutor (interface)
    [SerializeField] private int m_value;

    public override string ToString()
    {
        string str = null;
        Array conditionTypeValues = Enum.GetValues(typeof(ConditionType));
        foreach (ConditionType cd in conditionTypeValues)
        {
            if ((cd & m_conditionType) == cd)
            {
                if (str != null) str += " OU ";
                str += m_ressource.name + " : " + m_ressource.Value + " " + cd + " " + m_value;
            }
        }
        return str;
    }

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
