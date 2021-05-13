using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExactionMain : MonoBehaviour
{
    [SerializeField] List<GameObject> m_ExactionOb = new List<GameObject>();

    List<TextExactionIndividual> m_ExactionText = new List<TextExactionIndividual>();

    private void Start()
    {
        foreach (GameObject ExactionContainer in m_ExactionOb)
        {
            m_ExactionText.Add(ExactionContainer.GetComponent<TextExactionIndividual>());
        }
    }

    public void Display(InstitutionSO p_institution)
    {
        // on commence par les desafficher, puis on les affiche selon notre besoin
        DisallowAll();
        DisplayNecessary(p_institution);

        for (int i = 0; i < p_institution.m_exactionList.Count; i++)
        {
            m_ExactionText[i].Display(p_institution.m_exactionList[i]);
        }
    }

    // ATTENTION le nombre d'exactions ne doivent pas être superieur au nb de text (3)
    void DisplayNecessary(InstitutionSO p_institution)
    {
        for (int i = 0; i < p_institution.m_exactionList.Count; i++)
        {
            m_ExactionOb[i].SetActive(true);
        }
    }

    void DisallowAll()
    {
        foreach (GameObject ExactionContainer in m_ExactionOb)
        {
            ExactionContainer.SetActive(false);
        }
    }
}
