using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonFeedBack : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
{
    Image m_thisImage;
    [SerializeField] TMP_Text m_buttonText;

    void Awake()
    {
        m_thisImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.m_interfaceManager.m_imageBehavior.ReverseBackGroundImage(m_thisImage);
        m_buttonText.color = Color.black;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Permet de remettre l'ancienne image une fois cliquer dessus
        SoundManager.Instance.ClickEffect();
        GameManager.Instance.m_interfaceManager.m_imageBehavior.ReplaceBackGroundImage(m_thisImage);
        m_buttonText.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.m_interfaceManager.m_imageBehavior.ReplaceBackGroundImage(m_thisImage);
        
        // Ici on met blanc, parce que tous les textes des bouttons sont en blanc, cela évite certains bug de couleur
        m_buttonText.color = Color.white;
    }
}
