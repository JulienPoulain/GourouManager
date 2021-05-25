using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextApprocheMain : MonoBehaviour
{
    [SerializeField] GameObject [] m_approche;

    [Tooltip("Definit la scene de l'interlocutor (à definir plus tard depuis l'interlocutorSO")]
    // [SerializeField] string m_approachSceneToLoad;

    List<TextApprocheIndividual> m_approcheScript = new List<TextApprocheIndividual>();

    [SerializeField] Image m_interlocutorImage;

    void Awake()
    {
        Debug.Log("LE MAIN START");
        foreach (GameObject thisObject in m_approche)
        {
            m_approcheScript.Add(thisObject.GetComponent<TextApprocheIndividual>());
        }
    }
    
    // on prend tous les scripts InterlocutorSO pour les configurer avec les ApprochSO correspondants
    public void Display(InterlocutorSO p_interlocutor) // depuis InterfaceManager
    {
        foreach (GameObject approachText in m_approche)
        {
            approachText.SetActive(false);
        }

        for (int i = 0; i < p_interlocutor.m_approach.Count; i++)
        {
            m_approche[i].SetActive(true);
            m_approcheScript[i].DisplayApproach(p_interlocutor.m_approach[i]);
        }

        m_interlocutorImage.sprite = p_interlocutor.m_sprite;
    }
}
