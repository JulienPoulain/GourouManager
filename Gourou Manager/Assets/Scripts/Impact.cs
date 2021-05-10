using UnityEngine;

public class Impact
{
    private SyncIntSO m_ressource;
    private OperationSO m_magnitude;
    private int m_duration;

    public SyncIntSO Ressource => m_ressource;
    public OperationSO Magnitude => m_magnitude;
    public int Duration => m_duration;

    public Impact(ImpactSO p_impactSO)
    {
        m_ressource = p_impactSO.Ressource;
        m_magnitude = p_impactSO.Magnitude;
        m_duration = p_impactSO.Duration;
    }
    
    public void Apply()
    {
        //m_ressource.Value += m_magnitude;
    }
}
