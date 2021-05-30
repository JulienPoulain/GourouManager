using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InterlocutorButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text m_textContainer;
    public InterlocutorSO m_interlocutor;

    // On recupere l'image lier a ce script pour changer sa couleur
    Image m_thisImage;

    void Awake()
    {
        m_thisImage = GetComponent<Image>();
    }

    public void Configuration(InterlocutorSO p_Interlocutor)
    {
        m_interlocutor = p_Interlocutor;
        m_textContainer.text = "" + p_Interlocutor.m_name;

        m_thisImage.color = GameManager.Instance.m_interfaceManager.m_institutionSelected.InstitutionColor;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            // On appelle Display du script TextInterlocutor depuis le GameManager
            GameManager.Instance.m_interfaceManager.m_interlocutorScript.Display(m_interlocutor);
        }
    }
}
