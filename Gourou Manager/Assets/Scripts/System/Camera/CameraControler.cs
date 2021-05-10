using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    // Interraction avec la Carte
    [SerializeField] GameObject m_FieldTarget;

    [Tooltip("Definit la distace à laquelle la camera sera éloignée de l'institution lors que m_cameraFocusOnInstitution == true")]
    [SerializeField] float m_FocusInsitutionDistance;

    public bool m_cameraFocusOnInstitution;

    /// <summary>
    /// Permet de cibler la camera sur une intitution
    /// </summary>
    /// <param name="p_Object"></param>
    public void FocusOnInstitution(Vector3 p_position)
    {
        m_cameraFocusOnInstitution = true;

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
}