using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DecayLvlMethods;

public class TextEndTurn : MonoBehaviour
{

    // [SerializeField] private GameObject m_textPrefab;
    // Partie Institutions

    [SerializeField] [Tooltip("List des images Institution (a mettre par ordre)")] private List<Image> m_imageInstitutionList = new List<Image>();     // Liste des picto d'institutions
    [SerializeField] [Tooltip("List des text Stat (a mettre par ordre)")] private List<TMP_Text> m_textStatList = new List<TMP_Text>();            // liste des picto d'etats d'institutions

    [SerializeField] GameObject m_objectMainInstitutionName;
    private TMP_Text m_TextmainInstitutionName;
    
    // Partie Culte
    [SerializeField] private List<GameObject> m_objectCultStatList;
    [SerializeField] private List<TMP_Text> m_textCultStatList = new List<TMP_Text>();

    [SerializeField] TextExactionPanel m_exactionScript;

    [SerializeField] List<Image> m_BackGroundColor = new List<Image>();


    // Start is called before the first frame update
    void Awake()
    {        
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
        // On affiche les Text dont on a besoin
        // Etatant long à être créer, le nombre d'institutions est prédéfini
        for (int i = 0; i < GameManager.Instance.Institutions.Count; i++)
        {
            m_imageInstitutionList[i].sprite = GameManager.Instance.Institutions[i].Pictogram;
            m_textStatList[i].text = GameManager.Instance.Institutions[i].Decay.GetDecayLvl().ToString();
        }
        
        // Affichage du Culthe
        m_TextmainInstitutionName.text = "" + GameManager.Instance.MainInstitution.m_name;

        m_textCultStatList[0].text = "" + GameManager.Instance.MainInstitution.Funds.Value.ToString("N1");
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
}
