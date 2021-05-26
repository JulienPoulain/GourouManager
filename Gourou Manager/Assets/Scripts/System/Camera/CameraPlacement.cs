using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExactionSO", menuName = "GourouManager/Dialogue/CameraPlacement")]
public class CameraPlacement : ScriptableObject
{
    [SerializeField] Vector3 m_position;
    [SerializeField] Quaternion m_rotation;

    public Vector3 Position => m_position;
    public Quaternion Rotation => m_rotation;
}
