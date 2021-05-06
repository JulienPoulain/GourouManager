using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

using TMPro;
using UnityEditorInternal;
using Vector2 = UnityEngine.Vector2;

// local = text in front of the camera
// global = text in map

public class InterfaceManager : MonoBehaviour
{

    

    // Canvas Institution Local
    /*
    [SerializeField] TMP_Text m_textInstitutionNom;
    [SerializeField] TMP_Text m_textInstitutionFonts;
    [SerializeField] TMP_Text m_textInstitutionMembre;
    [SerializeField] TMP_Text m_textInstitutionFanatique;
    [SerializeField] TMP_Text m_textInstitutionExpositionPublic;
    [SerializeField] TMP_Text m_textInstitutionCorruption;
    */
    // text
    [Tooltip("Institution Texte en Standard mode")]
    [SerializeField] GameObject m_InstitutionLightText;
    
    [Tooltip("Institution Texte en FocusOnInstitution mode")]
    [SerializeField] GameObject m_InstitutionHeavyText;
    
    [Tooltip("Crises Texte")]
    [SerializeField] GameObject m_CrisisText;   // texte local

    [Tooltip("définit la distance de  l'interface Institution par rapport au GO pointé")]
    [SerializeField] float m_distanceRight = 5f;
    
    private Camera m_Camera;
    
    
    
    public InterfaceMode m_InterfaceMode = InterfaceMode.Standard;
   
    [Tooltip("définit si l'interface affiche actuellement une information, permet d'éviter de rappeler la fonction d'affichage")]
    public bool m_interfaceIsDisplay;

    void Start()
    {
        m_Camera = GameManager.Instance.u_Camera.GetComponent<Camera>();
    }

    /// <summary>
    /// Envoi les données au bon Text
    /// </summary>
    /// <param name="Institution Display"></param>
    public void DisplayInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        m_interfaceIsDisplay = true;
        // redirection du flux selon si la camera tourne autour de la carte
        switch (m_InterfaceMode)
        {
            case InterfaceMode.Standard:
                DisplayLightInstitution(p_Institution, p_InstitutionScriptable);
                break;
            
            case InterfaceMode.FocusOnInstitution:
                DisplayHeavyInstitution(p_InstitutionScriptable);
                break;
        }
    }

    void DisplayHeavyInstitution(InstitutionSO p_Institution)
    {
        // ALL INFORMATION
        m_InstitutionHeavyText.SetActive(true);
    }

    void DisplayLightInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        // Placement du texte
        m_InstitutionLightText.SetActive(true);
        
        // Définit la position de l'affichage par rapport au G.O.
        Vector3 position = m_Camera.WorldToScreenPoint(p_Institution.transform.position + Vector3.right * m_distanceRight);
        m_InstitutionLightText.transform.position = position;
        
        // envoi des Informations à l'interface pour l'afficher
        m_InstitutionLightText.GetComponent<TextInstitutionLight>().Display(p_InstitutionScriptable);
    }


    public void DisplayCrisis(StructEventCrisesSO p_Crisis)
    {
        m_CrisisText.SetActive(true);

        TextMesh[] textList = m_CrisisText.GetComponentsInChildren<TextMesh>();

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
        m_CrisisText.SetActive(false);
        m_InstitutionLightText.SetActive(false);
        m_InstitutionHeavyText.SetActive(false);
        
        m_interfaceIsDisplay = false;
    }
}