using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextApprocheIndividual : MonoBehaviour
{
    [SerializeField] TMP_Text m_name;
    [SerializeField] TMP_Text m_dialogueCharacter;
    [SerializeField] TMP_Text m_gain;

    public void Display(ApproachSO p_approach)
    {
        m_name.text = "" + p_approach.Name;
        m_dialogueCharacter.text = "" + p_approach.m_DialogueApproach;
        m_gain.text = "" + p_approach.m_resultatApproach;
    }
}
