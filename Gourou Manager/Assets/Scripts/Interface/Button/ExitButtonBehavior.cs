using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] Sprite m_exitNormalSprite;
    [SerializeField] Sprite m_exitSelectedSprite;

    [SerializeField] Color m_normalColor;
    [SerializeField] Color m_normalSelectedColor;

    [SerializeField] Image m_spriteButonContainer;
    [SerializeField] Image m_colorButonContainer;

    private void Start() 
    {
        m_spriteButonContainer.sprite = m_exitNormalSprite;
        m_colorButonContainer.color = m_normalColor;
    }


    // Le curseur entre dedans
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_spriteButonContainer.sprite = m_exitSelectedSprite;
        m_colorButonContainer.color = m_normalSelectedColor;
    }

    // On clique dessus
    public void OnPointerDown(PointerEventData eventData)
    {
        m_spriteButonContainer.sprite = m_exitNormalSprite;
        m_colorButonContainer.color = m_normalColor;
    }

    // Le curseur quitte
    public void OnPointerExit(PointerEventData eventData)
    {
        m_spriteButonContainer.sprite = m_exitNormalSprite;
        m_colorButonContainer.color = m_normalColor;
    }
}
