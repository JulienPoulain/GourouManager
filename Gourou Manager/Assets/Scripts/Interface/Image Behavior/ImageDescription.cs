using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ImageDescription : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] RessourceType m_ressourceName;
    [SerializeField] TMP_Text m_textPrefab;

    // Stocke le GO instancier pour le détruire
    TMP_Text m_actualPrefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        string message = "";
        switch (m_ressourceName)
        {
            case RessourceType.Founds:
                message = "Fonts";
                break;
            case RessourceType.Membres:
                message = "Membres";
                break;
            case RessourceType.Fanatiques:
                message = "Fanatiques";
                break;
            case RessourceType.Tour:
                message = "Jour";
                break;
            case RessourceType.ExpositionPublic:
                message = "Exposition Public";
                break;
            case RessourceType.Corruption:
                message = "Corruption";
                break;
        }

        Vector3 position = new Vector3(Input.mousePosition.x + 120f, Input.mousePosition.y - 25f, 0);
        m_actualPrefab = Instantiate(m_textPrefab, position, Quaternion.identity, GameManager.Instance.m_interfaceManager.transform);
        m_actualPrefab.text = message;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_actualPrefab.transform.position = Input.mousePosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(m_actualPrefab);
    }
}
