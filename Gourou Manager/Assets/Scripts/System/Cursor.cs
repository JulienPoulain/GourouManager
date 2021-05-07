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
        m_InterfaceManager.DisallowInstitution();  // désafficher les Institutions
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
            if (hit.transform.gameObject.TryGetComponent(out InterfaceDisplay script))
            {
                if (!m_InterfaceManager.m_InstitutionIsDisplay)
                {
                    // On fait appel à l'interface, via le script contenu dans le GameObject.
                    // ça permet de faire la différence entre les institutions et les crises
                    script.DisplayInterface();
                }
                
                if (Input.GetMouseButtonDown(0))
                {
                    m_CameraScript.FocusOnInstitution(hit.transform.position);
                }
            }
        }
        else // si le curseur ne pointe null part, toutes les interfaces sont désactivés
        {
            // desafficher les interfaces Institution
            if (m_InterfaceManager.m_InstitutionIsDisplay)
            {
                m_InterfaceManager.DisallowInstitution();
                Debug.Log("je desactive tout");
            }

            // desafficher l'interface de crise
            if (Input.GetMouseButtonDown(0) && m_InterfaceManager.m_crisisIsDisplay)
            {
                m_InterfaceManager.DisallowCrisis();
            }
        }        
    }
}
