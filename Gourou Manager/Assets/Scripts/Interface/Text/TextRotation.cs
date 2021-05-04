using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script a poser sur les GameObject meres des Text
/// </summary>

public class TextRotation : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(GameManager.Instance.u_Camera.transform.position);
    }
}
