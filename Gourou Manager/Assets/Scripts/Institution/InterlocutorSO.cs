using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInterlocutor", menuName = "GourouManager/Institution/Interlocuteur")]

public class InterlocutorSO: ScriptableObject, IInitializable
{
    [SerializeField] public string m_name;
    [SerializeField] [Tooltip("Description rapide du personnage et son rôle")]  public string m_description;
    [SerializeField] [Tooltip("Represente ce que le joueur risuqe s'il échou la negociation")]  public string m_descriptionFailure;
    [SerializeField] [Tooltip("Approches débloquées par les conditions.")] public List<ApproachSO> m_approach;
    [SerializeField] [Tooltip("Conditions d'accès à l'interlocuteur.")] private List<ConditionIntSO>  m_accesConditions;
    [SerializeField] [Tooltip("Sprite du visuel de l'interlocutor.")] public Sprite m_sprite;

    public List<ConditionIntSO> AccessCondition => m_accesConditions;
    
    public void Initialize()
    {
        foreach (ApproachSO approach in m_approach)
        {
            approach.Initialize();
        }

        foreach (ConditionIntSO conditionInt in m_accesConditions)
        {
            conditionInt.Initialize();
        }
    }

    public bool IsAccessible()
    {
        foreach (ConditionSO condition in m_accesConditions)
        {
            if (condition == null)
            {
                Debug.Log("<color=red>ERROR :</color> Condition manquante.");
            }
            else if (!condition.IsValid())
            {
                return false;
            }
        }
        
        return true;
    }
}

