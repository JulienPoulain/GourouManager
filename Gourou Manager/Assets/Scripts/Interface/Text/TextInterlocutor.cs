using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInterlocutor : MonoBehaviour
{
    [SerializeField] private GameObject m_descriptionOb;
    [SerializeField] private List<GameObject> m_accessibilityOb;
    [SerializeField] private List<GameObject> m_conditionOb = new List<GameObject>();
    [SerializeField] private GameObject m_menaceOb;
    [SerializeField] private GameObject m_buttonSpeakToInterlocutor; // permettra de l'afficher lorsqu'un interlocuteur est selectionner

    [SerializeField] [Tooltip("comprend les textes qui ne sont pas modifiers, pour les afficher dès que nécessaire")] private List<GameObject> m_TextAnnexe = new List<GameObject>();

    private TMP_Text m_description;
    private List<TMP_Text> m_accessibility = new List<TMP_Text>();
    private List<TMP_Text> m_condition = new List<TMP_Text>();  
    private TMP_Text m_menace;

    [Tooltip("Definit si l'interface Interlocuteur cible un personnage ou non, utile pour éviter les bugs")] public bool m_InterlocutorSelected = false;

    private InterlocutorSO m_Interlocutor;

    public string m_approachSceneToLoad;
    
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
        
        for (int i = 0; i < m_conditionOb.Count; i++)
        {
            m_condition.Add(m_conditionOb[i].GetComponent<TMP_Text>());
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
        DisplayNotAccessibleInterlocutorText();
        InterlocutorIsNotAccessible();

        // Si l'interlocuteur est accessible, on affiche le reste
        if (p_data.IsAccessible())
        {
            DisplayAcessibleInterlocutorText();
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
        // condition
        for (int i = 0; i < m_Interlocutor.m_approach.Count; i++)
        {
            m_condition[i].text = "" +  m_Interlocutor.m_approach[i].m_dialogueApproach;
        }
        // menace
        m_menace.text = "" + m_Interlocutor.m_descriptionFailure; // m_risque

        m_buttonSpeakToInterlocutor.SetActive(true); // on affiche le boutton : Parler à l'interlocuteur
    }

    void InterlocutorIsNotAccessible()
    {
        m_description.text = "" + m_Interlocutor.m_description;

        for (int i = 0; i < m_Interlocutor.AccessCondition.Count; i++)
        {            
            // On affiche : nom de la ressource / le tyle (> || < || =) / valeur de la ressource
            m_accessibility[i].text = "" + m_Interlocutor.AccessCondition[i].ToString();
        }
    }
    
    void DisplayAcessibleInterlocutorText()
    {
        int count = m_Interlocutor.m_approach.Count;
        
        for (int i = 0; i < count; i++)
        {
            m_conditionOb[i].SetActive(true);
        }
        
        m_menaceOb.SetActive(true);
    }

    void DisplayNotAccessibleInterlocutorText()
    {
        m_descriptionOb.SetActive(true);

        Debug.Log(m_Interlocutor);

        if (m_Interlocutor != null)
        {
            int count = m_Interlocutor.AccessCondition.Count;

            for (int i = 0; i < m_accessibilityOb.Count; i++)
            {
                m_accessibilityOb[i].SetActive(true);
            }
        }
        else
        {
            Debug.Log("L'interlocutor " + m_Interlocutor + " n'est pas de conditions d'acces!");
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
        
        for (int i = 0; i < m_conditionOb.Count; i++)
        {
            m_conditionOb[i].SetActive(false);
        }
        
        m_menaceOb.SetActive(false);

        m_buttonSpeakToInterlocutor.SetActive(false);
    }

    public void SpeekToInterlocutor()
    {
        if (m_Interlocutor.IsAccessible() && m_InterlocutorSelected  && !GameManager.Instance.PlayerHasExecuteAction)
        {
            GameManager.Instance.m_interfaceManager.CameraChange();     // On place la camera liee a l'institution
            GameManager.Instance.m_interfaceManager.DisplayApproche(m_Interlocutor);
            GameManager.Instance.m_interfaceManager.DisallowInterlocutor();

            GameManager.Instance.PlayerHasExecuteAction = true;
            Debug.Log("Institution : " + GameManager.Instance.PlayerHasExecuteAction);
        }
        else if (!m_Interlocutor.IsAccessible())
        {
            GameManager.Instance.m_interfaceManager.m_feedBackScript.FeedBackApproachNotValid();
            Debug.Log("Cet Interlocuteur n'est pas disponible, ou tu n'as pas sélectionner d'interlocuteurs");
        }
        else if (GameManager.Instance.PlayerHasExecuteAction)
        {
            GameManager.Instance.m_interfaceManager.m_feedBackScript.FeedBackApproachDouble();
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

    // appeler depuis un boutton, option de dev, à supprimer pour le public
    public void ForcerApproche()
    {
        if (m_InterlocutorSelected)
        {
            GameManager.Instance.m_interfaceManager.DisplayApproche(m_Interlocutor);
            GameManager.Instance.m_interfaceManager.DisallowInterlocutor();
            // Il y avait le changement de scene ici
            GameManager.Instance.PlayerHasExecuteAction = true;
            Debug.Log("Institution : " + GameManager.Instance.PlayerHasExecuteAction);
        }
        else
        {
            Debug.Log("Tu n as pas selectionner d'interlocuteurs");
        }
    }
}
