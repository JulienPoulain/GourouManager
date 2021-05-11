using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // GameManager.Instance.WhatYouWant

    [SerializeField] public ScriptableObject [] u_Institutions;
    [SerializeField] public ScriptableObject [] u_Crise;
    [SerializeField] public InterfaceManager u_InterfaceManager;
    [SerializeField] public GameObject u_Camera;
    
    [SerializeField] public List<ExactionSO> m_pendingExactions;
    [SerializeField] public List<Event> m_activeEvents;

    // RoundManager c_RoundManager = new RoundManager;

    // Mode : Rotation autour de la carte
    bool _rotateAroundMap = false;
    public bool u_rotateAroundMap
    {
        get { return _rotateAroundMap; }
        set
        {
            if (value == _rotateAroundMap) return;

            _rotateAroundMap = value;
            u_Camera.GetComponent<CameraControler>().m_cameraFocusOnMap = value;
        }
    }
    
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
