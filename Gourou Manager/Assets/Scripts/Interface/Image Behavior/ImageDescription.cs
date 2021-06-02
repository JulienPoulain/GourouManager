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

    // Stocke le GO instancier pour le d�truire
    TMP_Text m_actualPrefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        string message = "";
        switch (m_ressourceName)
        {
            case RessourceType.Founds:
                message = "Fonds : Les fonds permettent de réaliser certaines éxactions telles que soudoyer. " +
                          "Chaque institution possède ses propres fonds qui leur permettent de lancer des évènements pour ou contre le culte";
                break;
            case RessourceType.Membres:
                message = "Membres : Les membres sont votre condition de victoire, obtenez en 100 pour gagner la partie. Votre impact sur la population ainsi que celle des institutions font varier leur nombre ";
                break;
            case RessourceType.Fanatiques:
                message = "Points de fanatisme : Les points de fanatisme sont utilisés pour lancer certaines éxactions, ils ont beaucoup de valeur et sont relativement difficile à obtenir ";
                break;
            case RessourceType.Tour:
                message = "Jour : ";
                break;
            case RessourceType.ExpositionPublic:
                message = "Exposition Publique : L'exposition publique représente la façon dont l'institution est perçue par la population, plus elle est élevée et plus l'institution est connue et bien vue, elle est également souvent requise pour accèder a certain interlocuteurs";
                break;
            case RessourceType.Corruption:
                message = "Corruption : La corruption d'une institution représente sa dévotion au culte et impact directement le statut de l'institution à son égard, plus elle est élevée plus l'institution sera amicale  ";
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
