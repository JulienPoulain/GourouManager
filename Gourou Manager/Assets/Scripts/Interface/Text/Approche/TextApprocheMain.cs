using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextApprocheMain : MonoBehaviour
{
    [SerializeField] GameObject [] m_approche;

    [Tooltip("Definit la scene de l'interlocutor (à definir plus tard depuis l'interlocutorSO")]
    [SerializeField] string m_approachSceneToLoad;

    List<TextApprocheIndividual> m_approcheScript = new List<TextApprocheIndividual>();

    static InterlocutorSO m_interlocutor;
    public static ApproachSO m_approach;

    void Start()
    {
        foreach (GameObject thisObject in m_approche)
        {
            m_approcheScript.Add(thisObject.GetComponent<TextApprocheIndividual>());
        }

        // Idee pour l'instant abandonnee
        if (m_interlocutor != null)
        {
            // DisplayApproach(m_interlocutor);
        }

        // Si il y a une exaction au start, dans ce cas on lance range l'approach pour le prochain tour
        // Cette exaction est stocker depuis TextApproachIndividual
        if (m_approach != null)
        {
            Debug.Log("Approach executee");
            GameManager.Instance.PendingExactions.Add(m_approach.TryApproach());
            //m_approach = null;
            //m_interlocutor = null;
        }
    }
    
    // on prend tous les scripts InterlocutorSO pour les configurer avec les ApprochSO correspondants
    public void StoreInterlocutor(InterlocutorSO p_interlocutor) // depuis InterfaceManager
    {
        m_interlocutor = p_interlocutor;

        for (int i = 0; i < p_interlocutor.m_approach.Count; i++)
        {
            m_approche[i].SetActive(true);
            m_approcheScript[i].StoreApproach(p_interlocutor.m_approach[i]);
        }

        SceneManager.LoadScene(m_approachSceneToLoad);
    }

    /*  Je stocke ca auy cas où
    public void DisplayApproach(InterlocutorSO p_interlocutor)
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
    */

    // comme m_approach est static, on ne peut pas la modifier en dehor du script, on la midifie donc via une methode
    public void StoreApproach(ApproachSO p_approach)
    {
        m_approach = p_approach;
    }

    
}
