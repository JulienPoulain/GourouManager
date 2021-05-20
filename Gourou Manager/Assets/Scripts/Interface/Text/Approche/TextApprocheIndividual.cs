using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextApprocheIndividual : MonoBehaviour
{
    [SerializeField] TMP_Text m_name;
    [SerializeField] TMP_Text m_dialogueCharacter;
    [SerializeField] TMP_Text m_gain;

    ApproachSO m_Approche;

    public void Display(ApproachSO p_approach)
    {
        m_Approche = p_approach;

        m_name.text = "" + p_approach.Name;
        m_dialogueCharacter.text = "" + p_approach.m_dialogueApproach;
        m_gain.text = "" + p_approach.m_resultatApproach;
    }

    public void ExecuteApproche()
    {
        GameManager.Instance.PendingExactions.Add(m_Approche.TryApproach());
        Debug.Log("Approche fait");
        GameManager.Instance.m_InterfaceManager.DisallowApproche();

        m_Approche = null;
    }
}
