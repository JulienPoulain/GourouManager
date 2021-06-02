using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DecayLvlMethods;
public class TextInstitutionLight : MonoBehaviour
{
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] Image m_imageEtat;
    [SerializeField] TMP_Text m_textFont;
    [SerializeField] TMP_Text m_textDescription;
    [SerializeField] Image m_image;
    [SerializeField] Image m_pictogram;



    public void Display(InstitutionSO p_data)
    {
        m_textNom.text = "" + p_data.m_name;
        
        m_imageEtat.sprite = GameManager.Instance.m_interfaceManager.m_pictoEtatBehavior.DisplayEtat(p_data.Decay.GetDecayLvl()) ;
        m_textFont.text = "" + p_data.Funds.Value.ToString("N1");
        // m_textDescription.text = "Si ce text est présent, c'est qu'on doit rajouter une description aux Institutions";
        m_textDescription.text = "" + p_data.m_description;

        // On change la couleur du fond et les lettes
        m_textNom.color = GameManager.Instance.m_interfaceManager.m_institutionSelected.InstitutionColor;
        m_image.color = GameManager.Instance.m_interfaceManager.m_institutionSelected.InstitutionColor;
        
        // on definit la couleur du pictogram pour changer l'opacite
        Color pictogramColor = new Color(m_pictogram.color.r, m_pictogram.color.g, m_pictogram.color.b, GameManager.Instance.m_interfaceManager.m_institutionSelected.InstitutionAlpha);
        
        m_pictogram.color = pictogramColor;
        m_pictogram.sprite = p_data.Pictogram;
        
    }
}
