using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExactionSO", menuName = "Exactions")]

public class ExactionSO : ScriptableObject
{
    [SerializeField] private List<EventSO> m_eventList;

    public List<EventSO> EventList => m_eventList;
    [SerializeField] public string m_name;
    [SerializeField] public string m_description;
    
    [SerializeField] private int duree;
    [SerializeField] private List<ImpactSO> impactList;
}
