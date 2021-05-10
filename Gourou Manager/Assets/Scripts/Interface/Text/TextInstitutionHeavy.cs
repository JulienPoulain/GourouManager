using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInstitutionHeavy : MonoBehaviour
{
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_textFonds;
    [SerializeField] TMP_Text m_textMembres;
    [SerializeField] TMP_Text m_textFanatiques;
    [SerializeField] TMP_Text m_textEtat;
    [SerializeField] TMP_Text m_textExpositionPublique;
    [SerializeField] TMP_Text m_textGouvernement;
    [SerializeField] TMP_Text m_textCulte;

    private InstitutionSO m_InstitutionData;


    public void Display(InstitutionSO p_data)
    {
        m_InstitutionData = p_data;

        m_textNom.text = "Nom : " + p_data.m_name;
        m_textFonds.text = "Fonds : " + p_data.m_funds.m_value;
        m_textMembres.text = "Membres : " + p_data.m_members.m_value;
        m_textFanatiques.text = "Fanatiques : " + p_data.m_fanatics.m_value;
        m_textEtat.text = "Etat : " + p_data.m_option.ToString();
        m_textExpositionPublique.text = "Exposition publique : " + p_data.m_publicExposure.m_value;
        m_textGouvernement.text = "Pour Gouvernements :";
        m_textCulte.text = "Pour Culte :";
    }

    public void DisplayInterlocutor()
    {
        GameManager.Instance.u_InterfaceManager.DisplayInterlocutor(m_InstitutionData);
    }
}