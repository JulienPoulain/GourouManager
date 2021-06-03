using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightHovers : MonoBehaviour
{
    [SerializeField] private List<Outline> m_hovers;

    // Start is called before the first frame update
    void Start()
    {
        DesableOutline();
    }

    public void DesableOutline()
    {
        foreach (Outline hover in m_hovers)
        {
            hover.OutlineColor = Color.clear;
        }
    }
}
