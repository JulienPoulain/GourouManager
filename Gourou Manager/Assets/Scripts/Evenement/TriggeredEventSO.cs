using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTriggeredEvent", menuName = "GourouManager/Evenement/Evenement déclenché")]
public class TriggeredEventSO : EventSO
{
    [SerializeField] private int m_initNbUse = -1;
    [SerializeField] private int m_nbUse;
    [SerializeField] [CanBeNull] private ConditionSO m_cdtActivation;
    
    public int NbUse => m_nbUse;
    public ConditionSO CdtActivation => m_cdtActivation;

    public override void Initialize()
    {
        m_nbUse = m_initNbUse;
        if (m_cdtActivation != null)
            m_cdtActivation.Initialize();
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
        return m_cdtActivation.IsOneValid();
    }
    
    public void UseOnce()
    {
        if(!IsUnlimited())
            m_nbUse--;
    }
}
