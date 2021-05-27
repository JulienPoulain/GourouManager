using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConditionInt", menuName = "GourouManager/Condition/ConditionInt")]
public class ConditionIntSO : ConditionSO
{
    [SerializeField] public RessourceSO m_ressource;    // utiliser dans TextInterlocutor
    [SerializeField] public ConditionType m_conditionType; // utiliser dans TextInterlocutor (interface)
    [SerializeField]private int m_value;
    
    public override void Initialize()
    {
        m_ressource.Initialize();
    }

    public override string ToString()
    {
        string str = null;

        str = m_ressource.name + ":" + m_ressource.Value + " " + ConditionTypeToString(m_conditionType) + " " + m_value;

        return str;
    }

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
                return m_ressource.Value < m_value;
            case ConditionType.Equal:
                return m_ressource.Value == m_value;
            case ConditionType.Greater:
                return m_ressource.Value > m_value;
            default:
                Debug.LogError("<color=red>ERROR :</color> ConditionType Inconnue.");
                break;
        }
        return false;
    }

    string ConditionTypeToString(ConditionType p_condition)
    {
        switch (p_condition)
        {
            case ConditionType.Lesser:
                return "<";
            case ConditionType.Equal:
                return "=";
            case ConditionType.Greater:
                return ">";
            default:
                return "?";
        }
    }
}
