using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;

public class TextCultStat : MonoBehaviour
{
    [SerializeField] TMP_Text m_fonds;
    [SerializeField] TMP_Text m_membres;
    [SerializeField] TMP_Text m_fanatiques;
    [SerializeField] TMP_Text m_expositionPublic;
    [SerializeField] TMP_Text m_turnNumber;

    [SerializeField] Image m_backGroundColor;

    private void Start()
    {
        // on définit ici les couleurs pour ne pas avoir a le faire à chaques appels
        m_backGroundColor.color = GameManager.Instance.MainInstitutionScript.InstitutionColor;
        
        Display();
    }

    public void Display()
    {
        m_turnNumber.text = "" + GameManager.Instance.Turn;
    }

    private void OnEnable()
    {
        InstitutionSO culte = GameManager.Instance.MainInstitution;
        culte.Funds.onValueChanged += HandleFundsChanged;
        culte.Members.onValueChanged += HandleMembersChanged;
        culte.Fanatics.onValueChanged += HandleFanaticsChanged;
        culte.PublicExposure.onValueChanged += HandlePublicExposureChanged;
    }

    private void OnDisable()
    {
        InstitutionSO culte = GameManager.Instance.MainInstitution;
        culte.Funds.onValueChanged -= HandleFundsChanged;
        culte.Members.onValueChanged -= HandleMembersChanged;
        culte.Fanatics.onValueChanged -= HandleFanaticsChanged;
        culte.PublicExposure.onValueChanged -= HandlePublicExposureChanged;
    }
    
    private void HandleFundsChanged(int p_value) {
        m_fonds.text = "" + p_value.ToString("N1");
    }
    private void HandleMembersChanged(int p_value) {
        m_membres.text = "" + p_value;
    }
    private void HandleFanaticsChanged(int p_value) {
        m_fanatiques.text = "" + p_value;
    }
    private void HandlePublicExposureChanged(int p_value) {
        m_expositionPublic.text = "" + p_value;
    }
}
