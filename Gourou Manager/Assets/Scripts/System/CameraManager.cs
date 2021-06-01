using System.Collections;
using TreeEditor;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    // Main caméra
    [SerializeField] private Camera m_mainCamera;
    // Caméra utilisée actuellement
    [SerializeField] private Camera m_currentCamera;
    // Vue de référence
    [SerializeField] private Transform m_currentView;
    // Vue destination
    [SerializeField] private Transform m_viewDestination;

    [Header("Views")]
    [SerializeField] private Transform m_viewMainScreen;
    [SerializeField] private Transform m_viewPolice;

    [Header("MainScreen")]
    [SerializeField] private Transform m_springView;
    [Range(0.0f, 20.0f)]
    [SerializeField] private float m_springSoftness;

    [Header("Transition")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float m_transitionSpeed;
    [SerializeField] private Coroutine m_instTransitionToView = null;

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
        /*m_viewDestination.position = m_currentView.position;
        m_viewDestination.rotation = m_currentView.rotation;*/

        // POUR LE DEBUG
        m_centerScreen = new Vector2();
    }

    private void Update()
    {
        // POUR LE DEBUG
        m_cursorPos.x = Input.mousePosition.x;
        m_cursorPos.y = Input.mousePosition.y;
        m_screenWidth = Screen.width;
        m_screenHeigth = Screen.height;
        m_centerScreen.x = (float) Screen.width / 2;
        m_centerScreen.y = (float) Screen.height / 2;

        m_normalizedToCenter = GetPosNormToCenter();

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log($"DEBUT - m_instTransitionToView : {m_instTransitionToView}");
            if (m_instTransitionToView != null)
                StopCoroutine(m_instTransitionToView);
            
            if (m_currentView == m_viewMainScreen)
                m_currentView = m_viewPolice;
            else
                m_currentView = m_viewMainScreen;
            
            m_viewDestination.position = m_currentView.position;
            m_viewDestination.rotation = m_currentView.rotation;
            
            m_instTransitionToView = StartCoroutine(TransitionToView(m_viewDestination));
            Debug.Log($"FIN   - m_instTransitionToView : {m_instTransitionToView}");
        }
        
        if (m_currentView == m_viewMainScreen)
            SpringView(m_viewDestination);
    }

    /// <summary>
    /// Retourne la position du curseur sur l'écran de jeu avec :
    /// - 0 pour le centre.
    /// - 1 comme interval centre/bord.
    /// </summary>
    /// <returns>Vector2 position relative au centre de l'écran.</returns>
    private Vector2 GetPosNormToCenter()
    {
        return new Vector2(
            m_cursorPos.x * (2 / m_screenWidth) - 2,
            m_cursorPos.y * (2 / m_screenHeigth) - 2);
    }

    /// <summary>
    /// Modifie un transforme pour qu'il accompagne le curseur sur l'écran de jeu.
    /// </summary>
    /// <param name="p_transform">Transform sur lequel appliquer la translation.</param>
    private void SpringView(Transform p_transform)
    {
        p_transform.Translate(
            m_normalizedToCenter.x * m_springSoftness,
            m_normalizedToCenter.y * m_springSoftness,
            0);
    }

    /// <summary>
    /// Coroutine transition entre la vue actuelle de la caméra à la vue renseignée.
    /// </summary>
    /// <param name="p_view">La vue destination.</param>
    /// <returns>La coroutine TransitionToView instanciée.</returns>
    private IEnumerator TransitionToView(Transform p_view)
    {
        Transform transformMainCamera = m_mainCamera.transform;
        
        Vector3 initPos = transformMainCamera.position;
        Quaternion initRot = transformMainCamera.rotation;
        float elapsedTime = 0f;
        
        while (elapsedTime <= m_transitionSpeed)
        {
            elapsedTime += Time.deltaTime;
            
            m_currentCamera.transform.position =
                Vector3.Lerp(
                    initPos,
                    p_view.position,
                    elapsedTime / m_transitionSpeed);
            
            m_currentCamera.transform.rotation =
                Quaternion.Lerp(
                    initRot,
                    p_view.rotation,
                    elapsedTime / m_transitionSpeed);
            
            yield return null;
        }
    }
}
