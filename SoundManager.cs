using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource musicAudioSource;
    public AudioSource fxSoundsAudioSource;

    private void Awake()
    {
        Instance = this;

        if (musicAudioSource == null)
        {
            musicAudioSource = gameObject.AddComponent<AudioSource>();
        }

        if (fxSoundsAudioSource == null)
        {
            fxSoundsAudioSource = gameObject.AddComponent<AudioSource>();
            fxSoundsAudioSource.playOnAwake = false;
            fxSoundsAudioSource.loop = false;
        }
    }

    public void PlayMusic(Sound sound)
    {
        musicAudioSource.clip = sound.clip;
        musicAudioSource.volume = sound.volume;
        musicAudioSource.loop = sound.loop;
        musicAudioSource.Play();
    }

    public void PlayFxSound(Sound sound)
    {
        fxSoundsAudioSource.clip = sound.clip;
        fxSoundsAudioSource.volume = sound.volume;
        fxSoundsAudioSource.Play();
    }
}
