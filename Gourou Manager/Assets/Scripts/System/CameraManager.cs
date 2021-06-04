using System.Collections;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private Camera m_mainCamera;
    private Camera m_currentCamera;
    
    [SerializeField] private Transform m_currentView;
    [SerializeField] private Transform m_view;
    
    [SerializeField] private Transform m_viewIsland;
    [SerializeField] private Transform m_viewPolice;

    [Header("Comportements")]
    [SerializeField] private CameraState m_state;
    [Range(0.0f, 2.0f)]
    [SerializeField] private float m_springSoftness;
    [Range(0.0f, 2.0f)]
    [SerializeField] private float m_transitionSpeed;
    private Coroutine m_instCoroutine;


    private void Start()
    {
        // Inititalisation des caméras
        m_mainCamera = Camera.main;
        m_currentCamera = m_mainCamera;
        
        // Initialisation des vues
        m_view = GameObject.Find("View").GetComponentInChildren<Transform>();
        m_viewIsland = GameObject.Find("ViewIsland").GetComponentInChildren<Transform>();
        m_currentView = m_viewIsland;
        m_view.SetPositionAndRotation(m_currentView.position, m_currentView.rotation);

        // Initialisation de l'état de la caméra
        m_state = CameraState.IslandView | CameraState.Spring;
    }

    private void Update()
    {
        m_view.SetPositionAndRotation(m_currentView.position, m_currentView.rotation);

        if ((m_state & CameraState.Spring) == CameraState.Spring)
            SpringView(m_view);
    }

    private void LateUpdate()
    {
        if ((m_state & CameraState.Transition) != CameraState.Transition)
            m_mainCamera.transform.SetPositionAndRotation(m_view.position, m_view.rotation);
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
            Input.mousePosition.x * ((float) 2 / Screen.width) - 1,
            Input.mousePosition.y * ((float) 2 / Screen.height) - 1);
    }

    /// <summary>
    /// Modifie un transforme pour qu'il accompagne le curseur sur l'écran de jeu.
    /// </summary>
    /// <param name="p_transform">Transform sur lequel appliquer la translation.</param>
    private void SpringView(Transform p_transform)
    {
        Vector2 posNormalizedToCenter = GetPosNormToCenter();
        p_transform.Translate(
            posNormalizedToCenter.x * m_springSoftness,
            posNormalizedToCenter.y * m_springSoftness,
            0);
    }

    /// <summary>
    /// Coroutine transition entre la vue actuelle de la caméra à la vue renseignée.
    /// </summary>
    /// <param name="p_view">La vue destination.</param>
    /// <returns>La coroutine TransitionToView instanciée.</returns>
    private IEnumerator TransitionToView(Transform p_view)
    {
        // Ajout du comportement de transition.
        m_state |= CameraState.Transition;
        
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

        transformMainCamera.position = p_view.position;
        transformMainCamera.rotation = p_view.rotation;
        
        // Retrait du comportement de transition.
        Remove(CameraState.Transition);
    }

    /// <summary>
    /// Supprime l'état spécifié.
    /// </summary>
    /// <param name="p_cameraState">L'état à supprimer.</param>
    private void Remove(CameraState p_cameraState)
    {
        CameraState maskErase = CameraState.All ^ p_cameraState;
        m_state &= maskErase;
    }

    /// <summary>
    /// Passe de l'état actuel au nouvel état [sur le groupe concerné si précisé].
    /// </summary>
    /// <param name="p_newState">Nouvel état.</param>
    /// <param name="p_group">Groupe optionel sur lequel s'exerce le changement.</param>
    private void SwitchToState(CameraState p_newState, CameraState p_group = CameraState.All)
    {
        Remove(p_group);
        m_state |= p_newState;
    }

    public void SwitchToInstitution(Transform p_viewInstitution)
    {
        m_currentView = p_viewInstitution;
        SwitchToState(CameraState.InstitutionView);
        m_view.SetPositionAndRotation(m_currentView.position, m_currentView.rotation);
        m_instCoroutine = StartCoroutine(TransitionToView(m_view));
    }

    public void SwitchToIsland()
    {
        m_currentView = m_viewIsland;
        SwitchToState(CameraState.IslandView | CameraState.Spring);
        m_view.SetPositionAndRotation(m_currentView.position, m_currentView.rotation);
        m_instCoroutine = StartCoroutine(TransitionToView(m_view));
    }
}
