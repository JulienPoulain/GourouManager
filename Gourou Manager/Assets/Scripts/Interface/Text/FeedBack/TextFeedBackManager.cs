using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFeedBackManager : MonoBehaviour
{

    RectTransform m_canvasSize;
    RectTransform m_textSize;

    Vector3 m_textPosition;

    [SerializeField] GameObject m_textPrefab;
    [SerializeField] float m_textcooldown;
    
    void Awake()
    {
        m_canvasSize = GetComponent<RectTransform>();
        m_textSize = m_textPrefab.GetComponent<RectTransform>();

        float posX = m_textSize.rect.width / 2;
        float posY = m_canvasSize.rect.height - m_textSize.rect.height;

        m_textPosition = new Vector3(posX, posY, 0);
    }
    
    // Feed Back Exactions
    public void FeedBackExaction()
    {
        DisplayText("Exaction faite");
    }

    public void FeedBackExactionDouble()
    {
        DisplayText("Exaction déjà faite!");
    }
    
    public void FeedBackExactionNotValid()
    {
        DisplayText("Exaction non valide!");
    }
    
    // Feed Back Approach
    public void FeedBackApproach()
    {
        DisplayText("Approche faite");
    }
    
    public void FeedBackApproachDouble()
    {
        DisplayText("Approche déjà tentée ce tour!");
    }
    
    public void FeedBackApproachNotValid()
    {
        DisplayText("Approche non valide!");
    }
    
    // Display Function
    void DisplayText(string p_message)
    {
        GameObject text = Instantiate(m_textPrefab, m_textPosition, Quaternion.identity, GameManager.Instance.m_InterfaceManager.gameObject.transform);
        TMP_Text textContain = text.GetComponent<TMP_Text>();
        textContain.text = p_message;

        StartCoroutine(CleanText(text, textContain));
    }
    
    // Coroutine TextManagment
    IEnumerator CleanText(GameObject p_textContainer, TMP_Text p_text)
    {
        float counter = 0;
        Image textImage = p_textContainer.GetComponent<Image>();

        while (counter <= m_textcooldown)
        {
            counter += Time.deltaTime;
            yield return null;
            
            p_text.alpha -= Time.deltaTime;
            p_textContainer.transform.position += new Vector3(0, 0.01f, 0);
        }

        Destroy (p_textContainer);
    }

}
