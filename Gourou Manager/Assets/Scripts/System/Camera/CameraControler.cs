using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    // Interraction avec la Carte
    [SerializeField] GameObject m_FieldTarget;

    [Tooltip("Definit la position initiale de la cam lorsqu'elle cible la Carte")]
    [SerializeField] Vector3 m_InitialPos;

    [Tooltip("Definit la rotation initiale de la cam lorsqu'elle cible la Carte")]
    [SerializeField] Quaternion m_InitialRotation;

    [Tooltip("Vitesse de la camera lorsqu'elle cible la Carte")]
    [SerializeField] float m_cameraFirstMovementSpeed = 2f;

    [Tooltip("Vitesse de la camera lorsqu'elle tourne autour de la carte")]
    // use in InterfaceManager pour ralentir la camera lorsqu'on affiche une institution
    [SerializeField] public float m_cameraRotationSpeed = 10f;

    [Tooltip("Definit la distace à laquelle la camera sera éloignée de l'institution lors que m_cameraFocusOnInstitution == true")]
    [SerializeField] float m_FocusInsitutionDistance;


    [Tooltip("true = camera cible le plateau / false = camera est sur le personnage")]
    /// <summary>
    /// Accesseur -> permet de rendre le focus sur le plateau en coroutine, et donc,
    /// en automatique et avec une gestion du temps
    /// </summary>
    bool _CameraFocusOnMap = false;
    public bool m_cameraFocusOnMap
    {
        get { return _CameraFocusOnMap; }
        set 
        {
            if (value == _CameraFocusOnMap) return;

            _CameraFocusOnMap = value;
            Debug.Log("CA BOUGE ICI");
            
            if(value)
            {
                StartCoroutine("FocusOnMap");
            }
        }
    }

    public bool m_cameraFocusOnInstitution;
    

    /*
    void Update()
    {
        if (m_CameraFocusOnPlayer)
        {
            // insérer les commandes de déplacements // 
        }
    }
    */

    /// <summary>
    /// Permet de cibler la camera sur une intitution
    /// </summary>
    /// <param name="p_Object"></param>
    public void FocusOnInstitution(Vector3 p_position)
    {
        m_cameraFocusOnInstitution = true;
        m_cameraFocusOnMap = false;

        // focus l'institution
        

        IEnumerator coroutine = FocusInstitution(p_position);
        StartCoroutine(coroutine);
    }

    /// <summary>
    /// Permet le retour de la camera autour de la carte
    /// </summary>
    public void StopFocusOnInstitution()
    {
        m_cameraFocusOnInstitution = false;
        m_cameraFocusOnMap = true;
    }

    IEnumerator FocusInstitution(Vector3 p_targetPos)
    {
        float dist = Vector3.Distance(p_targetPos, transform.position);

        while (dist > m_FocusInsitutionDistance)
        {
            transform.LookAt(p_targetPos, Vector3.up);
            transform.position = Vector3.Lerp(transform.position, p_targetPos, Time.deltaTime * 2f);

            yield return new WaitForSeconds(0f);

            dist = Vector3.Distance(p_targetPos, transform.position);
            Debug.Log("la distance est de " + dist);
        }
    }

    /// <summary>
    /// s'active lorsque la camera cible la carte
    /// </summary>
    /// <returns></returns>
    IEnumerator FocusOnMap()
    {
        float pause = 0.5f; // temps de pause lorsque la camera pointe vers la table
        Vector3 position = CalculCameraPosition();

        // transform.position = Vector3.MoveTowards(transform.position, CalculCameraPosition(), m_CameraFirstMovementSpeed);

        float transitionTime = 0f;

        while (transitionTime < 1.5f)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * m_cameraFirstMovementSpeed);
            // transform.position += (m_InitialPos - transform.position * Time.deltaTime * m_CameraFirstMovementSpeed).normalized;
            yield return new WaitForSeconds(0f);
            transitionTime += Time.deltaTime;
            
            transform.LookAt(m_FieldTarget.transform.position, Vector3.up);
        }

        // transition entre la position et la rotation de la camera autour de la carte
    }


    Vector3 CalculCameraPosition()
    {
        // Vector3 initialPos = new Vector3(9.08f, 10.85f, -28.87f);

        Vector3 initialPos = m_FieldTarget.transform.position + m_InitialPos;
        // return initialPos;
        return m_InitialPos;
    }
}


// Rotate Around map
/*
while (m_cameraFocusOnMap == true)
{
    yield return new WaitForSeconds(0);
    transform.RotateAround(m_FieldTarget.transform.position, Vector3.up, m_cameraRotationSpeed * Time.deltaTime);
    transform.LookAt(m_FieldTarget.transform.position, Vector3.up);
}
*/