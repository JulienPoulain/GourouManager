using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstitutionScript : MonoBehaviour
{
    [SerializeField] public InstitutionSO m_Institution;
    
    // Partie concernant les changements de l'interface
    [SerializeField] [Tooltip("Camera qui sera activee lors des approches")] public GameObject m_cameraObject;
    [SerializeField] [Tooltip("Couleur prepresenant l'institution")] private Color m_institutionColor;
    public Color InstitutionColor => m_institutionColor;
}
