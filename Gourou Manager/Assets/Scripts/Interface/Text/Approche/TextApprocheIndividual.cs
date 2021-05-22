using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextApprocheIndividual : MonoBehaviour
{
    [SerializeField] TMP_Text m_name;
    [SerializeField] TMP_Text m_dialogueCharacter;
    [SerializeField] TMP_Text m_gain;

    [SerializeField] TextApprocheMain m_mainApproach;   // servira à stocker l'approach choisis

    ApproachSO m_approche;
    public static List<ApproachSO> m_approachList = new List<ApproachSO>();

    void Start()
    {
        this.gameObject.SetActive(false);

        // Si la liste d'approach n'est pas vide, on affiche
        if (m_approachList.Count != 0)
        {
            DisplayApproach();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void StoreApproach(ApproachSO p_approach)
    {
        m_approachList.Add(p_approach);
        Debug.Log("approach stocker ");
    }

    public void DisplayApproach()
    {
        this.gameObject.SetActive(true);

        m_approche = m_approachList[0];
        m_approachList.RemoveAt(0);
        
        Debug.Log("l'approach est stockee");

        m_name.text = "" + m_approche.Name;
        m_dialogueCharacter.text = "" + m_approche.m_dialogueApproach;
        m_gain.text = "" + m_approche.m_resultatApproach;
    }

    public void ExecuteApproche()
    {
        // Debug.Log("L'approach n'est pas faite !");
        m_mainApproach.StoreApproach(m_approche);
        SceneManager.LoadScene("Julian_project");

        /*
        GameManager.Instance.PendingExactions.Add(m_Approche.TryApproach());
        Debug.Log("Approche fait");
        GameManager.Instance.m_InterfaceManager.DisallowApproche();
        */

        m_approche = null;
    }
}

// fonctionnement de l'approache :
// le principe est, avantr le changement de scene, envoyer les approach dans la 
// list d'approach static, puis, une fois dans l'autre scene, récupérer les approach
// pour les afficher, celui qui est retenu est envoyer dans le main, où on pourra l'ajouter
// à la fin du tour
