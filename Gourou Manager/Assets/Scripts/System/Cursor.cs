using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{  
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
            if (hit.transform.gameObject.TryGetComponent(out InterfaceDisplay script) && GameManager.Instance.u_rotateAroundMap)
            {
                Affiche = true;
                script.DisplayInterface();

                if (Input.GetMouseButtonDown(0) && !GameManager.Instance.u_Camera.GetComponent<CameraControler>().m_cameraFocusOnInstitution)
                {
                    GameManager.Instance.u_Camera.GetComponent<CameraControler>().FocusOnInstitution(hit.transform.position);
                }
            }

            // activer la camera autour de la carte
            if (Input.GetMouseButtonDown(0) && !GameManager.Instance.u_rotateAroundMap)
            {
                // on active la rotation de la camera autour de la carte (obj 3d)
                GameManager.Instance.u_rotateAroundMap = true;
            }
        }
        else
        {
            Affiche = false;
        }        
    }
}
