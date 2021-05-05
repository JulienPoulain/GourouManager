using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // GameManager.Instance.WhatYouWant

    [SerializeField] public ScriptableObject[] u_Institutions;
    [SerializeField] public ScriptableObject[] u_Crise;
    [SerializeField] public InterfaceManager u_InterfaceManager;

    [SerializeField] public GameObject u_Camera;

    public bool m_focusOnInstitution = false;


    // RoundManager c_RoundManager = new RoundManager;

    // Fin de tour
    bool _endTurn = false;
    public bool u_endTurn
    {
        get {return _endTurn;}
        set 
        {
            if (!value) return;

            // RoundManager.nextTurn
        }
    }
}
