using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject m_MainInstitution;
    [SerializeField] List<GameObject> m_Institutions = new List<GameObject>();

    InstitutionSO m_MainInstitutionSO;
    List<InstitutionSO> m_InstitutionsSO = new List<InstitutionSO>();

    //[SerializeField] public ScriptableObject[] m_Institutions;
    //[SerializeField] public ScriptableObject[] m_Crise;
    
    [SerializeField] public InterfaceManager m_InterfaceManager;
    [SerializeField] public GameObject m_Camera;
    
    [SerializeField] public List<ExactionSO> m_pendingExactions = new List<ExactionSO>();
    public List<Event> m_activeEvents = new List<Event>();

    public bool m_focusOnInstitution = false;
    int m_turn = 0;

    private void Start()
    {
        m_MainInstitutionSO = m_MainInstitution.GetComponent<InterfaceInstitution>().m_Institution;

        foreach (GameObject Institution in m_Institutions)
        {
            m_InstitutionsSO.Add(Institution.GetComponent<InterfaceInstitution>().m_Institution);
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
        m_turn++;
        Debug.Log("FIN DU TOUR");
        Debug.Log(m_turn);
    }
}
