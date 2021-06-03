using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionVisualTransition : MonoBehaviour
{
    private MaterialPropertyBlock m_mpb;
    private float m_corruptionLevel;
    [SerializeField] private Renderer m_renderer;
    private DecaySO m_decay;
    
    private void Awake()
    {
        m_decay = gameObject.GetComponentInParent<InstitutionScript>().m_Institution.Decay;
        m_mpb = new MaterialPropertyBlock();
    }

    void OnEnable()
    {
        m_decay.onValueChanged += HandleDecayChanged;
        
        Conversion();
    }

    private void OnDisable()
    {
        m_decay.onValueChanged -= HandleDecayChanged;
    }

    private void Conversion()
    {
        //calcul : (decay/(range de decay/range de _corruptionLevel)) - offset de la corruption
        //A modifier si les range et offset sont modifiés
        m_corruptionLevel = m_decay.Value / 62.5f - 1.6f;
        m_mpb.SetFloat("_corruptionLevel", m_corruptionLevel);
        m_renderer.SetPropertyBlock(m_mpb);
    }
    
    private void HandleDecayChanged(int p_value)
    {
        Conversion();
    }
}
