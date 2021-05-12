using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExactionSO", menuName = "GourouManager/Dialogue/Exaction")]

public class ExactionSO : ScriptableObject
{
    [SerializeField] private string m_name;
    [SerializeField] private string m_description;
    [SerializeField] private List<EventSO> m_eventList;
    
    public string Name => m_name;

    public string Description => m_description;
    
    public List<EventSO> EventList => m_eventList;
}
