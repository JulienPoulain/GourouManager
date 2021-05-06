using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "GourouManager/Dialogue/Dialogue")]
public class DialogueSO : ScriptableObject
{
    [SerializeField] private List<ApproachSO> m_approches;
    //[SerializeField] private ExactionSO m_exactionPos;
    //[SerializeField] private ExactionSO m_exactionNeg;

    /*public List<ApproachSO> GetAvailableApproches()
    {
        List<ApproachSO> availableApproches = new List<ApproachSO>();
        
        foreach (var approach in m_approches)
        {
            if (approach.IsAccessible())
                availableApproches.Add(approach);
        }

        return availableApproches;
    }*/

    /*public ExactionSO tryApproach(ApproachSO p_approach)
    {
        ExactionSO exaction = p_approach.IsSuccessful() ? m_exactionPos : m_exactionNeg;
        return exaction;
    }*/
}
