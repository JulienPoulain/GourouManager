using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InterlocutorButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text m_TextContainer;
    private InterlocutorSO m_Interlocutor;

    public void Configuration(InterlocutorSO p_Interlocutor)
    {
        m_Interlocutor = p_Interlocutor;
        m_TextContainer.text = "" + p_Interlocutor.m_name;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.Instance.m_InterfaceManager.m_InterlocutorScript.Display(m_Interlocutor);
        }
    }

    // lorsque l'object est desafficher, on le supprime et on reset les statistiques de l'interface interlocutor
    void OnDisable()
    {
        Destroy (this.gameObject);
    }
}
