using UnityEngine;
using UnityEngine.UI;

public class SoundVolumePart2 : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float m_backgroundFloat, m_soundEffectFloat;
    public Slider m_backgroundSlider, m_soundEffectSlider;
    
    public AudioSource m_backgroundAudio;
    public AudioSource[] m_soundEffectsAudio;
    
    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        m_backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        m_backgroundSlider.value = m_backgroundFloat;
        m_soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        m_soundEffectSlider.value = m_soundEffectFloat;

        m_backgroundAudio.volume = m_backgroundFloat;
        foreach (AudioSource effect in m_soundEffectsAudio)
        {
            effect.volume = m_soundEffectFloat;
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
