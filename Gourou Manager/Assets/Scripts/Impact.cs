public class Impact
{
    private SyncIntSO m_ressource;
    private OperationSO m_magnitude;

    public SyncIntSO Ressource => m_ressource;
    public OperationSO Magnitude => m_magnitude;

    public Impact(ImpactSO p_impactSO)
    {
        m_ressource = p_impactSO.Ressource;
        m_magnitude = p_impactSO.Magnitude;
    }
}
