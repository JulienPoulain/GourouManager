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

    [SerializeField] TextApprocheMain m_mainApproach;   // servira � stocker l'approach choisis

    [SerializeField] ButtonFeedBack m_buttonFeedBack;

    ApproachSO m_approche;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void DisplayApproach(ApproachSO p_approach)
    {
        this.gameObject.SetActive(true);

        m_approche = p_approach;
        
        if (m_approche.RemainingTime == 0)
        {
            m_buttonFeedBack.enabled = true;
        }
        else
        {
            m_buttonFeedBack.enabled = false;
        }

        m_name.text = "" + m_approche.Name;
        m_dialogueCharacter.text = "" + m_approche.m_dialogueApproach;
        m_gain.text = "" + m_approche.m_resultatApproach;
    }

    public void ExecuteApproche()
    {
        if (m_approche.RemainingTime == 0)
        {
            GameManager.Instance.PendingExactions.Add(m_approche.TryApproach());
            GameManager.Instance.ApproachesAttempted.Add(m_approche);
            GameManager.Instance.m_interfaceManager.DisallowApproche();
            GameManager.Instance.m_interfaceManager.CameraReset();
            m_approche = null;

            GameManager.Instance.EndTurn();
        }
    }
}
