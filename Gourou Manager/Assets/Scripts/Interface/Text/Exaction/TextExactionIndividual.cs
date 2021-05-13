using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextExactionIndividual : MonoBehaviour
{
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_textDescription;

    ExactionSO m_ActualExaction;

    public void Display(ExactionSO p_exaction)
    {
        m_ActualExaction = p_exaction;

        m_textNom.text = "" + p_exaction.m_name;
        m_textDescription.text = "" + p_exaction.m_description;
    }

    public void ExecuteExaction()
    {
        GameManager.Instance.m_pendingExactions.Add(m_ActualExaction);
        GameManager.Instance.u_InterfaceManager.DisallowExaction();
    }
}
