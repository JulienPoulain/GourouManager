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


<<<<<<< HEAD
            _rotateAroundMap = value;
            u_Camera.GetComponent<CameraControler>().m_cameraFocusOnMap = value;
        }
    }
    
    public void AddEvent()
=======
    // RoundManager c_RoundManager = new RoundManager;

    // Fin de tour
    bool _endTurn = false;
    public bool u_endTurn
>>>>>>> Interface
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
