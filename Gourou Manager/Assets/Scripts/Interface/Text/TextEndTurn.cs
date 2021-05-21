using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEndTurn : MonoBehaviour
{

    // [SerializeField] private GameObject m_textPrefab;
    [SerializeField] private List<GameObject> m_objectEtatList;
    private List<TMP_Text> m_textEtatList = new List<TMP_Text>();
    
    [SerializeField] private List<GameObject> m_objectStatList;
    private List<TMP_Text> m_textStatList = new List<TMP_Text>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject thisObject in m_objectEtatList)
        {
            m_textEtatList.Add(thisObject.GetComponent<TMP_Text>());
        }
        
        foreach (GameObject thisObject in m_objectStatList)
        {
            m_textStatList.Add(thisObject.GetComponent<TMP_Text>());
        }

        Display();
    }

    void Display()
    {
        DisallowAll();
        
        // On affiche les Text dont on a besoin
        for (int i = 0; i < GameManager.Instance.Institutions.Count; i++)
        {
            m_objectEtatList[i].SetActive(true);
            m_textEtatList[i].text = "" + GameManager.Instance.Institutions[i].m_name + " : " + GameManager.Instance.Institutions[i].m_option.ToString();
        }
        
        m_textStatList[0].text = "Fonds : " + GameManager.Instance.MainInstitution.m_funds.Value.ToString();
        m_textStatList[1].text = "Membres : " + GameManager.Instance.MainInstitution.m_members.Value.ToString();
        m_textStatList[2].text = "Fanatiques : " + GameManager.Instance.MainInstitution.m_fanatics.Value.ToString();
        m_textStatList[3].text = "Exposition Publique : " + GameManager.Instance.MainInstitution.m_publicExposure.Value.ToString();
    }

    void DisallowAll()
    {
        foreach (GameObject thisObject in m_objectEtatList)
        {
            thisObject.SetActive(false);
        }
    }
}
