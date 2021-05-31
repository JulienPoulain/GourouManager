using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>, IInitializable
{
    [SerializeField] GameObject m_mainInstitutionObject;
    [SerializeField] List<GameObject> m_institutionsObjectList = new List<GameObject>();

    [SerializeField] InstitutionSO m_mainInstitution;
    [SerializeField] List<InstitutionSO> m_institutions = new List<InstitutionSO>();
    private InstitutionScript m_mainInstitutionScript;

    //[SerializeField] public ScriptableObject[] m_Institutions;
    //[SerializeField] public ScriptableObject[] m_Crise;

    [SerializeField] public RoundManager m_roundManager;
    [SerializeField] public InterfaceManager m_interfaceManager;
    
    [SerializeField] public GameObject m_camera;
    
    [SerializeField] private List<ExactionSO> m_pendingExactions = new List<ExactionSO>();
    [SerializeField] private List<EventSO> m_activeEvents = new List<EventSO>();

    [SerializeField] private List<ConditionSO> m_cdtVictory;
    [SerializeField] private List<ConditionSO> m_cdtDefeat;

    public bool m_focusOnInstitution = false;
    [SerializeField] private int m_turn;

    public List<ExactionSO> PendingExactions => m_pendingExactions;
    public List<EventSO> ActiveEvents => m_activeEvents;
    public int Turn => m_turn;

    public InstitutionScript MainInstitutionScript => m_mainInstitutionScript;

    public InstitutionSO MainInstitution => m_mainInstitution;
    public List<InstitutionSO> Institutions => m_institutions;    

    // Player Variable //
    
    private bool m_playerHasExecuteAction = false; 
    
    public bool PlayerHasExecuteAction
    {
        get { return m_playerHasExecuteAction; }
        set
        {
            m_playerHasExecuteAction = value;
            
            // feed back sur le boutton de fin de tour (changement de couleur, et animation)
            if (value == true)
            {
                m_interfaceManager.m_nextTurnButtonImage.color = Color.red;
                StartCoroutine(m_interfaceManager.ChangeNextTurnButtonSizeAnimation());
            }
            else
            {
                m_interfaceManager.m_nextTurnButtonImage.color = Color.white;
            }
        }
    }

    public void Initialize()
    {
        m_turn = 0;
        
        foreach (InstitutionSO institution in m_institutions)
            institution.Initialize();

        // Initializastion des conditions de victoire.
        if (m_cdtVictory.Count < 1)
            Debug.Log("<color=red>ERROR :</color> Aucune condition de victoire.");
        else
            foreach (ConditionSO condition in m_cdtVictory)
                condition.Initialize();

        // Initialisation des conditions de défaite.
        if (m_cdtDefeat.Count < 1)
            Debug.Log("<color=red>ERROR :</color> Aucune condition de défaite.");
        else
            foreach (ConditionSO condition in m_cdtDefeat)
                condition.Initialize();
            
    }
    
    private void Start()
    {
        //m_mainInstitution = m_mainInstitutionObject.GetComponent<InterfaceInstitution>().m_Institution;

        foreach (GameObject Institution in m_institutionsObjectList)
        {
            m_institutions.Add(Institution.GetComponent<InstitutionScript>().m_Institution);
        }

        m_mainInstitutionScript = m_mainInstitutionObject.GetComponent<InstitutionScript>();
        m_mainInstitution = m_mainInstitutionScript.m_Institution; 

        //m_cameraScript = m_camera.GetComponent<CameraManager>();

        Initialize();
    }

    public void EndTurn()
    {
        Debug.Log("FIN DU TOUR");

        PlayerHasExecuteAction = false;

        RoundManager.Instance.NextTurn();

        m_interfaceManager.DisplayEndTurn();

        TryEndGame();

        m_turn++;
    }

    
    // GESTION DES CONDITIONS DE VICTOIRE ET DÉFAITE
    
    private void TryEndGame()
    {
        if (IsVictory())
            Victory();
        else if (IsDefeat())
            Defeat();
    }

    private bool IsVictory()
    {
        if (m_cdtVictory.Count > 0)
            return ConditionSO.IsAllValid(m_cdtVictory);
        return false;
    }

    private bool IsDefeat()
    {
        if (m_cdtDefeat.Count > 0)
            return ConditionSO.IsAllValid(m_cdtDefeat);
        return false;
    }

    private void Victory()
    {
        Debug.Log("### VICTOIRE ###");
        m_interfaceManager.DisplayVictory();
    }

    private void Defeat()
    {
        Debug.Log("### DEFAITE ###");
        m_interfaceManager.DisplayDefeat();
    }
}
