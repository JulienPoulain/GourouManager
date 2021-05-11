using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInterlocutor : MonoBehaviour
{
    [SerializeField] private GameObject m_descriptionOb;
    [SerializeField] private GameObject m_accessibilityOb;
    [SerializeField] private List<GameObject> m_conditionOb = new List<GameObject>();
    [SerializeField] private GameObject m_menaceOb;

    private TMP_Text m_description;
    private TMP_Text m_accessibility;
    private List<TMP_Text> m_condition = new List<TMP_Text>(); 
    private TMP_Text m_menace;

    void Start()
    {
        m_description = m_descriptionOb.GetComponent<TMP_Text>();
        m_accessibility = m_accessibilityOb.GetComponent<TMP_Text>();

        for (int i = 0; i < m_conditionOb.Count; i++)
        {
            m_condition[i] = m_conditionOb[i].GetComponent<TMP_Text>();
        }

        m_menace = m_menaceOb.GetComponent<TMP_Text>();
    }
    
    void Display(InterlocutorSO p_data)
    {
        DisallowAll();
        
        if (p_data.IsAccessible())
        {
            
            InterlocutorIsAccessible(p_data);
        }
        
        m_description.text = "" + p_data.m_description;
        m_accessibility.text = "" + p_data;
        m_menace.text = "";
    }

    void InterlocutorIsAccessible(InterlocutorSO p_data)
    {
        m_description.text = "" + p_data.m_description;
        m_accessibility.text = "" + p_data;
        
        for (int i = 0; i < p_data.m_accesConditionInt.Count; i++)
        {
            m_condition[i].text = "";
        }
        
        m_menace.text = "";
    }

    void InterlocutorIsNotAccessible()
    {
        
    }

    void DisplayAcessibleInterlocutorText()
    {
        
    }

    void DisplayNotAccessibleInterlocutorText()
    {
        
    }

    void DisallowAll()
    {
        m_descriptionOb.SetActive(false);
        m_accessibilityOb.SetActive(false);
        
        for (int i = 0; i < m_conditionOb.Count; i++)
        {
            m_conditionOb[i].SetActive(false);
        }
        
        m_menaceOb.SetActive(false);
    }
}
