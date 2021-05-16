using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExactionSO", menuName = "GourouManager/Dialogue/Exaction")]

public class ExactionSO : ScriptableObject
{
    [SerializeField] private string m_name;
    [SerializeField] private string m_description;
    [SerializeField] private List<EventSO> m_eventList;
    // Condition d'accès dans le cas d'une exaction d'institution.
    // Condition d'activation automatique dans le cas d'une exaction spontané.
    [SerializeField] private List<ConditionSO> m_conditions;

    public string Name => m_name;
    public string Description => m_description;
    public List<EventSO> EventList => m_eventList;
    public List<ConditionSO> Conditions => m_conditions;

    public bool IsValid()
    {
        foreach (ConditionSO condition in m_conditions)
        {
            if (!condition.IsOneValid())
                return false;
        }
        return true;
    }
}
