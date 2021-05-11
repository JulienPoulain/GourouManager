using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T m_instance;
    public int m_stat = 0;

    static protected void CreateMySingleton()
    {
        GameObject singletonObject = new GameObject();
        m_instance = singletonObject.AddComponent<T>();
    }

    protected void Initializer()
    {
        DontDestroyOnLoad(gameObject);
    }


    public static T Instance
    {
        get
        {
            if (m_instance != null)
            {
                return m_instance;
            }

            m_instance = FindObjectOfType<T>();
            if (m_instance != null)
            {
                return m_instance;
            }
            CreateMySingleton();
                return m_instance;
        }
    }
}

