using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ImageDescription : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler , IPointerDownHandler
{
    [SerializeField] string m_ressourceName;
    [SerializeField] string m_ressourceDescription;
    [SerializeField] TMP_Text m_textPrefab;

    [SerializeField] GameObject m_descriptionPrefab;
    GameObject m_descriptionPrefabContainer;

    bool m_descriptionIsDisplay = false;

    // Stocke le GO instancier pour le d�truire
    TMP_Text m_actualPrefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        string message = m_ressourceName;
        Vector3 position = new Vector3(Input.mousePosition.x + 120f, Input.mousePosition.y - 25f, 0);
        m_actualPrefab = Instantiate(m_textPrefab, position, Quaternion.identity, GameManager.Instance.m_interfaceManager.transform);
        m_actualPrefab.text = message;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!m_descriptionIsDisplay)
        {
            m_descriptionIsDisplay = true;
            RectTransform canvasDim = GameManager.Instance.m_interfaceManager.m_canvasSize;

            Vector3 position = new Vector3(150, canvasDim.rect.height - 200, 0); ;

            m_descriptionPrefabContainer = Instantiate(m_descriptionPrefab, position, Quaternion.identity, GameManager.Instance.m_interfaceManager.transform);
            m_descriptionPrefabContainer.GetComponent<RessourceDescription>().Display(m_ressourceDescription);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(m_actualPrefab);

        if (m_descriptionIsDisplay)
        {
            Destroy(m_descriptionPrefabContainer);
            m_descriptionIsDisplay = false;
        }
    }
}
