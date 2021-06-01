using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    // Main caméra
    [SerializeField] private Camera m_mainCamera;
    // Caméra utilisée actuellement
    [SerializeField] private Camera m_currentCamera;
    // Vue de référence
    [SerializeField] private Transform m_currentView;
    // Vue actuelle
    [SerializeField] private Transform m_view;

    [Header("Views")]
    [SerializeField] private Transform m_viewMainScreen;
    [SerializeField] private Transform m_viewPolice;

    [Header("MainScreen")]
    [SerializeField] private Transform m_springView;
    [Range(0.0f, 20.0f)]
    [SerializeField] private float m_springSoftness;

    [Header("Transition")]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float m_transitionSpeed;

    [SerializeField] private Vector2 m_cursorPos;
    [SerializeField] private float m_screenWidth;
    [SerializeField] private float m_screenHeigth;
    [SerializeField] private Vector2 m_centerScreen;
    [SerializeField] private Vector2 m_normalizedToCenter;

    private void Start()
    {
        m_mainCamera = Camera.main;
        m_currentCamera = m_mainCamera;
        m_currentView = m_viewMainScreen;

        m_centerScreen = new Vector2();
    }

    private void Update()
    {
        m_cursorPos.x = Input.mousePosition.x;
        m_cursorPos.y = Input.mousePosition.y;
        m_screenWidth = Screen.width;
        m_screenHeigth = Screen.height;
        m_centerScreen.x = (float) Screen.width / 2;
        m_centerScreen.y = (float) Screen.height / 2;
        m_normalizedToCenter.x = (m_cursorPos.x - m_centerScreen.x) / (m_screenWidth / 2);
        m_normalizedToCenter.y = (m_cursorPos.y - m_centerScreen.y) / (m_screenHeigth / 2);

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (m_currentView == m_viewMainScreen)
                m_currentView = m_viewPolice;
            else
                m_currentView = m_viewMainScreen;
        }

        m_view.position = m_currentView.position;
        m_view.rotation = m_currentView.rotation;
        if (m_currentView == m_viewMainScreen)
            SpringView(m_view);
    }

    private void LateUpdate()
    {
        TransitionCam();
    }

    private void SpringView(Transform p_transform)
    {
        p_transform.Translate(
            m_normalizedToCenter.x * m_springSoftness,
            m_normalizedToCenter.y * m_springSoftness,
            0);
    }

    private void TransitionCam()
    {
        m_currentCamera.transform.position =
            Vector3.Lerp(
                m_currentCamera.transform.position,
                m_view.position,
                Time.deltaTime * m_transitionSpeed);
        m_currentCamera.transform.rotation =
            Quaternion.Lerp(
                m_currentCamera.transform.rotation,
                m_view.rotation,
                Time.deltaTime * m_transitionSpeed);
    }
}
