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
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

// local = text in front of the camera
// global = text in map

public class InterfaceManager : MonoBehaviour
{
    // text
    [Tooltip("Institution Texte en Standard mode")]
    [SerializeField] GameObject m_InstitutionLightObject;
    
    [Tooltip("Institution Texte en FocusOnInstitution mode")]
    [SerializeField] GameObject m_InstitutionHeavyObject;

    [SerializeField] GameObject m_InterlocutorObject;

    TextInstitutionLight m_InstitutionLightScript;
    TextInstitutionHeavy m_InstitutionHeavyScript;
    TextCrisis m_CrisisScript;
    TextInterlocutor m_InterlocutorScript;


    [Tooltip("Crises Texte")]
    [SerializeField] GameObject m_CrisisObject;   // texte local

    [Tooltip("définit la distance de  l'interface Institution par rapport au GO pointé")]
    [SerializeField] float m_decallingLightInstitution = 5f;
    
    [SerializeField] GameObject m_ButtonInterlocutorPrefab;
    private List<GameObject> m_ButtonInterlocutorList;

    private Camera m_Camera;

    private RectTransform m_canvasSize;
    
    
    
    public InterfaceMode m_InterfaceMode = InterfaceMode.Standard;
   
    [Tooltip("définit si l'interface affiche actuellement une information, permet d'éviter de rappeler la fonction d'affichage")]
    public bool m_InstitutionLightIsDisplay = false;
    public bool m_InstitutionHeavyIsDisplay = false;
    public bool m_crisisIsDisplay = false;
    public bool m_InterlocutorIsDisplay = false;

    void Start()
    {
        m_Camera = GameManager.Instance.u_Camera.GetComponent<Camera>();
        m_canvasSize = GetComponent<RectTransform>();

        m_InstitutionLightScript = m_InstitutionLightObject.GetComponent<TextInstitutionLight>();
        m_InstitutionHeavyScript = m_InstitutionHeavyObject.GetComponent<TextInstitutionHeavy>();
        m_CrisisScript = m_CrisisObject.GetComponent<TextCrisis>();
        m_InterlocutorScript = m_InterlocutorObject.GetComponent<TextInterlocutor>();
    }

    /// <summary>
    /// Envoi les données au bon Text
    /// </summary>
    /// <param name="Institution Display"></param>

    public void DisplayHeavyInstitution(InstitutionSO p_Institution)
    {
        // ALL INFORMATION
        m_InstitutionHeavyIsDisplay = true;
        m_InstitutionHeavyObject.SetActive(true);

        // envoie les informations pour les afficher
        m_InstitutionHeavyScript.Display(p_Institution);
    }

    public void DisplayLightInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        m_InstitutionLightIsDisplay = true;

        // Placement du texte
        m_InstitutionLightObject.SetActive(true);

        // Définit la position de l'affichage par rapport au G.O.
        Vector3 position = CalculateWindowDimention(m_Camera.WorldToScreenPoint(p_Institution.transform.position));

        m_InstitutionLightObject.transform.position = position;

        // envoie les informations pour les afficher
        m_InstitutionLightScript.Display(p_InstitutionScriptable);        
    }
    
    // sert à DisplayLightInstitution
    private Vector3 CalculateWindowDimention(Vector3 p_focusPoint)
    {
        // on vérifie si la pos du GO est en haut / en bas / a droite ou a gauche par rapport au canvas
        // si la pos est en haut, l'image sera affichée en bas
        Vector3 position = Vector3.zero;

        // HAUT BAS
        if(p_focusPoint.y > m_canvasSize.rect.height / 2)
        {
            position.y = p_focusPoint.y - m_decallingLightInstitution;
        }
        else
        {
            position.y = p_focusPoint.y + m_decallingLightInstitution;
        }
        // DROITE GAUCHE
        if (p_focusPoint.x > m_canvasSize.rect.width/2)
        {
            position.x = p_focusPoint.x - m_decallingLightInstitution;
        }
        else
        {
            position.x = p_focusPoint.x + m_decallingLightInstitution;
        }
        return position;
    }

    
    // Fonction affiche / desaffiche
    public void DisplayCrisis(StructEventCrisesSO p_Crisis)
    {
        m_crisisIsDisplay = true;
        m_CrisisObject.SetActive(true);
        m_CrisisScript.Display(p_Crisis);
    }

    public void DisallowLightInstitution() // call in Cursor.cs
    {
        m_InstitutionLightObject.SetActive(false);
        m_InstitutionLightIsDisplay = false;
    }

    public void DisallowHeavyInstitution()
    {
        m_InstitutionHeavyObject.SetActive(false);
        m_InstitutionHeavyIsDisplay = false;
    }

    public void DisallowCrisis() // call in Cursor.cs
    {
        m_CrisisObject.SetActive(false);
        m_crisisIsDisplay = false;
    }

    public void DisallowInterlocutor()
    {
        if(m_ButtonInterlocutorList != null) m_ButtonInterlocutorList.Clear();
        
        m_InterlocutorObject.SetActive(false);
        m_InterlocutorIsDisplay = false;
    }


    public void DisplayInterlocutor(InstitutionSO p_data)
    {
        Debug.Log("JE TINVOQUE");
        m_InterlocutorObject.SetActive(true);
        
        RectTransform buttonDim = m_ButtonInterlocutorPrefab.GetComponent<RectTransform>();
        float buttonWidth = buttonDim.rect.width;
        
        Vector3 firstPos = firstButtonPos(p_data, buttonWidth);
        
        for (int i = 0; i < p_data.m_interlocutorList.Count; i++)
        {
            // on créer + placer le boutton
            GameObject Button = Instantiate(m_ButtonInterlocutorPrefab, firstPos, Quaternion.identity);
            firstPos.x += buttonWidth;
            // on configure le texte pour y afficher le nom de l'interlocuteur
            Button.GetComponentInChildren<TextMeshPro>().text = "" + p_data.m_interlocutorList[i].m_name;
            
            // on configure le boutton pour qu'il ai les informations de l'interlocuteur
            Button.gameObject.GetComponent<InterlocutorButton>().Configuration(p_data.m_interlocutorList[i]);

            Button.transform.parent = m_ButtonInterlocutorPrefab.transform;
            
            m_ButtonInterlocutorList.Add(Button);
        }
    }

    Vector3 firstButtonPos(InstitutionSO p_data, float p_buttonWidth)
    {
        // largeur canvas / 2 - (nbButton * dimButton)/2
        float startX = m_canvasSize.rect.width / 2 - (p_data.m_interlocutorList.Count * p_buttonWidth) / 2;
        float startY = m_canvasSize.rect.height / 10;

        return new Vector3(startX, startY, 0);
    }
}