using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject m_MainInstitution;
    [SerializeField] List<GameObject> m_Institutions = new List<GameObject>();

    InstitutionSO m_MainInstitutionSO;
    List<InstitutionSO> m_institutions = new List<InstitutionSO>();

    //[SerializeField] public ScriptableObject[] m_Institutions;
    //[SerializeField] public ScriptableObject[] m_Crise;

    [SerializeField] public RoundManager m_roundManager;
    [SerializeField] public InterfaceManager m_InterfaceManager;
    [SerializeField] public GameObject m_Camera;
    
    [SerializeField] private List<ExactionSO> m_pendingExactions = new List<ExactionSO>();
    private List<Event> m_activeEvents = new List<Event>();

    public bool m_focusOnInstitution = false;
    int m_turn = 0;

    public List<ExactionSO> PendingExactions => m_pendingExactions;

    public List<Event> ActiveEvents => m_activeEvents;

    public List<InstitutionSO> Institutions => m_institutions;

    private void Start()
    {
        m_MainInstitutionSO = m_MainInstitution.GetComponent<InterfaceInstitution>().m_Institution;

        foreach (GameObject Institution in m_Institutions)
        {
            m_institutions.Add(Institution.GetComponent<InterfaceInstitution>().m_Institution);
            
        }

        foreach (InstitutionSO institutionSO in m_institutions)
        {
            institutionSO.init();
        }
    }

    public void EndTurn()
    {
        RoundManager.Instance.NextTurn();
        m_turn++;
        Debug.Log("FIN DU TOUR");
        Debug.Log(m_turn);
    }
}
