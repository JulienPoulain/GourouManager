using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonFeedBackIndependent : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite m_normalSprite;
    [SerializeField] Sprite m_reverseSprite;

    private Image m_image;
    void Start()
    {
        m_image = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_image.sprite = m_normalSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_image.sprite = m_reverseSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_image.sprite = m_normalSprite;
    }
}
