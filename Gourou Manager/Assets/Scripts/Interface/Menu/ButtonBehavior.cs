using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
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
        m_image.sprite = MenuManager.Instance.RedSprite;
        MenuManager.Instance.LoadScene(m_SceneName);
        Debug.Log("je clicke dessus");
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        m_image.sprite = MenuManager.Instance.WhiteSprite;
        StartCoroutine(ReverseScaleChange());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ScaleChange());
        Debug.Log("je suis dessus");
    }

    IEnumerator ScaleChange()
    {
        float time = 1f;
        while (time < m_scaleDuration)
        {
            transform.localScale += Vector3.one * Mathf.Log(time) * Time.deltaTime * 3;
            time += Time.deltaTime;
            Debug.Log("JE RENTRE DEDANS" + time);
            yield return null;
        }
    }
    
    IEnumerator ReverseScaleChange()
    {
        float time = 1f;
        while (time < m_scaleDuration)
        {
            time += Time.deltaTime;
            transform.localScale -= Vector3.one * Mathf.Log(time) * Time.deltaTime * 3;
            yield return null;
            Debug.Log("JE SORS DE LA" + time);
        }
    }
}
