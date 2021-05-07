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
    public bool m_InstitutionLightIsDisplay = false;
    public bool m_InstitutionHeavyIsDisplay = false;
    public bool m_crisisIsDisplay = false;

    void Start()
    {
        m_Camera = GameManager.Instance.u_Camera.GetComponent<Camera>();
    }

    /// <summary>
    /// Envoi les données au bon Text
    /// </summary>
    /// <param name="Institution Display"></param>

    public void DisplayHeavyInstitution(InstitutionSO p_Institution)
    {
        // ALL INFORMATION
        m_InstitutionHeavyIsDisplay = true;
        m_InstitutionHeavyText.SetActive(true);
    }

    public void DisplayLightInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        m_InstitutionLightIsDisplay = true;

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
        m_crisisIsDisplay = true;
        m_CrisisText.SetActive(true);
        m_CrisisText.GetComponent<TextCrisis>().Display(p_Crisis);
    }

    public void DisallowLightInstitution() // call in Cursor.cs
    {
        m_InstitutionLightText.SetActive(false);
        m_InstitutionLightIsDisplay = false;
    }

    public void DisallowHeavyInstitution()
    {
        m_InstitutionHeavyText.SetActive(false);
        m_InstitutionHeavyIsDisplay = false;
    }

    public void DisallowCrisis() // call in Cursor.cs
    {
        m_CrisisText.SetActive(false);
        m_crisisIsDisplay = false;
    }
}