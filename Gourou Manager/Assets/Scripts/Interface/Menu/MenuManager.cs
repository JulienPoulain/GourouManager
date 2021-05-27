using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    public void LoadScene(string p_sceneName)
    {
        SceneManager.LoadScene(p_sceneName, LoadSceneMode.Single);
    }

    public void GameQuit()
    {

    }
}
