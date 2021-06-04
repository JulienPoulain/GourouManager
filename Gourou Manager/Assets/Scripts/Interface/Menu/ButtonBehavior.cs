using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour, IPointerDownHandler
{
    // en static parce qu'il s'agit une valeur qui sera commun à tout le monde
    [SerializeField] private float m_scaleDuration;
    [SerializeField] private string m_SceneName;
    private Image m_image;
    
    void Start()
    {
        m_image = GetComponent<Image>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(m_SceneName, LoadSceneMode.Single);
        Debug.Log("je clicke dessus");
    }
}
