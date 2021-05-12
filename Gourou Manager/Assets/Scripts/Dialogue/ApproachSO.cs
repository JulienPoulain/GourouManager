using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "NewApproche", menuName = "GourouManager/Dialogue/Approche")]
public class ApproachSO : ScriptableObject
{
    [SerializeField] public string m_approach;  // utiliser dans TextAproachIndividual en temps que nom de l'approche
    [SerializeField] private ExactionSO m_exactionPos;
    [SerializeField] private ExactionSO m_exactionNeg;
    [SerializeField] private List<ConditionSO> m_cdtSuccess;
    [SerializeField] private int m_cooldown;
    private int m_remainingTime;

    [SerializeField] [Tooltip("petite descrition de l'approche pour le joueur exemple : Si vous parvenez a l'intimider, vous obtiendrez des informations")] 
    public string m_descriptionApproach; // utiliser dans TextInterlocutor
    
    [SerializeField] [Tooltip("Phrase du personnage lors du dialogue (Partie de Maxime)")] 
    public string m_DialogueApproach; // utiliser dans TextApprocheIndividual
    
    [SerializeField] [Tooltip("Phrase au joueur pour lui indiquer ce qu'il reçois s'il réussit l'approche, ex: si vous parvenez à l'intimider, vous pourrez obtenir ceci")] 
    public string m_resultatApproach; // utiliser dans TextApprocheIndividual
    
    /// <summary>
    /// Renvoie le résultat d'une tentative de cette approche.
    /// </summary>
    /// <returns>L'exaction correspondante si l'approche n'est pas en récupération. Sinon null.</returns>
    [CanBeNull] public ExactionSO TryApproach()
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
