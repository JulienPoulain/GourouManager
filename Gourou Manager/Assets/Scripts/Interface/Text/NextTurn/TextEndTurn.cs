using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEndTurn : MonoBehaviour
{

    // [SerializeField] private GameObject m_textPrefab;
    [SerializeField] private List<GameObject> m_objectEtatList;
    private List<TMP_Text> m_textEtatList = new List<TMP_Text>();
    
    [SerializeField] GameObject m_objectMainInstitutionName;
    private TMP_Text m_TextmainInstitutionName;
    
    [SerializeField] private List<GameObject> m_objectStatList;
    private List<TMP_Text> m_textStatList = new List<TMP_Text>();

    [SerializeField] TextExactionPanel m_exactionScript;


    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject thisObject in m_objectEtatList)
        {
            m_textEtatList.Add(thisObject.GetComponent<TMP_Text>());
        }
        
        foreach (GameObject thisObject in m_objectStatList)
        {
            m_textStatList.Add(thisObject.GetComponent<TMP_Text>());
        }

        m_TextmainInstitutionName = m_objectMainInstitutionName.GetComponent<TMP_Text>();
    }

    public void Display()
    {
        DisallowAll();

        // On affiche les Text dont on a besoin
        for (int i = 0; i < GameManager.Instance.Institutions.Count; i++)
        {
            m_objectEtatList[i].SetActive(true);
            m_textEtatList[i].text = "" + GameManager.Instance.Institutions[i].m_name + " : " + GameManager.Instance.Institutions[i].m_option.ToString();
        }
        
        // Affichage du Culthe
        m_TextmainInstitutionName.text = "" + GameManager.Instance.MainInstitution.m_name;

        m_textStatList[0].text = "Fonds : " + GameManager.Instance.MainInstitution.Funds.Value.ToString();
        m_textStatList[1].text = "Membres : " + GameManager.Instance.MainInstitution.Members.Value.ToString();
        m_textStatList[2].text = "Fanatiques : " + GameManager.Instance.MainInstitution.Fanatics.Value.ToString();
        m_textStatList[3].text = "Exposition Publique : " + GameManager.Instance.MainInstitution.PublicExposure.Value.ToString();
        m_textStatList[4].text = "Brutalité : " + GameManager.Instance.MainInstitution.Brutality.Value;

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
        foreach (GameObject thisObject in m_objectEtatList)
        {
            thisObject.SetActive(false);
        }
    }
}
