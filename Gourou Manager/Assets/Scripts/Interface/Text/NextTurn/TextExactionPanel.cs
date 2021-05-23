using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextExactionPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_objectExactionList;
    private List<TMP_Text[]> m_textExactionList = new List<TMP_Text[]>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject thisObject in m_objectExactionList)
        {
            m_textExactionList.Add(thisObject.GetComponentsInChildren<TMP_Text>());
        }
    }

    public void Display(List<ExactionSO> p_exactionList)
    {
        DisallowAll();

        Debug.Log(m_textExactionList[0]);

        // Affichage des Exactions
        for (int i = 0; i < p_exactionList.Count; i++)
        {
            m_objectExactionList[i].SetActive(true);
            m_textExactionList[i][0].text = "" + p_exactionList[i].Name;
            m_textExactionList[i][1].text = "" + p_exactionList[i].Description;
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
