using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewApproche", menuName = "GourouManager/Dialogue/Approche")]
public class ApproachSO : ScriptableObject
{
    [SerializeField] private string m_approach;
    [SerializeField] private List<ConditionSO> m_cdtAccess;
    [SerializeField] private List<ConditionSO> m_cdtSuccess;

    public bool IsAccessible()
    {
        return ConditionsReached(m_cdtAccess);
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
