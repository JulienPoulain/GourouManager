using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CameraPlacement m_defaultPlacement;

    void Start()
    {
        Debug.Log("Position de la camera" + transform.position);
        Debug.Log("Rotation de la camera" + transform.rotation);
        
        // A REACTIVER LORSQU'ON VEUT TESTER LE JEU
        ResetPosition();
    }
    public void ChangePosition(CameraPlacement p_cameraData)
    {
        transform.position = p_cameraData.Position;
        transform.rotation = p_cameraData.Rotation;
    }

    public void ResetPosition()
    {
        transform.position = m_defaultPlacement.Position;
        transform.rotation = m_defaultPlacement.Rotation;
    }
    
    
}
