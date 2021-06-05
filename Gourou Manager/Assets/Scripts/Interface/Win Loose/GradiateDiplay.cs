using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GradiateDiplay : MonoBehaviour
{
    [SerializeField] List<Image> m_imageList = new List<Image>();
    [SerializeField] List<TMP_Text> m_textList = new List<TMP_Text>();

    List<Color> m_imageColorList = new List<Color>();
    List<Color> m_imageTextList = new List<Color>();

    [SerializeField] [Tooltip("Temps durant lequel l'element va apparaître")] float m_displayDuration;

    // définit la valeur max de l'apha
    // List<float> m_alphaValue;

    private void Start()
    {
        // On commence par mettre toutes les couleurs en opacité 0
        
        foreach(Image buttonImage in m_imageList)
        {
            // on met l'opactité de l'image a 0 avant de la mettre dans une liste
            Color thisImageColor = buttonImage.color;

            //m_alphaValue.Add(thisImageColor.a / 255);
            //Debug.Log(thisImageColor.a / 255);

            thisImageColor.a = 0;
            buttonImage.color = thisImageColor;

            m_imageColorList.Add(buttonImage.color);
        }

        foreach (TMP_Text buttonText in m_textList)
        {
            // on met l'opactité de l'image a 0 avant de la mettre dans une liste
            Color thisImageColor = buttonText.color;
            
            // m_alphaValue.Add(thisImageColor.a);

            thisImageColor.a = 0;
            buttonText.color = thisImageColor;

            m_imageTextList.Add(thisImageColor);
        }
    }

    public void Display()
    {
        StartCoroutine(DradiateDisplay());
    }

    IEnumerator DradiateDisplay()
    {
        float time = 0;
        while (time <= m_displayDuration)
        {
            yield return null;

            for (int i = 0; i < m_imageList.Count; i++)
            {
                Color color = m_imageColorList[i];
                color.a = time / m_displayDuration; //* m_alphaValue[i];

                m_imageList[i].color = color;
            }

            for (int i = 0; i < m_textList.Count; i++)
            {
                Color color = m_imageTextList[i];
                color.a = time / m_displayDuration; // * m_alphaValue[i + m_imageList.Count];

                m_textList[i].color = color;
            }

            time += Time.deltaTime;
        }
    }
}
