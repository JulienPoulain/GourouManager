using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RessourceDescription : MonoBehaviour
{
    [SerializeField] TMP_Text m_text;

    public void Display(string p_description)
    {
        m_text.text = p_description;
    }

}
