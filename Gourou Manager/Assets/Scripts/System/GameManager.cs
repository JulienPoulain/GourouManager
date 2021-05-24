using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IInitializable
{
    [SerializeField] GameObject m_MainInstitution;
    [SerializeField] List<GameObject> m_Institutions = new List<GameObject>();

    [SerializeField] InstitutionSO m_MainInstitutionSO;
    [SerializeField] List<InstitutionSO> m_institutions = new List<InstitutionSO>();

    //[SerializeField] public ScriptableObject[] m_Institutions;
    //[SerializeField] public ScriptableObject[] m_Crise;

    [SerializeField] public RoundManager m_roundManager;
    [SerializeField] public InterfaceManager m_InterfaceManager;
    [SerializeField] public GameObject m_Camera;
    
    [SerializeField] private static List<ExactionSO> m_pendingExactions = new List<ExactionSO>();
    [SerializeField] private List<EventSO> m_activeEvents = new List<EventSO>();

    public bool m_focusOnInstitution = false;
    [SerializeField] private int m_turn;

    public List<ExactionSO> PendingExactions => m_pendingExactions;
    public List<EventSO> ActiveEvents => m_activeEvents;
    public int Turn => m_turn;

    public InstitutionSO MainInstitution => m_MainInstitutionSO;
    public List<InstitutionSO> Institutions => m_institutions;

    // Player Variable //
    
    private static bool m_playerHasExecuteExaction = false; // définit si le joueur à déjà fait une exaction ce tour ci, static pour que l'information ne change pas entre les changments de scènes
    private static bool m_playerHasExecuteApproche = false;    // Définit si le joueur à déjà fait un dialogue ce tour ci
    
    public bool PlayerHasExecuteApproach
    {
        get { return m_playerHasExecuteApproche; }
        set { m_playerHasExecuteApproche = value;}
    }
    public bool PlayerHasExectuteExaction
    {
        get { return m_playerHasExecuteExaction; }
        set { m_playerHasExecuteExaction = value; }
    }

    public void Initialize()
    {
        m_turn = 0;
        foreach (InstitutionSO institution in m_institutions)
        {
            institution.Initialize();
        }
    }
    
    private void Start()
    {
        m_MainInstitutionSO = m_MainInstitution.GetComponent<InterfaceInstitution>().m_Institution;

        foreach (GameObject Institution in m_Institutions)
        {
            m_institutions.Add(Institution.GetComponent<InterfaceInstitution>().m_Institution);
        }

        Initialize();
    }

    public void EndTurn()
    {
        Debug.Log("FIN DU TOUR");
        
        // On copie la liste des exactions, pour afficher les exactions faites dans l'interface
        List<ExactionSO> exactionList = new List<ExactionSO>();
        foreach (ExactionSO exaction in m_pendingExactions)
        {
            exactionList.Add(exaction);
        }

        RoundManager.Instance.NextTurn();

        Debug.Log("LE NOMBRE D'ELEMENT DANS LE TABLEAU EST DE : " + exactionList.Count);

        
        m_turn++;

        m_playerHasExecuteExaction = false;
        m_playerHasExecuteApproche = false;

        m_InterfaceManager.DisplayEndTurn(exactionList);
    }
}
