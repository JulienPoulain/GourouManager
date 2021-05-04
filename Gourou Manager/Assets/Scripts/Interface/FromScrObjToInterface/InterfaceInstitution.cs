using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceInstitution : InterfaceDisplay
{
    [SerializeField] public InstitutionSO m_Institution;

    public override void DisplayInterface()
    {
        GameManager.Instance.u_InterfaceManager.DisplayInstitution(this.gameObject ,m_Institution);
    }
}
