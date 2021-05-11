using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterlocutorButton : MonoBehaviour
{
    [SerializeField] private TMP_Text m_TextContainer;
    private InterlocutorSO m_Interlocutor;

    public void Configuration(InterlocutorSO p_Interlocutor)
    {
        m_Interlocutor = p_Interlocutor;
        m_TextContainer.text = "" + p_Interlocutor.m_name;
    }
}
