using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextApprocheMain : MonoBehaviour
{
    [SerializeField] GameObject [] m_approche;
    
    List<TextApprocheIndividual> m_approcheScript = new List<TextApprocheIndividual>();

    // sert à faire une interface responsive
    RectTransform m_canvasSize;

    void Start()
    {
        foreach (GameObject thisObject in m_approche)
        {
            m_approcheScript.Add(thisObject.GetComponent<TextApprocheIndividual>());
        }

        m_canvasSize = GameManager.Instance.m_InterfaceManager.m_canvasSize;
    }
    
    // on prend tous les scripts InterlocutorSO pour les configurer avec les ApprochSO correspondants
    public void Display(InterlocutorSO p_interlocutor)
    {
        float posX = 0;
        float posY = 0;

        // on desaffiche toute la liste
        foreach (GameObject thisObject in m_approche)
        {
            thisObject.SetActive(false);
        }

        transform.position = new Vector3(posX, posY, 0);

        // Pour afficher ceux dont on a besoin 
        for (int i = 0; i < p_interlocutor.m_approach.Count; i++)
        {
            m_approcheScript[i].Display(p_interlocutor.m_approach[i]);
            m_approche[i].SetActive(true);
        }
    }

    
}
