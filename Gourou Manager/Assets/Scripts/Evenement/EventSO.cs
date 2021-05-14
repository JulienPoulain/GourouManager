using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEvent", menuName = "GourouManager/Evenement/Evenement")]
public class EventSO : ScriptableObject
{
    [SerializeField] private string m_name;
    [SerializeField] private string m_description;
    [SerializeField] private int m_duration;
    [SerializeField] private List<ImpactSO> m_impacts;
    [SerializeField] private List<InfoSO> m_infoGained;

    public string Name => m_name;
    public string Description => m_description;
    public int Duration => m_duration;
    public List<ImpactSO> Impacts => m_impacts;
    public List<InfoSO> InfoGained => m_infoGained;
}
