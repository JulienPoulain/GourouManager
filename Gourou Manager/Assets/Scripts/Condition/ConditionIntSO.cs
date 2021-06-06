using System;
using ConditionTypeMethods;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConditionInt", menuName = "GourouManager/Condition/ConditionInt")]
public class ConditionIntSO : ConditionSO
{
    [SerializeField] private SyncIntSO m_syncInt;    // utiliser dans TextInterlocutor
    [SerializeField] private ConditionType m_conditionType; // utiliser dans TextInterlocutor (interface)
    [SerializeField] private int m_value;
    public int Value => m_value;
    public override void Initialize()
    {
        if (m_syncInt == null)
        {
            Debug.Log($"<color=red>ERROR :</color> {name} SyncInt manquant.");
        }
        else
        {
            m_syncInt.Initialize();
        }
    }

    public override string Express()
    {
        return m_syncInt.Name + " (" + m_syncInt.Value + ") " + m_conditionType.GetString(" ou ") +" à " + m_value + ".";
    }

    public override string ToString()
    {
        string str = null;

        str = m_syncInt.name + " (" + m_syncInt.Value + ") " + m_conditionType.GetSymbol(", ") + " " + m_value;

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
                return m_syncInt.Value < m_value;
            case ConditionType.Equal:
                return m_syncInt.Value == m_value;
            case ConditionType.Greater:
                return m_syncInt.Value > m_value;
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
