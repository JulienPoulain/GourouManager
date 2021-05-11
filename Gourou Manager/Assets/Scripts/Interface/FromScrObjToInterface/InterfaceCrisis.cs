using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceCrisis : MonoBehaviour
{
    [SerializeField] StructEventCrisesSO m_Crisis;

    public void Display()
    {
        GameManager.Instance.u_InterfaceManager.DisplayCrisis(m_Crisis);
    }
}
