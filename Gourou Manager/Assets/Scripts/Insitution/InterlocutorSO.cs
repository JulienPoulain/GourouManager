using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInterlocutor", menuName = "GourouManager/Institution/Interlocuteur")]

public class InterlocutorSO: ScriptableObject
{
    [SerializeField] public string m_name;
    [SerializeField] public string m_description;
    [SerializeField] [Tooltip("Santé mentale de l'interlocuteur (0-100) 100 à l'initialisation.")] public SyncIntSO m_sanity;
    [SerializeField] [Tooltip("Approches débloquées par les conditions.")] public List<ApproachSO> m_approach;
    [SerializeField] [Tooltip("Conditions d'accès à l'interlocuteur.")] private List<ConditionIntSO>  m_accesConditions;

    public List<ConditionIntSO> AccessCondition => m_accesConditions;

    public bool IsAccessible()
    {
        foreach (ConditionSO condition in m_accesConditions)
        {
            if (condition == null)
            {
                Debug.Log("<color=red>ERROR :</color> Condition manquante.");
            }
            else if (!condition.IsOneValid())
            {
                return false;
            }
        }
        
        return true;
    }
}

