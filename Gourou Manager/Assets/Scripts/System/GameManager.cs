using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // GameManager.Instance.WhatYouWant

    [SerializeField] public ScriptableObject[] u_Institutions;
    [SerializeField] public ScriptableObject[] u_Crise;
    [SerializeField] public InterfaceManager u_InterfaceManager;
    [SerializeField] public GameObject u_Camera;
    
    [SerializeField] public List<ExactionSO> m_pendingExactions;
    [SerializeField] public List<Event> m_activeEvents;

    public bool m_focusOnInstitution = false;

    public void AddEvent()
    {
        foreach (ExactionSO exactionSO in m_pendingExactions)
        {
            foreach (EventSO eventSO in exactionSO.EventList)
            {
                m_activeEvents.Add(new Event(eventSO));
            }
        }
        m_pendingExactions.Clear();
    }

    public void EndTurn()
    {
        RoundManager.Instance.NextTurn();
    }
}
