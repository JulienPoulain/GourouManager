using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{
    CameraControler m_CameraScript;

    bool _affiche = false;
    public bool Affiche
    {
        get {return _affiche;}
        set 
        {
            if (value == _affiche) return;
            if (!value) GameManager.Instance.u_InterfaceManager.Disallow();
            _affiche = value;
        }
    }

    void Start()
    {
        GameManager.Instance.u_InterfaceManager.Disallow();
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
                GameManager.Instance.u_InformationTarget = script;

                if (Input.GetMouseButtonDown(0))
                {
                    m_CameraScript.FocusOnInstitution(hit.transform.position);
                }
            }
        }
        else
        {
            GameManager.Instance.u_InformationTarget = null;
        }        
    }
}
