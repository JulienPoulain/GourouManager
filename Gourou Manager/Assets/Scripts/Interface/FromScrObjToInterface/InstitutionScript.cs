using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstitutionScript : MonoBehaviour
{
    [SerializeField] public InstitutionSO m_Institution;
    
    // Partie concernant les changements de l'interface
    [SerializeField] [Tooltip("Vue qui sera activée lors des approches")] private Transform m_view;
    [SerializeField] [Tooltip("Couleur prepresenant l'institution")] private Color m_institutionColor;
    [SerializeField] [Tooltip("Alpha du pictogram représentant l'institution, sur l'interface LightInstitution")] private float m_institutionAlpha;

    public Transform View => m_view;

    public Color InstitutionColor => m_institutionColor;
    public float InstitutionAlpha => m_institutionAlpha;
}
