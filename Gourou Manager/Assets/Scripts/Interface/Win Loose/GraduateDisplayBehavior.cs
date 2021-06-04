using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduateDisplayBehavior : MonoBehaviour
{
    [SerializeField] List<GradiateDiplay> m_graduateDispalyScriptList = new List<GradiateDiplay>();
    [SerializeField] float m_intervalDisplayTime;

    void Start()
    {
        StartCoroutine(InterfaceDisplay());
    }

    IEnumerator InterfaceDisplay()
    {
        foreach(GradiateDiplay script in m_graduateDispalyScriptList)
        {
            script.Display();
            yield return new WaitForSeconds(m_intervalDisplayTime);
        }
    }
}
