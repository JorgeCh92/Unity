using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public enum TypeOfSound
    {
        Music, FxSound
    }

    public TypeOfSound typeOfSound;
    public Sound sound;


    void Start()
    {
        if (typeOfSound == TypeOfSound.Music)
        {
            SoundManager.Instance.PlayMusic(sound);
        }
    }

    public void PlayFxSound()
    {
        SoundManager.Instance.PlayFxSound(sound);
    }
}
