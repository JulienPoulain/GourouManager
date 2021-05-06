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
        m_InterfaceManager.Disallow();  // désafficher toutes les Interfaces
        
        m_CameraScript = GameManager.Instance.u_Camera.GetComponent<CameraControler>();
        
    }
    
    public bool Affiche
    {
        get {return _affiche;}
        set 
        {
            if (value == _affiche) return;
            if (!value) m_InterfaceManager.Disallow();
            _affiche = value;
        }
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
                if (!m_InterfaceManager.m_interfaceIsDisplay)
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
            if (m_InterfaceManager.m_interfaceIsDisplay)
            {
                m_InterfaceManager.Disallow();
            }
        }        
    }
}
