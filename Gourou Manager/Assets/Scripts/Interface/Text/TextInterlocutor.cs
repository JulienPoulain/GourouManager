using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInterlocutor : MonoBehaviour
{
    [SerializeField] GameObject m_TextMeshPrefab;
    
    [Tooltip("Les texts seront créer petit à petit, on a besoin de la position du premier")]
    [SerializeField] private Vector3 m_firstTextPos;

    [Tooltip("Decallage entre 2 Textes")]
    [SerializeField] private float m_distance = 5f;
    
    private List<GameObject> m_Prefabs;
    
    
    void Display(InterlocutorSO p_data)
    {
        GameObject instance = Instantiate(m_TextMeshPrefab, m_firstTextPos, Quaternion.identity);
        instance.GetComponent<TextMeshPro>();
        
        m_Prefabs.Add(instance);
        m_firstTextPos.y += m_distance;
    }

}
