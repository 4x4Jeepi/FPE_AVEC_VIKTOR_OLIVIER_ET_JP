using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnObject : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioSource m_AudioSourceToCopy;
    [SerializeField] private float m_MinValue;
    [SerializeField] private float m_MaxValue;

    public void OnInit(float a_MinValue, float a_MaxValue)
    {
        m_MinValue = a_MinValue;
        m_MaxValue = a_MaxValue;

        m_AudioSourceToCopy = DigitalRuby.SoundManagerNamespace.SoundManagerFPE.m_Instance.m_SoundAudioSources[(int)Random.Range(m_MinValue, m_MaxValue)];

        m_AudioSource.clip = m_AudioSourceToCopy.clip;
        m_AudioSource.spatialBlend = m_AudioSourceToCopy.spatialBlend;

        StartCoroutine(PlayerSound());
    }
    private IEnumerator PlayerSound()
    {
        m_AudioSource.Play();
        yield return new WaitForSeconds(m_AudioSource.clip.length);
        Destroy(this.gameObject);
    }

    public void DisplayName()
    {
        Debug.Log(this.gameObject.name);
    }

    public void SetVolume(float a_Volume) 
    {
        m_AudioSource.volume = a_Volume;
    }
}
