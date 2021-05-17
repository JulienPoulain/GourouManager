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

        m_textNom.text = "" + p_exaction.Name;
        m_textDescription.text = "" + p_exaction.Description;
    }
}
