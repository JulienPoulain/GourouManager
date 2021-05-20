using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCrisis : MonoBehaviour
{
    [SerializeField] TMP_Text m_textNom;
    [SerializeField] TMP_Text m_Description1;
    [SerializeField] TMP_Text m_Description2;

    public void Display(StructEventCrisesSO p_data)
    {
        m_textNom.text = "Crises";
        m_Description1.text = "Les terribles crises qui traversent Le pay empirent à mesure " +
            "que le Culte Du Grand Cthulhu game en puissance.";
        m_Description2.text = "Ceci est une description des effets de la crise";
    }
}
