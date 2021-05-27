using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTriggeredEvent", menuName = "GourouManager/Evenement/Evenement déclenché")]
public class TriggeredEventSO : EventSO
{
    [SerializeField] private int m_initNbUse = -1;
    [SerializeField] private int m_nbUse;
    [SerializeField] [CanBeNull] private List<ConditionSO> m_cdtActivation;
    
    public int NbUse => m_nbUse;
    public List<ConditionSO> CdtActivation => m_cdtActivation;

    public override void Initialize()
    {
        m_nbUse = m_initNbUse;
        base.Initialize();
        if (m_cdtActivation.Count > 0)
            foreach (ConditionSO condition in m_cdtActivation)
                condition.Initialize();
        }
    public bool IsUnlimited()
    {
        return m_initNbUse < 0;
    }
    
    public bool IsExhausted()
    {
        return m_nbUse == 0;
    }
    
    public bool IsTriggerable()
    {
        if (m_cdtActivation == null)
            return true;
        foreach (ConditionSO condition in m_cdtActivation)
        {
            if (!condition.IsValid())
                return false;
        }
        return true;
    }
    
    public void UseOnce()
    {
        if(!IsUnlimited())
            m_nbUse--;
    }
}
