using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEvent", menuName = "GourouManager/Evenement/Evenement")]
public class EventSO : ScriptableObject, IInitializable
{
    [SerializeField] private string m_name;
    [SerializeField] private string m_description;
    [SerializeField] private int m_initDuration;
    private int m_duration;
    [SerializeField] private List<ImpactSO> m_impacts;
    [SerializeField] private List<InfoSO> m_infoGained;

    public string Name => m_name;
    public string Description => m_description;
    public int Duration => m_duration;
    public List<ImpactSO> Impacts => m_impacts;
    public List<InfoSO> InfoGained => m_infoGained;
    
    public void Initialize()
    {
        m_duration = m_initDuration;
        foreach (ImpactSO impact in m_impacts)
        {
            impact.Initialize();
        }

        foreach (InfoSO info in m_infoGained)
        {
            info.Initialize();
        }
    }
}
