using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI m_infoText;
    [SerializeField] public GameObject m_window;
    private List<InfoSO> m_infoList = new List<InfoSO>();

    // Start is called before the first frame update
    void Start()
    {
        m_window.SetActive(false);
        m_infoList = GetInfoSO();
    }

    List<InfoSO> GetInfoSO()
    {
        List<InfoSO> infoInScene = new List<InfoSO>();

        foreach (InfoSO info in Resources.FindObjectsOfTypeAll(typeof(InfoSO)) as InfoSO[])
        {
            infoInScene.Add(info);
        }

        return infoInScene;
    }

    public void OpenWindow()
    {
        if (m_window.activeSelf)
        {
            m_window.SetActive(false);
        }
        else
        {
            if (m_infoList.Count <= 0)
            {
                m_infoText.text = "Pas d'information disponible";
                Debug.Log("pas d'info");
            }
            else
            {
                m_infoText.text = null;
                foreach (InfoSO info in m_infoList)
                {
                    if (info.Value)
                    {
                        m_infoText.text += $"<b>{info.Title}</b>" + "\n" + info.Description + "\n\n";
                        Debug.Log("info");
                    }
                }
            }
        
            m_window.SetActive(true);
        }
    }
}
