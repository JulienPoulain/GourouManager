using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource m_audio;
    [SerializeField] private AudioClip m_click;

    public AudioSource Audio => m_audio;
    public AudioClip Click => m_click;

    private void Start()
    {
        if (m_audio == null)
        {
            m_audio = GameObject.Find("Music background").GetComponent<AudioSource>();
        }
    }
}
