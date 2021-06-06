using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ETPALogoScript : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] Sprite m_logoSprite;
    [SerializeField] Sprite m_logoReverseSprite;

    Image m_thisImage;

    void Start()
    {
        m_thisImage = GetComponent<Image>();
        m_thisImage.sprite = m_logoSprite;
    }

    // Le curseur entre dedans
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_thisImage.sprite = m_logoReverseSprite;
    }

    // On clique dessus
    public void OnPointerDown(PointerEventData eventData)
    {
        SoundManager.Instance.ClickEffect();
        Application.OpenURL("https://www.etpa.com/game-design");
        m_thisImage.sprite = m_logoSprite;
    }

    // Le curseur quitte
    public void OnPointerExit(PointerEventData eventData)
    {
        m_thisImage.sprite = m_logoSprite;
    }
}
