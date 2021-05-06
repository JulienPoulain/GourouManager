using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewInterlocutor", menuName = "GourouManager/Interlocutor")]

public class InterlocutorSO: ScriptableObject
{
    [SerializeField] public string m_name;
    [SerializeField] [Tooltip("santé mentale de l'interlocuteur (0-100) 100 à l'initialisation")] public SyncIntSO m_sanity;
    [SerializeField] [Tooltip("approches débloquées par les conditions")] public List<ApproachSO> m_approach;
    [Header("conditions pour accéder à l'interlocuteur")]
    [SerializeField] [Tooltip("conditions dépendantes d'un entier")] public List<ConditionIntSO>  m_accesConditionInt;
    [SerializeField] [Tooltip("conditions dépendantes d'un booléen")] public List<ConditionBoolSO>  m_accesConditionBool;

    public bool IsAccessible()
    {
        // TEST CONDITION INT
        foreach (ConditionIntSO condition in m_accesConditionInt)
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
        foreach (ConditionBoolSO condition in m_accesConditionBool)
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

