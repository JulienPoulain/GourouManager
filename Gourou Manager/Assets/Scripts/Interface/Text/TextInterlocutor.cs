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

    private TMP_Text m_description;
    private List<TMP_Text> m_accessibility = new List<TMP_Text>();
    private List<TMP_Text> m_condition = new List<TMP_Text>();  
    private TMP_Text m_menace;

    private InterlocutorSO m_Interlocutor;
    
    // si les interlocutor ne sont pas accessible : on affiche m_description + m_accessibility
    // si les interlocuteurs sont accessible : on affiche en plus m_condition + m_menace

    void Start()
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
    }
    
    public void Display(InterlocutorSO p_data) // appeler depuis InterlocutorButton
    {
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
    }

    void InterlocutorIsAccessible()
    {
        // condition
        for (int i = 0; i < m_Interlocutor.m_approach.Count; i++)
        {
            m_condition[i].text = "" +  m_Interlocutor.m_approach[i].m_descriptionApproach;
        }
        // menace
        m_menace.text = "" + m_Interlocutor.m_description; // m_risque
    }

    void InterlocutorIsNotAccessible()
    {
        m_description.text = "" + m_Interlocutor.m_description;
        
        for (int i = 0; i < m_accessibilityOb.Count; i++)
        {
            // On affiche : nom de la ressource / le tyle (> || < || =) / valeur de la ressource
            // string accessCondition = ConditionTypeToString(m_Interlocutor.AccessCondition[i].m_conditionType);
            // m_accessibility[i].text = "" + m_Interlocutor.AccessCondition[i].m_ressource.Name + " " + accessCondition + " " + m_Interlocutor.AccessCondition[i].m_ressource.m_value;
            m_accessibility[i].text = m_Interlocutor.AccessCondition[i].ToString();
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
        
        int count = m_Interlocutor.AccessCondition.Count;
        for (int i = 0; i < m_accessibilityOb.Count; i++)
        {
            m_accessibilityOb[i].SetActive(true);
        }
    }

    void DisallowAll()
    {
        m_descriptionOb.SetActive(false);
        
        for (int i = 0; i < m_accessibilityOb.Count; i++)
        {
            m_accessibilityOb[i].SetActive(false);
        }
        
        for (int i = 0; i < m_conditionOb.Count; i++)
        {
            m_conditionOb[i].SetActive(false);
        }
        
        m_menaceOb.SetActive(false);
    }

    /*
    string ConditionTypeToString(ConditionType p_condition)
    {
        switch (p_condition)
        {
            case ConditionType.Lesser:
                return "<";
                break;
            case ConditionType.Equal:
                return "=";
                break;
            case ConditionType.Greater:
                return ">";
                break;
            default:
                return "?";
                break;
        }
    }
    */

    public void SpeekToInterlocutor()
    {
        if (m_Interlocutor.IsAccessible())
        {
            GameManager.Instance.m_InterfaceManager.DisplayApproche(m_Interlocutor);
        }
    }

    public void ExitInterlocutorInterface()
    {
        GameManager.Instance.m_InterfaceManager.DisallowInterlocutor();
    }

    public void ForcerApproche()
    {
        GameManager.Instance.m_InterfaceManager.DisplayApproche(m_Interlocutor);
    }
}
