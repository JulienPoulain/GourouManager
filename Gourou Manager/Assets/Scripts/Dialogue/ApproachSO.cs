using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewApproche", menuName = "GourouManager/Dialogue/Approche")]
public class ApproachSO : ScriptableObject, IInitializable
{
    [SerializeField] private string m_name;
    [SerializeField] private ExactionSO m_exactionPos;
    [SerializeField] private ExactionSO m_exactionNeg;
    [SerializeField] private List<ConditionSO> m_cdtSuccess;

    [SerializeField] private int m_cooldown;
    [SerializeField] private int m_remainingTime;

    [SerializeField]
    [Tooltip("petite descrition de l'approche pour le joueur exemple : Si vous parvenez a l'intimider, vous obtiendrez des informations")]
    public string m_descriptionApproach; // utiliser dans TextInterlocutor

    [SerializeField]
    [Tooltip("Phrase du personnage lors du dialogue (Partie de Maxime)")]
    public string m_dialogueApproach; // utiliser dans TextApprocheIndividual

    [SerializeField]
    [Tooltip("Phrase au joueur pour lui indiquer ce qu'il reçois s'il réussit l'approche, ex: si vous parvenez à l'intimider, vous pourrez obtenir ceci")]
    public string m_resultatApproach; // utiliser dans TextApprocheIndividual

    public string Name => m_name;

    public int Cooldown => m_cooldown;
    
    public int RemainingTime => m_remainingTime;
    
    public void Initialize()
    {
        m_exactionPos.Initialize();
        m_exactionNeg.Initialize();
        foreach (ConditionSO condition in m_cdtSuccess)
        {
            condition.Initialize();
        }
        m_remainingTime = 0;
    }

    /// <summary>
    /// Renvoie le résultat d'une tentative de cette approche.
    /// </summary>
    /// <returns>L'exaction correspondante si l'approche n'est pas en récupération. Sinon null.</returns>
   
    /*
    public ExactionSO TryApproach()
    {
        if (!(m_remainingTime > 0))
        {
            m_remainingTime = m_cooldown;
            if (ConditionsReached(m_cdtSuccess))
                return m_exactionPos;
            return m_exactionNeg;
        }
        return null;
    }
    */
    public ExactionSO TryApproach()
    {
        m_remainingTime = m_cooldown;
        if (ConditionsReached(m_cdtSuccess))
            return m_exactionPos;
        return m_exactionNeg;
    }

    public bool IsSuccessful()
    {
        return ConditionsReached(m_cdtSuccess);
    }

    private bool ConditionsReached(List<ConditionSO> p_cdt)
    {
        bool success = true;
        
        foreach (var cdt in p_cdt)
        {
            success &= cdt.IsOneValid();
        }

        return success;
    }
}
