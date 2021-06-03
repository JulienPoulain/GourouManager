using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInterlocutor : MonoBehaviour
{
    [SerializeField] private GameObject m_descriptionOb;
    [SerializeField] private List<GameObject> m_accessibilityOb = new List<GameObject>();
    [SerializeField] private GameObject m_menaceOb;
    [SerializeField] private GameObject m_buttonSpeakToInterlocutor; // permettra de l'afficher lorsqu'un interlocuteur est selectionner

    [SerializeField] [Tooltip("comprend les textes qui ne sont pas modifiers, pour les afficher dès que nécessaire")] private List<GameObject> m_TextAnnexe = new List<GameObject>();

    private TMP_Text m_description;
    private List<TMP_Text> m_accessibility = new List<TMP_Text>();
    private TMP_Text m_menace;

    [Tooltip("Definit si l'interface Interlocuteur cible un personnage ou non, utile pour éviter les bugs")] public bool m_InterlocutorSelected = false;

    private InterlocutorSO m_Interlocutor;

    [SerializeField] List<GameObject> m_buttonInterlocutorList = new List<GameObject>();
    List<InterlocutorButton> m_buttonScriptList = new List<InterlocutorButton>();

    [SerializeField] public Image m_backGroundColor;
    
    // si les interlocutor ne sont pas accessible : on affiche m_description + m_accessibility
    // si les interlocuteurs sont accessible : on affiche en plus m_condition + m_menace

    void Awake()
    {
        // On récupère les texts des GO
        m_description = m_descriptionOb.GetComponent<TMP_Text>();

        for (int i = 0; i < m_accessibilityOb.Count; i++)
        {
            m_accessibility.Add(m_accessibilityOb[i].GetComponent<TMP_Text>());
        }

        for (int i = 0; i < m_buttonInterlocutorList.Count; i++)
        {
            m_buttonScriptList.Add(m_buttonInterlocutorList[i].GetComponent<InterlocutorButton>());
        }

        m_menace = m_menaceOb.GetComponent<TMP_Text>();

        m_buttonSpeakToInterlocutor.SetActive(false);
    }
    
    public void Display(InterlocutorSO p_data) // appeler depuis 
    {
        m_InterlocutorSelected = true;
        m_Interlocutor = p_data;
        
        DisallowAll();

        // par default, l'interlocuteur est innaccessible, on affiche les 2 premières informations
        InterlocutorIsNotAccessible();

        // Si l'interlocuteur est accessible, on affiche le reste
        if (p_data.IsAccessible())
        {
            InterlocutorIsAccessible();
        }

        // On affiche les text non modifiers
        for (int i = 0; i < m_TextAnnexe.Count; i++)
        {
            m_TextAnnexe[i].SetActive(true);
        }
    }

    void InterlocutorIsAccessible()
    {
        // menace
        m_menaceOb.SetActive(true);
        m_menace.text = "" + m_Interlocutor.m_descriptionFailure; // m_risque

        m_buttonSpeakToInterlocutor.SetActive(true); // on affiche le boutton : Parler à l'interlocuteur
    }

    void InterlocutorIsNotAccessible()
    {
        m_descriptionOb.SetActive(true);
        m_description.text = "" + m_Interlocutor.m_description;

        if (m_Interlocutor.AccessCondition.Count != 0)
        {
            for (int i = 0; i < m_Interlocutor.AccessCondition.Count; i++)
            {            
                // On affiche : nom de la ressource / le tyle (> || < || =) / valeur de la ressource
                m_accessibilityOb[i].SetActive(true);
                m_accessibility[i].text = "" + m_Interlocutor.AccessCondition[i].ToString();
            }
        }
        else
        {
            m_accessibilityOb[0].SetActive(true);
            m_accessibility[0].text = "Aucune condition d'accès";
        }
        
    }

    void DisallowAll()
    {
        m_descriptionOb.SetActive(false);

        for (int i = 0; i < m_TextAnnexe.Count; i++)
        {
            m_TextAnnexe[i].SetActive(false);
        }

        for (int i = 0; i < m_accessibilityOb.Count; i++)
        {
            m_accessibilityOb[i].SetActive(false);
        }
        
        m_menaceOb.SetActive(false);

        m_buttonSpeakToInterlocutor.SetActive(false);
    }

    public void SpeekToInterlocutor()
    {
        if (m_Interlocutor.IsAccessible() && m_InterlocutorSelected)
        {
            GameManager.Instance.m_interfaceManager.CameraChange();     // On place la camera liee a l'institution
            GameManager.Instance.m_interfaceManager.DisplayApproche(m_Interlocutor);

            ResetInterlocutorInterface();
            
            GameManager.Instance.m_interfaceManager.DisallowInterlocutor();
        }
        else if (!m_Interlocutor.IsAccessible())
        {
            GameManager.Instance.m_interfaceManager.m_feedBackScript.FeedBackApproachNotValid();
            Debug.Log("Cet Interlocuteur n'est pas disponible, ou tu n'as pas sélectionner d'interlocuteurs");
        }
    }

    public void ExitInterlocutorInterface()
    {
        ResetInterlocutorInterface();
        m_InterlocutorSelected = false;
        GameManager.Instance.m_interfaceManager.DisallowInterlocutor();
    }

    // remet l'interface Interlocutor à zero
    public void ResetInterlocutorInterface()
    {
        m_Interlocutor = null;
        m_description.text = "C'est Ici que vous retrouverez les informations concernant les interlocuteurs.";

        // on desaffiche tout pour seulement afficher la description, comme au demarrage
        DisallowAll();
        m_descriptionOb.SetActive(true);
    }

    // Configuration des bouttons / appeler via InterfaceManager
    public void ConfigureButton(InstitutionSO p_institution)
    {
        // On les désactive tous pour les remettres
        foreach(GameObject interlocutorObject in m_buttonInterlocutorList)
        {
            interlocutorObject.SetActive(false);
        }
        // On initialise les Bouttons
        for (int i = 0; i < p_institution.m_interlocutorList.Count; i++)
        {
            m_buttonInterlocutorList[i].SetActive(true);
            m_buttonScriptList[i].Configuration(p_institution.m_interlocutorList[i]);
        }
    }
}
