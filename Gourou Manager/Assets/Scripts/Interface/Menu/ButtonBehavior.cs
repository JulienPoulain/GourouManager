using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    // en static parce qu'il s'agit une valeur qui sera commun à tout le monde
    [SerializeField] private float m_scaleDuration;
    [SerializeField] private string m_SceneName;

    [SerializeField] [Tooltip("True = bouton qui inverse ses couleurs lorsqu'on passe la souris dessus")] bool m_buttonChangeColor = false;
    [SerializeField] Sprite m_normalSprite;
    [SerializeField] Sprite m_reverseSprite;

    private Image m_image;
    
    void Start()
    {
        m_image = GetComponent<Image>();

        if (m_buttonChangeColor)
        {
            m_image.sprite = m_normalSprite;
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(m_SceneName, LoadSceneMode.Single);
        Debug.Log("je clicke dessus");

        if (m_buttonChangeColor)
        {
            m_image.sprite = m_normalSprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_buttonChangeColor)
        {
            m_image.sprite = m_reverseSprite;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (m_buttonChangeColor)
        {
            m_image.sprite = m_normalSprite;
        }
    }

}
