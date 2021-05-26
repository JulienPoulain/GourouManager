using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] private Sprite m_witeSprite;
    [SerializeField] private Sprite m_redSprite;

//     [SerializeField] private Sceen

    public Sprite WhiteSprite => m_witeSprite;
    public Sprite RedSprite => m_redSprite;

    public void LoadScene(string p_sceneName)
    {
        SceneManager.LoadScene(p_sceneName, LoadSceneMode.Single);

    }

    public void GameQuit()
    {

    }
}
