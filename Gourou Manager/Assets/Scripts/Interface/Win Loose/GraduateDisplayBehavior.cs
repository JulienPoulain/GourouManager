using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduateDisplayBehavior : MonoBehaviour
{
    [SerializeField] List<GradiateDiplay> m_graduateDispalyScriptList = new List<GradiateDiplay>();
    [SerializeField] float m_intervalDisplayTime;

    private bool m_coroutineHasFinish = false;

    public bool CoroutineHasFinish => m_coroutineHasFinish;

    void Start()
    {
        m_coroutineHasFinish = false;
        StartCoroutine(InterfaceDisplay());
    }

    /// <summary>
    /// Permet d'afficher par intervalle les Go contenant un script GradiateDiplay lier
    /// </summary>
    public void Display()
    {
        StartCoroutine(InterfaceDisplay());
    }

    /// <summary>
    /// Affiche par intervale les éléments
    /// </summary>
    /// <returns></returns>
    IEnumerator InterfaceDisplay()
    {
        foreach(GradiateDiplay script in m_graduateDispalyScriptList)
        {
            script.Display();
            yield return new WaitForSeconds(m_intervalDisplayTime);
        }

        m_coroutineHasFinish = true;
    }
}
