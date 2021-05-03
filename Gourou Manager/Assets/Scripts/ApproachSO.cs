using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewApproche", menuName = "GourouManager/Dialogue/Approche")]
public class ApproachSO : ScriptableObject
{
    [SerializeField] private string m_approach;
    [SerializeField] private List<ConditionIntSO> m_cdtAccessInt;
    [SerializeField] private List<ConditionBoolSO> m_cdtAccessInfo;
    [SerializeField] private List<ConditionIntSO> m_cdtSuccessInt;
    [SerializeField] private List<ConditionBoolSO> m_cdtSuccessInfo;
    //[SerializeField] private List<ICondition> m_cdtAccess;
    //[SerializeField] private List<ICondition> m_cdtSuccess;

    public bool IsAccessible()
    {
        return ConditionsReached(m_cdtAccessInt, m_cdtAccessInfo);
    }

    public bool IsSuccessful()
    {
        return ConditionsReached(m_cdtSuccessInt, m_cdtSuccessInfo);
    }

    private bool ConditionsReached(List<ConditionIntSO> p_cdtInt, List<ConditionBoolSO> p_cdtInfo)
    {
        bool success = true;
        
        foreach (var cdt in p_cdtInt)
        {
            success &= cdt.IsValid();
        }
        
        foreach (var cdt in p_cdtInfo)
        {
            success &= cdt.IsValid();
        }

        return success;
    }

    /*private bool ConditionsReached(List<ICondition> p_cdt)
    {
        bool success = true;
        
        foreach (var cdt in p_cdt)
        {
            success &= cdt.IsValid();
        }

        return success;
    }*/
}
