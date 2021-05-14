using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{
    private InterfaceManager m_InterfaceManager;
    private Camera m_Camera;

    bool _affiche = false;
    
    void Start()
    {
        
        m_InterfaceManager = GameManager.Instance.m_InterfaceManager;   // raccourcis l'access à Interface Manager
        m_InterfaceManager.DisallowLightInstitution();  // désafficher les Institutions
        m_InterfaceManager.DisallowHeavyInstitution();  // désafficher les Institutions
        m_InterfaceManager.DisallowCrisis();  // désafficher les Crises        
        m_InterfaceManager.DisallowInterlocutor();
        m_InterfaceManager.DisallowApproche();
        m_InterfaceManager.DisallowExaction();

        m_Camera = GameManager.Instance.GetComponent<Camera>();
    }

    // raycast
    [SerializeField] float m_raycastLenght = 10f;
    [SerializeField] LayerMask m_layerMask;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // Affiche les infos 
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_layerMask))
        {
            // on regarde si le GO selectionner est une institution
            if (hit.transform.gameObject.TryGetComponent(out InterfaceInstitution script))
            {
                if (!m_InterfaceManager.m_InstitutionLightIsDisplay && !m_InterfaceManager.m_InstitutionHeavyIsDisplay && !m_InterfaceManager.m_InterlocutorIsDisplay)
                {
                    m_InterfaceManager.DisplayLightInstitution(script.gameObject, script.m_Institution);
                }
                
                if (Input.GetMouseButtonDown(0) && !m_InterfaceManager.m_InstitutionHeavyIsDisplay)
                {
                    //m_CameraScript.FocusOnInstitution(hit.transform.position);
                    m_InterfaceManager.DisplayHeavyInstitution(script.m_Institution);
                }
            }
        }
        else // si le curseur ne pointe null part, toutes les interfaces sont désactivés
        {
            // desafficher les interfaces Institution
            if (m_InterfaceManager.m_InstitutionLightIsDisplay) m_InterfaceManager.DisallowLightInstitution();

            // desafficher l'interface de crise
            if (Input.GetMouseButtonDown(0))
            {
                if (m_InterfaceManager.m_crisisIsDisplay) m_InterfaceManager.DisallowCrisis();
                if (m_InterfaceManager.m_InstitutionHeavyIsDisplay && !m_InterfaceManager.m_cursorFocusHeavyInstitution) m_InterfaceManager.DisallowHeavyInstitution();
                // chercher comment détecter si le cursor pointe un boutton
            }
        }
    }
}
