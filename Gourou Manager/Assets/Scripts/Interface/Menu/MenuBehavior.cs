using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    [SerializeField] [Tooltip("Besoin de tous les GO associers au Menu pour les faire disparêtre / apparaître")] List<GameObject> m_menuObject;

    [SerializeField] bool m_gameHasCredit;
    [SerializeField] GameObject m_creditOption;

    private GraduateDisplayBehavior m_menuGraduateDisplayBehavior;
    private GraduateDisplayBehavior m_creditGraduateDisplayBehavior;

    private void Start()
    {
        m_menuGraduateDisplayBehavior = GetComponent<GraduateDisplayBehavior>();
        m_creditGraduateDisplayBehavior = m_creditOption.GetComponent<GraduateDisplayBehavior>();
    }

    public void StartGame()
    {
        if(m_menuGraduateDisplayBehavior.CoroutineHasFinish)
        {
            SceneManager.LoadScene("MAP_MAIN", LoadSceneMode.Single);
        }
        
    }
    public void StartCredit()
    {
        if (m_menuGraduateDisplayBehavior.CoroutineHasFinish)
        {
            DisallowMenuElements();
            m_creditOption.SetActive(true);
        }
            
    }

    public void ExitGame()
    {
        if (m_menuGraduateDisplayBehavior.CoroutineHasFinish)
        {
            Application.Quit();
        }
    }

    public void ExitCredit()
    {
        if (m_creditGraduateDisplayBehavior.CoroutineHasFinish)
        {
            m_creditOption.SetActive(false);
            DisplayMenuElement();
        }
        // m_menuGraduateDisplayBehavior.Display();
    }

    public void DisplayMenuElement()
    {
        foreach (GameObject objectSelected in m_menuObject)
        {
            objectSelected.SetActive(true);
        }
    }

    public void DisallowMenuElements()
    {
        foreach(GameObject objectSelected in m_menuObject)
        {
            objectSelected.SetActive(false);
        }
    }
}
