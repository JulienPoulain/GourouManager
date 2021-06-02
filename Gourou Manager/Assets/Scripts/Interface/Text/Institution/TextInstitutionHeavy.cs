using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DecayLvlMethods;

public class TextInstitutionHeavy : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // Text
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_textFonds;
    [SerializeField] TMP_Text m_textExpositionPublique;
    [SerializeField] private Image m_imagePico;

    [SerializeField] GameObject m_InterlocutorButton;

    private InstitutionSO m_institutionData;

    // EXACTIONS
    // stoque les GO exaction (contenant 1 bouton + un texte)
    [SerializeField] List<GameObject> m_ExactionsObject = new List<GameObject>();
    List<TextInstitutionExactionManager> m_exactionInterfaceScript = new List<TextInstitutionExactionManager>();

    RectTransform m_ThisRectangle;

    [SerializeField] List<Image> m_imageList = new List<Image>();
    [SerializeField] List<TMP_Text> m_textList = new List<TMP_Text>();

    [SerializeField] [Tooltip("Liste des images qui prendrons les pictogrammes des institutions")] List<Image> m_PictoList = new List<Image>();

    private void Awake()
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

        m_institutionData = p_data;

        m_textNom.text = "" + p_data.m_name;
        m_textFonds.text = "" + p_data.Funds.Value.ToString("N1");
        m_imagePico.sprite = GameManager.Instance.m_interfaceManager.m_pictoEtatBehavior.DisplayEtat(p_data.Decay.GetDecayLvl());
        m_textExpositionPublique.text = "" + p_data.PublicExposure.Value;

        GameManager.Instance.m_interfaceManager.ChangeColorInstitution(m_imageList, m_textList);

        DisplayExaction();

        foreach(Image pictogram in m_PictoList)
        {
            pictogram.sprite = p_data.Pictogram;
        }
    }

    public void DisplayInterlocutor()
    {
        GameManager.Instance.m_interfaceManager.DisplayInterlocutor();
    }

    public void DisplayExaction()
    {
        // On désaffiche les exactions pour les afficher comme on veut
        DisallowExaction();

        // On affiche les exactions selon notre besoin & on les paramètre        
        for (int i = 0; i < m_institutionData.m_exactionList.Count; i++)
        {
            m_ExactionsObject[i].SetActive(true);
            m_exactionInterfaceScript[i].Display(m_institutionData.m_exactionList[i]);
        }
    }

    public void DisallowExaction()
    {
        foreach (GameObject exaction in m_ExactionsObject)
        {
            exaction.SetActive(false);
        }
    }

    // On vide InstiutionData pour éviter les bugs d'interface
    void OnDisable()
    {
        m_institutionData = null;
    }

    // Interraction
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.m_interfaceManager.m_cursorFocusHeavyInstitution = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(MousePressed());
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.m_interfaceManager.m_cursorFocusHeavyInstitution = false;
    }

    // Mouvement de la fenêtre
    Vector3 m_oldMousePos;

    void MoveWindow()
    {
        if (m_oldMousePos != Input.mousePosition)
        {

            Vector3 mvt = Input.mousePosition - m_oldMousePos;


            // Vector3 vector = (Input.mousePosition - oldMousePos).normalized;

            // transform.position += vector * 1.5f;

            // m_ThisRectangle.pivot = new Vector2(Input.mousePosition.x, Input.mousePosition.y); 

           // Vector3 offset = new Vector3(m_dragOffset.x, m_dragOffset.y, 0);

            transform.position += mvt;

            m_oldMousePos = Input.mousePosition;
        }
    }

    IEnumerator MousePressed()
    {
        m_oldMousePos = Input.mousePosition;
        while (Input.GetMouseButton(0)) {
            MoveWindow();
            yield return null;
        }
    }
}