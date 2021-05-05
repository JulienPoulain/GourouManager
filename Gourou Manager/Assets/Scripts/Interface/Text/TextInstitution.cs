using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextInstitution : TextContainer
{
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_textEtat;
    [SerializeField] TMP_Text m_textFont;
    [SerializeField] TMP_Text m_textDescription;

    public void Display(InstitutionSO p_source)
    {
        m_textNom.text = "OUI" ;
        m_textEtat.text = "OUI";
        m_textFont.text = "DU BOIS MERCI";
        m_textDescription.text = "WOLOLOLOOOO leslilasdelilylientlelienlouesalola";
    }
}
