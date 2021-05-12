using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "NewApproche", menuName = "GourouManager/Dialogue/Approche")]
public class ApproachSO : ScriptableObject
{
    [SerializeField] private string m_approach;
    [SerializeField] [Tooltip("petite descrition de l'approche pour le joueur exemple : Si vous parvenez a l'intimider, vous obtiendrez des informations")] public string m_descriptionApproach; // utiliser dans TextInterlocutor
    [SerializeField] private ExactionSO m_exactionPos;
    [SerializeField] private ExactionSO m_exactionNeg;
    [SerializeField] private List<ConditionSO> m_cdtSuccess;
    [SerializeField] private int m_cooldown;
    private int m_remainingTime;

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
