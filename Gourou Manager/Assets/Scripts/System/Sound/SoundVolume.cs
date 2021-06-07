
using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int m_firstPlayInt;
    public Slider m_backgroundSlider, m_soundEffectSlider;
    private float m_backgroundFloat, m_soundEffectFloat;
    
    public AudioSource m_backgroundAudio;
    public AudioSource[] m_soundEffectsAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (m_firstPlayInt == 0)
        {
            m_backgroundFloat = .5f;
            m_soundEffectFloat = .5f;
            m_backgroundSlider.value = m_backgroundFloat;
            m_soundEffectSlider.value = m_soundEffectFloat;
            PlayerPrefs.SetFloat(BackgroundPref, m_backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, m_soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            m_backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            m_backgroundSlider.value = m_backgroundFloat;
            m_soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            m_soundEffectSlider.value = m_soundEffectFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, m_backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, m_soundEffectSlider.value);
    }

    //sauvegarde les paramettres si on quitte la fenetre du jeu
    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        m_backgroundAudio.volume = m_backgroundSlider.value;
        foreach (AudioSource effect in m_soundEffectsAudio)
        {
            effect.volume = m_soundEffectSlider.value;
        }
        
    }
}
