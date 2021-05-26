using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceCrisis : MonoBehaviour
{
    [SerializeField] StructEventCrisesSO m_Crisis;

    public void Display()
    {
        GameManager.Instance.m_interfaceManager.DisplayCrisis(m_Crisis);
    }
}
