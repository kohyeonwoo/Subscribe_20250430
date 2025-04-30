using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSound;
    public Sound[] effectSound;

    public AudioSource musicSource;
    public AudioSource effectSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSound, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("해당 배경음을 찾지 못했습니다.");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(effectSound, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("해당 효과음을 찾지 못했습니다.");
        }
        else
        {
            effectSource.PlayOneShot(sound.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        effectSource.mute = !effectSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        effectSource.volume = volume;
    }

}
