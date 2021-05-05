using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewInterlocutor", menuName = "GourouManager/Interlocutor")]

public class InterlocutorSO: ScriptableObject
{
    //[Header("Titre")]
    [SerializeField] public string m_name;
    [SerializeField] public SyncIntSO m_sanity;
    [SerializeField] public List<ConditionIntSO>  m_conditionInt;
    [SerializeField] public List<ConditionBoolSO>  m_conditionBool;
    [SerializeField] public DialogueSO m_dialogue;
    //[SerializeField] [Tooltip("")]


    public bool IsAccessible()
    {
        // TEST CONDITION INT
        foreach (ConditionIntSO condition in m_conditionInt)
        {
            if (condition == null)
            {
                Debug.Log("<color=red>ERROR :</color> Condition Int manquante.");
            }
            else if (!condition.IsOneValid())
            {
                Debug.Log("Condition Int : OK");
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
            else if (!condition.IsOneValid())
            {
                Debug.Log("Condition Bool : OK");
                return false;
            }
        }
        
        return true;
    }
}

