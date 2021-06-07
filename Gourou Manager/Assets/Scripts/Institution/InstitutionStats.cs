public class InstitutionStats
{
    int m_funds;
    int m_members;
    int m_fanatics;
    int m_publicExposure;
    int m_brutality;
    int m_decay;

    public InstitutionStats()
    {
        m_funds = 0;
        m_members = 0;
        m_fanatics = 0;
        m_publicExposure = 0;
        m_brutality = 0;
        m_decay = 0;
    }
    
    public InstitutionStats(InstitutionSO p_institution)
    {
        m_funds = p_institution.Funds.Value;
        m_members = p_institution.Members.Value;
        m_fanatics = p_institution.Fanatics.Value;
        m_publicExposure = p_institution.PublicExposure.Value;
        m_brutality = p_institution.Brutality.Value;
        m_decay = p_institution.Decay.Value;
    }

    public int Funds => m_funds;
    public int Members => m_members;
    public int Fanatics => m_fanatics;
    public int PublicExposure => m_publicExposure;
    public int Brutality => m_brutality;
    public int Decay => m_decay;

    public override string ToString()
    {
        return
            $"Fonds ({m_funds}), Membres ({m_members}), Fanatiques ({m_fanatics}) Exposition publique ({m_publicExposure}), brutalité ({m_brutality}), Corruption({m_decay})";
    }
    
    public (int fundsDif, int membersDif, int fanaticsDif, int publicExposureDif, int brutalityDif, int decayDif) Compare(InstitutionStats p_institutionStats)
    {
        int fundsDif = m_funds - p_institutionStats.Funds;
        int membersDif = m_members - p_institutionStats.Members;
        int fanaticsDif = m_fanatics - p_institutionStats.Fanatics;
        int publicExposureDif = m_publicExposure - p_institutionStats.PublicExposure;
        int brutalityDif = m_brutality - p_institutionStats.Brutality;
        int decayDif = m_decay - p_institutionStats.Decay;
        
        return (fundsDif, membersDif, fanaticsDif, publicExposureDif, brutalityDif, decayDif);
    }
}
