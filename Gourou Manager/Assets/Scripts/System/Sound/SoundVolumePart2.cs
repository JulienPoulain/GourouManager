using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumePart2 : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float m_backgroundFloat, m_soundEffectFloat;
    
    public AudioSource m_backgroundAudio;
    public AudioSource[] m_soundEffectsAudio;
    
    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        m_backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        m_soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        Debug.Log(m_backgroundFloat);
        Debug.Log(m_soundEffectFloat);

        m_backgroundAudio.volume = m_backgroundFloat;
        foreach (AudioSource effect in m_soundEffectsAudio)
        {
            effect.volume = m_soundEffectFloat;
        }
    }
}
