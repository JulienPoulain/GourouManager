using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictoEtatBehavior : MonoBehaviour
{
    [SerializeField] private Sprite m_hostile;
    [SerializeField] private Sprite m_mefiant;
    [SerializeField] private Sprite m_indiferent;
    [SerializeField] private Sprite m_complaisant;
    [SerializeField] private Sprite m_devoue;

    public Sprite DisplayStat(DecayLvl p_decay)
    {
        switch (p_decay)
        {
            case DecayLvl.Hostile:
                return m_hostile;
                break;
            case DecayLvl.Mefiant:
                return m_mefiant;
                break;
            case DecayLvl.Indifferent:
                return m_indiferent;
                break;
            case DecayLvl.Complaisant:
                return m_complaisant;
                break;
            case DecayLvl.Devoue:
                return m_devoue;
                break;
            default:
                return null;
        }
    }
}
