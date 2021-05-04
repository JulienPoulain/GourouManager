using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

// local = text in front of the camera
// global = text in map

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject m_InstitutionLocal;  // texte local
    [SerializeField] GameObject m_InstitutionGlobal;    // texte global
    
    [SerializeField] GameObject m_Crisis;   // texte local

    /// <summary>
    /// Afficher l'institution : m_Institution -> TextContainer -> List<TextMesh> -> Modifier
    /// </summary>
    /// <param name="Institution Display"></param>
    public void DisplayInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        // redirection du flux selon si la camera tourne autour de la carte
        switch (GameManager.Instance.u_rotateAroundMap)
        {
            case true:
                DisplayWorldInstitution(p_Institution, p_InstitutionScriptable);
                break;
            case false:
                DisplayLocalInstitution(p_InstitutionScriptable);
                break;
        }
    }

    void DisplayLocalInstitution(InstitutionSO p_Institution)
    {
        m_InstitutionLocal.SetActive(true);
        // TextContainer TextBox = m_Institution.GetComponent<TextContainer>();
        TextMesh[] textList = m_InstitutionLocal.GetComponentsInChildren<TextMesh>();

        // TextMesh test = TextBox.m_TextList[0];

        textList[0].text = "Nom: " + p_Institution.m_name;
        textList[1].text = "Fonts : " + p_Institution.m_funds.m_value;
        textList[2].text = "Membre : " + p_Institution.m_members.m_value;
        textList[3].text = "Fnatique : " + p_Institution.m_fanatics.m_value;
        textList[4].text = "Exposition public : " + p_Institution.m_publicExposure.m_value;
        textList[5].text = "Corruption : " + p_Institution.m_corruption.m_value;
        // TextBox.m_TextList[6].text = "Etat : " + p_Institution.OpinionOnTheCult;
    }

    void DisplayWorldInstitution(GameObject p_Institution, InstitutionSO p_InstitutionScriptable)
    {
        // Placement du texte
        m_InstitutionGlobal.SetActive(true);
        float distance = 2f;
        Vector3 position = (GameManager.Instance.u_Camera.transform.right * distance) ;

        m_InstitutionGlobal.transform.position = p_Institution.gameObject.transform.position + position;
        m_InstitutionGlobal.transform.LookAt(p_Institution.transform.position, Vector3.left);

        // Changement du texte
        TextMesh[] textList = m_InstitutionGlobal.GetComponentsInChildren<TextMesh>();



        // ralentissement de la camera lorsque qu'on affiche une insitution:
        // GameManager.Instance.u_Camera.GetComponent<CameraControler>().m_cameraRotationSpeed = 4f;
    }


    public void DisplayCrisis(StructEventCrisesSO p_Crisis)
    {
        m_Crisis.SetActive(true);

        TextMesh[] textList = m_Crisis.GetComponentsInChildren<TextMesh>();

        textList[0].text = "" ;
        textList[1].text = "Taux de la Crisis : ";
        textList[2].text = "Effect : ";
    }


    public void Display(InterfaceDisplay p_Object) // call in Cursor.cs
    {
        // switch(p_Object.m_type)
        

    }

    public void Disallow() // call in Cursor.cs
    {
        m_Crisis.SetActive(false);
        m_InstitutionLocal.SetActive(false);
        m_InstitutionGlobal.SetActive(false);
    }
}
