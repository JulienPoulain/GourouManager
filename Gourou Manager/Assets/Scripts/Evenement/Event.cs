using System.Collections.Generic;
using UnityEngine;

public class Event
{
    private string m_name;
    private string m_description;
    private int m_duration;
    private List<Impact> m_impacts;
    private List<InfoSO> m_infoGained;

    public string Name => m_name;
    public string Description => m_description;
    public int Duration => m_duration;
    public List<Impact> Impacts => m_impacts;
    public List<InfoSO> InfoGained => m_infoGained;
    

    public Event(EventSO p_eventSO)
    {
        m_name = p_eventSO.Name;
        m_description = p_eventSO.Description;
        m_duration = p_eventSO.Duration;
        
        m_impacts = new List<Impact>();
        foreach (ImpactSO impact in p_eventSO.Impacts)
        {
            m_impacts.Add(new Impact(impact));
        }
        
        m_infoGained = new List<InfoSO>();
        foreach (InfoSO info in p_eventSO.InfoGained)
        {
            m_infoGained.Add(info);
        }
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
    }
}
