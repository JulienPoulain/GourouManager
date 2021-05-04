using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class TextContainer : MonoBehaviour
{
    [SerializeField] GameObject[] m_TextTable;
    public List<TextMesh> m_TextList;

    private void Awake() 
    {        
        foreach(GameObject Object in m_TextTable)   
        {
            m_TextList.Add(Object.GetComponent<TextMesh>());
        }
    }
}
