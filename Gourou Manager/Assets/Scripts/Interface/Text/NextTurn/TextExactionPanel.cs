using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextExactionPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_objectExactionList;
    private List<TMP_Text[]> m_textExactionList = new List<TMP_Text[]>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject thisObject in m_objectExactionList)
        {
            m_textExactionList.Add(thisObject.GetComponentsInChildren<TMP_Text>());
        }
    }

    public void Display(List<EventSO> p_eventList)
    {
        DisallowAll();

        Debug.Log("DEBUT DES EVENT");

        // Affichage des Exactions
        for (int i = 0; i < p_eventList.Count; i++)
        {
            m_objectExactionList[i].SetActive(true);
            m_textExactionList[i][0].text = "" + p_eventList[i].Name;
            m_textExactionList[i][1].text = "" + p_eventList[i].Description;

            Debug.Log("" + p_eventList[i].Name);
            Debug.Log("" + p_eventList[i].Description);
        }
    }

    public void DisallowAll()
    {
        foreach (GameObject thisObject in m_objectExactionList)
        {
            thisObject.SetActive(false);
        }
    }
}