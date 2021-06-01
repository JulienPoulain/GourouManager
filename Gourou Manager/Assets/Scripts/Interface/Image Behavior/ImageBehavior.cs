using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBehavior : MonoBehaviour
{
    [SerializeField] Sprite m_backGroundImage;
    [SerializeField] Sprite m_backGroundReverseImage;

    /// <summary>
    /// Sert pour Image Behavior, le principe est d'interchanger les couleurs de fond
    /// </summary>
    /// <param name="p_backGround"></param>
    /// <param name="p_backGroundColor"></param>
    public void ReverseBackGroundImage(Image p_backGround)
    {
        p_backGround.sprite = m_backGroundReverseImage;
    }

    public void ReplaceBackGroundImage(Image p_backGround)
    {
        p_backGround.sprite = m_backGroundImage;
    }
}
