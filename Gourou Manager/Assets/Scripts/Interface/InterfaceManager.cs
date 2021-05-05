using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

using TMPro;

// local = text in front of the camera
// global = text in map

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject m_InstitutionLocal;  // texte local
    [SerializeField] GameObject m_InstitutionGlobal;    // texte global
    
    [SerializeField] GameObject m_Crisis;   // texte local

    // Canvas Institution Local
    [SerializeField] TMP_Text m_textInstitutionNom;
    [SerializeField] TMP_Text m_textInstitutionFonts;
    [SerializeField] TMP_Text m_textInstitutionMembre;
    [SerializeField] TMP_Text m_textInstitutionFanatique;
    [SerializeField] TMP_Text m_textInstitutionExpositionPublic;
    [SerializeField] TMP_Text m_textInstitutionCorruption;

    // text
    [SerializeField] TextInstitution m_TextInstitution;



    private void Awake()
    {

        // Si le designer a oublier les liens
        if (m_textInstitutionNom == null 
            || m_textInstitutionFonts == null 
            || m_textInstitutionMembre == null 
            || m_textInstitutionFanatique == null 
            || m_textInstitutionExpositionPublic == null 
            || m_textInstitutionCorruption == null )
        {

            Debug.LogWarning("Attention les champs textes ne sont pas configurés, j'assume de l'ordre");
            // Message au designer
            TMP_Text[] textList = m_InstitutionLocal.GetComponentsInChildren<TMP_Text>();
            m_textInstitutionNom = textList[0];
            m_textInstitutionFonts = textList[1];
            m_textInstitutionMembre = textList[2];
            m_textInstitutionFanatique = textList[3];
            m_textInstitutionExpositionPublic = textList[4];
            m_textInstitutionCorruption = textList[5];
        }
    }
    
    public void DisplayInterface()
    {


    }

    /// <summary>
    /// Afficher l'institution : m_Institution -> TextContainer -> List<TextMesh> -> Modifier
    /// </summary>
    /// <param name="Institution Display"></param>
    public void DisplayInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        // redirection du flux selon si la camera tourne autour de la carte
        switch (GameManager.Instance.m_focusOnInstitution)
        {
            case true:
                DisplayLightInstitution(p_Institution, p_InstitutionScriptable);
                break;
            case false:
                DisplayHeavyInstitution(p_InstitutionScriptable);
                break;
        }
    }

    void DisplayHeavyInstitution(InstitutionSO p_Institution)
    {
        // ALL INFORMATION

        m_InstitutionLocal.SetActive(true);
 

        m_textInstitutionNom.text = "Nom: " + p_Institution.m_name;
        m_textInstitutionFonts.text = "Fonts : " + p_Institution.m_funds.m_value; ;
        m_textInstitutionMembre.text = "Membre : " + p_Institution.m_members.m_value; ;
        m_textInstitutionFanatique.text = "Fanatique : " + p_Institution.m_fanatics.m_value;
        m_textInstitutionExpositionPublic.text = "Exposition public : " + p_Institution.m_publicExposure.m_value;
        m_textInstitutionCorruption.text = "Corruption : " + p_Institution.m_corruption.m_value;
    }

    void DisplayLightInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        // Placement du texte
        m_InstitutionGlobal.SetActive(true);
        
        float distance = 3f;
        
        Vector3 position = (GameManager.Instance.u_Camera.transform.up * distance);
        m_InstitutionGlobal.transform.position = p_Institution.gameObject.transform.position + position;

        m_InstitutionGlobal.transform.position = p_Institution.gameObject.transform.position + position;
        TextMesh[] textList = m_InstitutionLocal.GetComponentsInChildren<TextMesh>();
        
        // Changement du text
        textList[0].text = "" + p_InstitutionScriptable.m_name;
    }


    public void DisplayCrisis(StructEventCrisesSO p_Crisis)
    {
        m_Crisis.SetActive(true);

        TextMesh[] textList = m_Crisis.GetComponentsInChildren<TextMesh>();

        textList[0].text = "" ;
        textList[1].text = "Taux de la Crisis : ";
        textList[2].text = "Effect : ";
    }


    public void Display(InterfaceDisplay p_Object) // call in Cursor.cs
    {
        // switch(p_Object.m_type)
        

    }

    public void Disallow() // call in Cursor.cs
    {
        m_Crisis.SetActive(false);
        m_InstitutionLocal.SetActive(false);
        m_InstitutionGlobal.SetActive(false);
    }
}

// poser le texte à droite de l'institution
/*
Vector3 position = (GameManager.Instance.u_Camera.transform.right * distance) ;
m_InstitutionGlobal.transform.position = p_Institution.gameObject.transform.position + position;
m_InstitutionGlobal.transform.LookAt(p_Institution.transform.position, Vector3.left);
*/