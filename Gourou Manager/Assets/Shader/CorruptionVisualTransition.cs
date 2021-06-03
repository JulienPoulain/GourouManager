using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionVisualTransition : MonoBehaviour
{
    private MaterialPropertyBlock m_mpb;
    private float m_corruptionLevel;
    [SerializeField] private Renderer m_renderer;
    [SerializeField] private InstitutionSO m_institution;
    
    void OnEnable()
    {
        if (m_institution == null) Debug.Log($"<color=red>ERROR :</color> {m_renderer.name} institution manquante dans CVT.");
        else
        {
            m_corruptionLevel = 0;
            m_mpb = new MaterialPropertyBlock();
            m_mpb.SetFloat ("_corruptionLevel", m_corruptionLevel);
            m_renderer.SetPropertyBlock (m_mpb);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (m_institution != null)
        {
            //calcul : (decay/(range de decay/range de _corruptionLevel)) - offset de la corruption
            //A modifier si les range et offset sont modifiés
            m_corruptionLevel = (m_institution.Decay.Value / 50) - 2;
            m_mpb.SetFloat("_corruptionLevel", m_corruptionLevel);
            m_renderer.SetPropertyBlock(m_mpb);
        }
    }
}
