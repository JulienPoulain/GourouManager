using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceCrisis : InterfaceDisplay
{
    [SerializeField] StructEventCrisesSO m_Crisis;

    public override void DisplayInterface()
    {
        GameManager.Instance.u_InterfaceManager.DisplayCrisis(m_Crisis);
    }
}
