using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextApprocheMain : MonoBehaviour
{
    [SerializeField] GameObject [] m_approche;
    
    List<TextApprocheIndividual> m_approcheScript = new List<TextApprocheIndividual>();

    void Start()
    {
        foreach (GameObject thisObject in m_approche)
        {
            m_approcheScript.Add(thisObject.GetComponent<TextApprocheIndividual>());
        }
    }
    
    // on prend tous les scripts InterlocutorSO pour les configurer avec les ApprochSO correspondants
    public void Display(InterlocutorSO p_interlocutor)
    {
        for (int i = 0; i < p_interlocutor.m_approach.Count; i++)
        {
            m_approcheScript[i].Display(p_interlocutor.m_approach[i]);
        }
    }
}
