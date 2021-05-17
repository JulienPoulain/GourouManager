using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TextInstitutionHeavy : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // Text
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_textFonds;
    [SerializeField] TMP_Text m_textMembres;
    [SerializeField] TMP_Text m_textFanatiques;
    [SerializeField] TMP_Text m_textEtat;
    [SerializeField] TMP_Text m_textExpositionPublique;

    [SerializeField] GameObject m_InterlocutorButton;

    private InstitutionSO m_InstitutionData;

    // EXACTIONS
    // stoque les GO exaction (contenant 1 bouton + un texte)
    [SerializeField] List<GameObject> m_ExactionsObject = new List<GameObject>();
    List<TextInstitutionExactionManager> m_exactionInterfaceScript = new List<TextInstitutionExactionManager>();

    RectTransform m_ThisRectangle;

    private void Start()
    {
        foreach (GameObject ExactionObject in m_ExactionsObject)
        {
            m_exactionInterfaceScript.Add(ExactionObject.GetComponent<TextInstitutionExactionManager>());
        }

        m_ThisRectangle = GetComponent<RectTransform>();
    }

    public void Display(InstitutionSO p_data)
    {
        if (p_data.m_interlocutorList.Count == 0)
        {
            m_InterlocutorButton.SetActive(false);
        }
        else
        {
            m_InterlocutorButton.SetActive(true);
        }

        m_InstitutionData = p_data;

        m_textNom.text = "" + p_data.m_name;
        m_textFonds.text = "Fonds : " + p_data.m_funds.m_value;
        m_textMembres.text = "Membres : " + p_data.m_members.m_value;
        m_textFanatiques.text = "Fanatiques : " + p_data.m_fanatics.m_value;
        m_textEtat.text = "Etat : " + p_data.m_option.ToString();
        m_textExpositionPublique.text = "Exposition publique : " + p_data.m_publicExposure.m_value;

        /*
        m_textGouvernement.text = "Pour Gouvernements :";
        m_textCulte.text = "Pour Culte :";
        */

        DisplayExaction();
    }



    public void DisplayInterlocutor()
    {
        GameManager.Instance.m_InterfaceManager.DisplayInterlocutor(m_InstitutionData);
    }

    public void DisplayExaction()
    {
        // On désaffiche les exactions pour les afficher comme on veut
        DisallowExaction();

        // On affiche les exactions selon notre besoin & on les paramètre        
        for (int i = 0; i < m_InstitutionData.m_exactionList.Count; i++)
        {
            m_ExactionsObject[i].SetActive(true);
            m_exactionInterfaceScript[i].Display(m_InstitutionData.m_exactionList[i]);
        }
    }

    public void DisallowExaction()
    {
        foreach (GameObject exaction in m_ExactionsObject)
        {
            exaction.SetActive(false);
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.m_InterfaceManager.m_cursorFocusHeavyInstitution = true;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("MousePressed");
        MoveWindow();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.m_InterfaceManager.m_cursorFocusHeavyInstitution = false;
    }

    Vector3 oldMousePos;

    void MoveWindow()
    {
        if (oldMousePos != Input.mousePosition)
        {
            // Vector3 vector = (Input.mousePosition - oldMousePos).normalized;

            // transform.position += vector * 1.5f;

            // m_ThisRectangle.pivot = new Vector2(Input.mousePosition.x, Input.mousePosition.y); 

            transform.position = Input.mousePosition;

           oldMousePos = Input.mousePosition;
        }
    }

    IEnumerator MousePressed()
    {
        while (Input.GetMouseButton(0))
        {
            MoveWindow();
            yield return new WaitForSeconds(0.000001f);
        }
    }
}