using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{
    private InterfaceManager m_interfaceManager;
    private Camera m_camera;

    void Start()
    {
        m_interfaceManager = GameManager.Instance.m_interfaceManager;   // raccourcis l'access à Interface Manager
        m_interfaceManager.DisallowLightInstitution();  // désafficher les Institutions
        m_interfaceManager.DisallowHeavyInstitution();  // désafficher les Institutions
        m_interfaceManager.DisallowCrisis();  // désafficher les Crises        
        m_interfaceManager.DisallowInterlocutor();
        m_interfaceManager.DisallowApproche();
        m_interfaceManager.DisallowVictoryDefeat();
        m_interfaceManager.DisallowEndTurn();

        m_camera = GameManager.Instance.GetComponent<Camera>();
    }

    // raycast
    [SerializeField] LayerMask m_layerMask;
    void Update()
    {
        // On commence par vérifier si la camera est active ou non (si non, il y aura des problemes de raycast qui nous interessera pas)
        if (GameManager.Instance.m_camera.activeInHierarchy)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            // Affiche les infos 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_layerMask))
            {
                // on regarde si le GO selectionner est une institution
                if (hit.transform.gameObject.TryGetComponent(out InstitutionScript script) && !m_interfaceManager.m_endTurnIsDisplay)
                {
                    if (!m_interfaceManager.InterfaceIsDisplay())
                    {
                        m_interfaceManager.m_institutionSelected = script;    // On definit cette Institution comme celle actuellement selectionnee
                        m_interfaceManager.DisplayLightInstitution(script.gameObject, script.m_Institution);
                    }
                
                    if (Input.GetMouseButtonDown(0) && !m_interfaceManager.InterfaceIsDisplay())
                    {
                        //m_CameraScript.FocusOnInstitution(hit.transform.position);
                        m_interfaceManager.DisplayHeavyInstitution(script.m_Institution);
                    }
                }
            }
            else // si le curseur ne pointe null part, toutes les interfaces sont désactivés
            {
                // desafficher les interfaces Institution
                if (m_interfaceManager.m_InstitutionLightIsDisplay) m_interfaceManager.DisallowLightInstitution();

                // desafficher l'interface de crise
                if (Input.GetMouseButtonDown(0))
                {
                    if (m_interfaceManager.m_crisisIsDisplay) m_interfaceManager.DisallowCrisis();
                    if (m_interfaceManager.m_InstitutionHeavyIsDisplay && !m_interfaceManager.m_cursorFocusHeavyInstitution) m_interfaceManager.DisallowHeavyInstitution();
                    // chercher comment détecter si le cursor pointe un boutton
                }
            }
        }
        
    }
}
