using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] private Sprite m_witeSprite;
    [SerializeField] private Sprite m_redSprite;

    public Sprite WhiteSprite => m_witeSprite;
    public Sprite RedSprite => m_redSprite;
}
