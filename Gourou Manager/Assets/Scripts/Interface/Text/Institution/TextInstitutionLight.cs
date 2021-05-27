using UnityEngine;
using TMPro;
public class TextInstitutionLight : MonoBehaviour
{
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_textEtat;
    [SerializeField] TMP_Text m_textFont;
    [SerializeField] TMP_Text m_textDescription;

    public void Display(InstitutionSO p_data)
    {
        m_textNom.text = "" + p_data.m_name;
        
        m_textEtat.text = "" + p_data.m_option.ToString();
        m_textFont.text = "Font : " + p_data.Funds.Value;
        // m_textDescription.text = "Si ce text est présent, c'est qu'on doit rajouter une description aux Institutions";
        m_textDescription.text = "" + p_data.m_description;
    }
}
