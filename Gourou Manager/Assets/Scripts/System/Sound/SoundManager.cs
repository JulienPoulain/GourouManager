using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource m_audio;
    [SerializeField] private AudioSource m_click;

    public AudioSource Audio => m_audio;
    public AudioSource Click => m_click;

    private void Start()
    {
        if (m_audio == null)
        {
            m_audio = GameObject.Find("Music background").GetComponent<AudioSource>();
        }

        if (m_audio == null)
        {
            m_click = GameObject.Find("Click FeedBack").GetComponent<AudioSource>();
        }
    }

    public void ClickEffect()
    {
        m_click.Play();
    }
}
