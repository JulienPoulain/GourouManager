using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ImageDescription : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler // , IPointerDownHandler
{
    [SerializeField] string m_ressourceName;
    [SerializeField] TMP_Text m_textPrefab;

    // Stocke le GO instancier pour le d�truire
    TMP_Text m_actualPrefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        string message = m_ressourceName;
        Vector3 position = new Vector3(Input.mousePosition.x + 120f, Input.mousePosition.y - 25f, 0);
        m_actualPrefab = Instantiate(m_textPrefab, position, Quaternion.identity, GameManager.Instance.m_interfaceManager.transform);
        m_actualPrefab.text = message;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(m_actualPrefab);
    }
}
