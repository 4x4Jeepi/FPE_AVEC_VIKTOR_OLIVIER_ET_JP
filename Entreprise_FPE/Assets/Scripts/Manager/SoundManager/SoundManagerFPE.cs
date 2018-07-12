/*
Simple Sound Manager (c) 2016 Digital Ruby, LLC
http://www.digitalruby.com

Source code may no longer be redistributed in source format. Using this in apps and games is fine.
*/

using UnityEngine;
using UnityEngine.UI;

using System.Collections;

// Be sure to add this using statement to your scripts
// using DigitalRuby.SoundManagerNamespace

namespace DigitalRuby.SoundManagerNamespace
{
    public class SoundManagerFPE : MonoBehaviour
    {
        public static SoundManagerFPE m_Instance { get; set; }

        public Slider m_SoundSlider;
        public Slider m_MusicSlider;

        public float m_MusicVolume;

        public AudioSource[] m_SoundAudioSources;
        public AudioSource[] m_MusicAudioSources;

        public GameObject m_SoundOnObject;


        private void PlaySound(int index)
        {
                m_SoundAudioSources[index].PlayOneShotSoundManaged(m_SoundAudioSources[index].clip);
        }

        public void PlayMusic(int index)
        {
            m_MusicAudioSources[index].PlayLoopingMusicManaged(1.0f, 1.0f, false);
        }

        private void CheckPlayKey()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlayMusic(0);
            }
        }

        public void PlayASound(int a_index)
        {
            PlaySound(a_index);
        }

        private void Start()
        {
            SoundManager.MusicVolume = 0;

            if (m_Instance == null)
            {
                m_Instance = this;
                DigitalRuby.SoundManagerNamespace.SoundManagerFPE.m_Instance.m_MusicAudioSources[0].Play();
            }
            else
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            CheckPlayKey();
        }

        public void SoundVolumeChanged()
        {
            SoundManager.SoundVolume = m_SoundSlider.value;
        }

        public void MusicVolumeChanged()
        {
            SoundManager.MusicVolume = m_MusicSlider.value;
        }

        public void FadeInMusic() {

            if(SoundManager.MusicVolume < 1) {

                SoundManager.MusicVolume += 0.1f * Time.deltaTime;
            }
        }

        public void FadeOutMusic() {
            if (SoundManager.MusicVolume > 0) {

                SoundManager.MusicVolume -= 0.1f * Time.deltaTime;
            }
        }
    }
}
