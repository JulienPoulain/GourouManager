using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextExactionPanel : MonoBehaviour
{
    [SerializeField] GameObject m_textContainer;
    [SerializeField] GameObject m_textEndTurnEventPrefab;

    [SerializeField] private List<GameObject> m_objectEventList = new List<GameObject>();

    public void Display(List<EventSO> p_eventList)
    {
        DestroyAll();

        for (int i = 0; i < p_eventList.Count; i++)
        {
            if (p_eventList[i].IsDisplayed == true)
            {
                // on instancie un GO contenant 2 textes en fils de m_textContainer pour qu'il se mette � la suite sans faire d'histoire
                GameObject text = Instantiate(m_textEndTurnEventPrefab, Vector3.zero, Quaternion.identity, m_textContainer.transform);

                m_objectEventList.Add(text);

                // On va chercher les 2 textes pour les changer
                List<TMP_Text[]> m_textList = new List<TMP_Text[]>();
                m_textList.Add(text.GetComponentsInChildren<TMP_Text>());

                m_textList[m_textList.Count - 1][0].text = "" + p_eventList[i].Name;
                m_textList[m_textList.Count - 1][1].text = "" + p_eventList[i].Description;
            }

        }
    }

    public void DestroyAll()    // Appeler lorsque le joueur quitte l'interface
    {
        // Pour remettre la liste � 0, on d�truit tous les Objets avant de clear la list
        foreach (GameObject thisObject in m_objectEventList)
        {
            Destroy(thisObject);
        }
        m_objectEventList.Clear();
    }
}
