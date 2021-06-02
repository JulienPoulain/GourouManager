using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DecayLvlMethods;

public class TextEndTurn : MonoBehaviour
{

    // [SerializeField] private GameObject m_textPrefab;
    [SerializeField] private List<GameObject> m_objectEtatInstitutionList;
    private List<TMP_Text> m_textEtatList = new List<TMP_Text>();
    
    [SerializeField] GameObject m_objectMainInstitutionName;
    private TMP_Text m_TextmainInstitutionName;
    
    [SerializeField] private List<GameObject> m_objectCultStatList;
    [SerializeField] private List<TMP_Text> m_textCultStatList = new List<TMP_Text>();
    private List<Image> m_imageStatList = new List<Image>();

    [SerializeField] TextExactionPanel m_exactionScript;

    [SerializeField] List<Image> m_BackGroundColor = new List<Image>();


    // Start is called before the first frame update
    void Awake()
    {
        // 1 object est constituer d'un ob text et un ob image qu'on va utiliser plus tard
        foreach (GameObject thisObject in m_objectEtatInstitutionList)
        {
            m_textEtatList.Add(thisObject.GetComponentInChildren<TMP_Text>());
            m_imageStatList.Add(thisObject.GetComponentInChildren<Image>());
        }
        
        foreach (GameObject thisObject in m_objectCultStatList)
        {
            m_textCultStatList.Add(thisObject.GetComponent<TMP_Text>());
        }

        m_TextmainInstitutionName = m_objectMainInstitutionName.GetComponent<TMP_Text>();

        // On met la couleur du Culthe (qu'on cherche depuis le GameManager)
        foreach (Image backgroundImage in m_BackGroundColor)
        {
            backgroundImage.color = GameManager.Instance.MainInstitutionScript.InstitutionColor;
        }
        // m_TextmainInstitutionName.color = GameManager.Instance.MainInstitutionScript.InstitutionColor;
    }

    public void Display()
    {
        DisallowAll();

        // On affiche les Text dont on a besoin
        for (int i = 0; i < GameManager.Instance.Institutions.Count; i++)
        {
            m_objectEtatInstitutionList[i].SetActive(true);
            m_textEtatList[i].text = "" + GameManager.Instance.Institutions[i].Decay.GetDecayLvl().GetString();
            m_imageStatList[i].sprite = GameManager.Instance.Institutions[i].Pictogram;
        }
        
        // Affichage du Culthe
        m_TextmainInstitutionName.text = "" + GameManager.Instance.MainInstitution.m_name;

        m_textCultStatList[0].text = "" + GameManager.Instance.MainInstitution.Funds.Value.ToString();
        m_textCultStatList[1].text = "" + GameManager.Instance.MainInstitution.Members.Value.ToString();
        m_textCultStatList[2].text = "" + GameManager.Instance.MainInstitution.Fanatics.Value.ToString();
        m_textCultStatList[3].text = "" + GameManager.Instance.MainInstitution.PublicExposure.Value.ToString();

        // on récupère la liste d'event du tour qui vient de finir
        List<EventSO> m_eventList = EventRegister.Instance.GetEvents(GameManager.Instance.Turn);

        m_exactionScript.Display(m_eventList);
    }

    public void Disallow()
    {
        GameManager.Instance.m_interfaceManager.DisallowEndTurn();
        m_exactionScript.DestroyAll();
    }

    void DisallowAll()
    {
        foreach (GameObject thisObject in m_objectEtatInstitutionList)
        {
            thisObject.SetActive(false);
        }
    }
}
