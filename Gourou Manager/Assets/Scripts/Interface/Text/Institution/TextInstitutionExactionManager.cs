using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInstitutionExactionManager : MonoBehaviour
{
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_textDescription;

    Image m_thisImage;

    ExactionSO m_exaction;

    private void Start()
    {
        m_thisImage = GetComponentInChildren<Image>();
    }

    public void Display(ExactionSO p_exaction)
    {
        m_exaction = p_exaction;

        m_textNom.text = "" + p_exaction.Name;
        m_textDescription.text = "" + p_exaction.Description;

        // Changement de la couleur selon si l'exaction est valide ou non
        if (p_exaction.IsValid())
        {
            m_thisImage.sprite = GameManager.Instance.m_interfaceManager.m_redBackGroundSprite;
        }
        else
        {
            m_thisImage.sprite = GameManager.Instance.m_interfaceManager.m_whiteBackGroundSprite;
        }
    }

    public void ExecuteExaction()
    {
        if (!GameManager.Instance.PlayerHasExectuteExaction && m_exaction.IsValid())
        {
            GameManager.Instance.PendingExactions.Add(m_exaction);
            GameManager.Instance.m_interfaceManager.DisallowHeavyInstitution();
            GameManager.Instance.m_interfaceManager.m_feedBackScript.FeedBackExaction();

            GameManager.Instance.PlayerHasExectuteExaction = true;
        } 
        else if (!m_exaction.IsValid())
        {
            GameManager.Instance.m_interfaceManager.m_feedBackScript.FeedBackExactionNotValid();
        }
        else if (GameManager.Instance.PlayerHasExectuteExaction)
        {
            GameManager.Instance.m_interfaceManager.m_feedBackScript.FeedBackExactionDouble();
        }
        
    }
}
