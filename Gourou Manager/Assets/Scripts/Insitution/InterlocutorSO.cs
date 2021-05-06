using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewInterlocutor", menuName = "GourouManager/Interlocutor")]

public class InterlocutorSO: ScriptableObject
{
    [SerializeField] public string m_name;
    [SerializeField] [Tooltip("")] public SyncIntSO m_sanity;
    [SerializeField] [Tooltip("")] public List<ConditionIntSO>  m_conditionInt;
    [SerializeField] [Tooltip("")] public List<ConditionBoolSO>  m_conditionBool;
    [SerializeField] [Tooltip("")] public DialogueSO m_dialogue;
    
    public bool IsAccessible()
    {
        // TEST CONDITION INT
        foreach (ConditionIntSO condition in m_conditionInt)
        {
            if (condition == null)
            {
                Debug.Log("<color=red>ERROR :</color> Condition Int manquante.");
            }
            else if (!condition.IsValid())
            {
                Debug.Log("Condition Int : pas OK");
                return false;
            }
        }
        
        // TEST CONDITION BOOL
        foreach (ConditionBoolSO condition in m_conditionBool)
        {
            if (condition == null)
            {
                Debug.Log("<color=red>ERROR :</color> Condition Bool manquante.");
            }
            else if (!condition.IsValid())
            {
                Debug.Log("Condition Bool : pas OK");
                return false;
            }
        }
        
        return true;
    }
}

