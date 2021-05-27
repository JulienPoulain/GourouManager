using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEvent", menuName = "GourouManager/Evenement/Evenement")]
public class EventSO : ScriptableObject, IInitializable
{
    [SerializeField] protected string m_name;
    [SerializeField] protected string m_description;
    [SerializeField] protected int m_initDuration;
    [SerializeField] protected int m_duration;
    [SerializeField] protected int m_initDelay;
    [SerializeField] protected int m_delay;
    [SerializeField] protected List<ImpactSO> m_impacts;
    [SerializeField] protected List<InfoSO> m_infoGained;

    public string Name => m_name;
    public string Description => m_description;
    public int Duration => m_duration;
    public int Delay => m_delay;
    public List<ImpactSO> Impacts => m_impacts;
    public List<InfoSO> InfoGained => m_infoGained;

    public virtual void Initialize()
    {
        m_duration = m_initDuration;
        m_delay = m_initDelay;

        foreach (ImpactSO impact in m_impacts)
        {
            impact.Initialize();
        }

        foreach (InfoSO info in m_infoGained)
        {
            info.Initialize();
        }
    }

    public void Reset()
    {
        m_duration = m_initDuration;
    }
    
    public void AdvanceTime(int p_duration)
    {
        if (m_duration == 0)
        {
            Debug.Log("<color=red>ERROR :</color> Évènement terminé toujours présent.");
            return;
        }
        // Évènement infini
        if (Duration < 0) 
            return;
        // Évènement à durée limitée
        m_duration -= p_duration;
        if (m_duration < 0)
            m_duration = 0;
        // Évènement délayé
        m_delay -= p_duration;
        if (m_delay < 0)
            m_delay = 0;
    }

    public bool IsActive()
    {
        return m_duration != 0;
    }

    public bool IsDelayed()
    {
        // TODO
        return false;
    }
}
