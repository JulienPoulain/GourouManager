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
            if (hit.transform.gameObject.TryGetComponent(out InterfaceDisplay script))
            {
                Affiche = true;
                // hit.transform.gameObject.SetActive(true);
                // hit.transform.gameObject.GetComponent<InterfaceDisplay>().DisplayInterface();
                script.DisplayInterface();
            }
        }
        else
        {
            Affiche = false;
        }

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Mathf.Infinity, m_layerMask))
        {
            if (!GameManager.Instance.u_rotateAroundMap && hit.transform.gameObject.CompareTag("Map"))
            // on active la rotation de la camera autour de la carte (obj 3d)
            GameManager.Instance.u_rotateAroundMap = true;
        }
    }
}
