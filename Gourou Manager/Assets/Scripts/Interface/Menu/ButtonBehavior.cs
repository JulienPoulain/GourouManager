using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] private float m_scaleDuration = 1f;
    private Image m_image;
    
    void Start()
    {
        m_image = GetComponent<Image>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        m_image.sprite = MenuManager.Instance.RedSprite;
        StartCoroutine(ScaleChange());
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        m_image.sprite = MenuManager.Instance.WhiteSprite;
        StartCoroutine(ReverseScaleChange());
    }

    IEnumerator ScaleChange()
    {
        float time = 0;
        while (time < m_scaleDuration)
        {
            transform.localScale += Vector3.one * Mathf.Sin(4f) * Time.deltaTime;
            yield return null;
            time += Time.deltaTime;
        }
    }
    
    IEnumerator ReverseScaleChange()
    {
        float time = 0;
        while (time < m_scaleDuration)
        {
            transform.localScale -= Vector3.one * Mathf.Sin(2f) * Time.deltaTime;
            yield return null;
            time += Time.deltaTime;
        }
    }
}
