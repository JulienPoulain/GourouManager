using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSoundVolume : MonoBehaviour
{
    [SerializeField] public GameObject m_soundWindow;
    
    void Start()
    {
        m_soundWindow.SetActive(false);
    }
    
    public void OpenWindow()
    {
        if (m_soundWindow.activeSelf)
        {
            m_soundWindow.SetActive(false);
        }
        else
        {
            m_soundWindow.SetActive(true);
        }
    }
    
}
