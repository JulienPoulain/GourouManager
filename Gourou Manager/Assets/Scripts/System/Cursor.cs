using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{
    CameraControler m_CameraScript;
    private InterfaceManager m_InterfaceManager;

    bool _affiche = false;
    
    void Start()
    {
        
        m_InterfaceManager = GameManager.Instance.u_InterfaceManager;   // raccourcis l'access à Interface Manager
        m_InterfaceManager.DisallowLightInstitution();  // désafficher les Institutions
        m_InterfaceManager.DisallowHeavyInstitution();  // désafficher les Institutions
        m_InterfaceManager.DisallowCrisis();  // désafficher les Crises
        
        m_CameraScript = GameManager.Instance.u_Camera.GetComponent<CameraControler>();
        
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
            // Possibilités lorsque la camera tourne autour de la carte
            if (hit.transform.gameObject.TryGetComponent(out InterfaceInstitution script))
            {
                if (!m_InterfaceManager.m_InstitutionLightIsDisplay && !m_InterfaceManager.m_InstitutionHeavyIsDisplay)
                {
                    m_InterfaceManager.DisplayLightInstitution(script.gameObject, script.m_Institution);
                }
                
                if (Input.GetMouseButtonDown(0))
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
                if (m_InterfaceManager.m_InstitutionHeavyIsDisplay) m_InterfaceManager.DisallowHeavyInstitution();
            }
        }        
    }
}
