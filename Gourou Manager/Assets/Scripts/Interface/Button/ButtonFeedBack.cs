using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonFeedBack : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    Image m_thisImage;
    [SerializeField] TMP_Text m_buttonText;

    Color m_actualColor;

    void Awake()
    {
        m_thisImage = GetComponent<Image>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.m_interfaceManager.m_imageBehavior.ReplaceBackGroundImage(m_thisImage);
        m_buttonText.color = m_actualColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.m_interfaceManager.m_imageBehavior.ReverseBackGroundImage(m_thisImage);

        m_actualColor = m_buttonText.color;
        m_buttonText.color = Color.black;
    }
}
