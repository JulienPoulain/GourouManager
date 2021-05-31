using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextCultStat : MonoBehaviour
{
    [SerializeField] TMP_Text m_name;
    [SerializeField] TMP_Text m_fonds;
    [SerializeField] TMP_Text m_membres;
    [SerializeField] TMP_Text m_fanatiques;
    [SerializeField] TMP_Text m_expositionPublic;

    [SerializeField] Image m_backGroundColor;

    private void Start()
    {
        // on définit ici les couleurs pour ne pas avoir a le faire à chaques appels
        m_name.color = GameManager.Instance.MainInstitutionScript.InstitutionColor;
        m_backGroundColor.color = GameManager.Instance.MainInstitutionScript.InstitutionColor;
    }

    public void Display()
    {
        InstitutionSO culte = GameManager.Instance.MainInstitution;

        m_name.text = "" + culte.m_name;
        m_fonds.text = "Fonds : " + culte.Funds.Value;
        m_membres.text = "Membres : " + culte.Members.Value;
        m_fanatiques.text = "Culte : " + culte.Fanatics.Value;
        m_expositionPublic.text = "Exposition public : " + culte.PublicExposure.Value;

        
    }
}
