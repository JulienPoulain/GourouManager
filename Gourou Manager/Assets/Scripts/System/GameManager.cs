using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    ///!\ Remplace les u_ par des m_ nom de Dieu /!\
    [SerializeField] public ScriptableObject[] m_Institutions;
    [SerializeField] public ScriptableObject[] m_Crise;
    
    [SerializeField] public InterfaceManager m_InterfaceManager;
    [SerializeField] public GameObject m_Camera;
    
    [SerializeField] public List<ExactionSO> m_pendingExactions = new List<ExactionSO>();
    public List<Event> m_activeEvents = new List<Event>();

    public bool m_focusOnInstitution = false;
    int m_turn = 0;

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
        m_turn++;
        Debug.Log("FIN DU TOUR");
        Debug.Log(m_turn);
    }
}
