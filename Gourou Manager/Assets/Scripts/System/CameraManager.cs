using UnityEditor;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private Camera m_mainCamera;
    
    [SerializeField] private Vector3 m_posMainScreen;
    [Range(0.0f, 2.0f)]
    [SerializeField] private float m_springSoftness;

    [SerializeField] private Vector2 m_cursorPos;
    [SerializeField] private float m_screenWidth;
    [SerializeField] private float m_screenHeigth;
    [SerializeField] private Vector2 m_centerScreen;
    [SerializeField] private Vector2 m_nomalizedToCenter;
    [SerializeField] private Vector3 m_localPos;
    
    private void Start()
    {
        m_mainCamera = Camera.main;
        m_posMainScreen = m_mainCamera.transform.position;
        m_centerScreen = new Vector2();
        m_localPos = m_mainCamera.transform.localPosition;
    }

    private void Update()
    {
        /**/m_cursorPos.x = Input.mousePosition.x;
        /**/m_cursorPos.y = Input.mousePosition.y;
        m_screenWidth = Screen.width;
        m_screenHeigth = Screen.height;
        m_centerScreen.x = (float) Screen.width / 2;
        m_centerScreen.y = (float) Screen.height / 2;
        m_nomalizedToCenter.x = (m_cursorPos.x - m_centerScreen.x) / (m_screenWidth / 2);
        m_nomalizedToCenter.y = (m_cursorPos.y - m_centerScreen.y) / (m_screenHeigth / 2);

        springCam();
    }

    private void springCam()
    {
        m_mainCamera.transform.position = m_posMainScreen;
        m_mainCamera.transform.Translate(
            m_nomalizedToCenter.x * m_springSoftness,
            m_nomalizedToCenter.y * m_springSoftness,
            0);
    }
}
