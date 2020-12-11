using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClips;


    public enum Sound
    {
        BGM,
        Fire,
        Water,
        Wind,
        Rock,
        FireCharge,
        Victory,
        Key,
        Door,
        Mana,
        Pause,
        Jump,
        Splash
    }


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        
    }

    private void Update()
    {
        audioSource.volume = 0.1f;
    }

    public void playSound(Sound sound)
    {
        switch (sound)
        {
            case Sound.BGM:
                audioSource.Pause();
                audioSource.clip = audioClips[0];
                audioSource.Play();
                break;
            case Sound.Fire:
                audioSource.PlayOneShot(audioClips[1]);
                break;
            case Sound.Water:
                audioSource.PlayOneShot(audioClips[2]);
                break;
            case Sound.Wind:
                audioSource.PlayOneShot(audioClips[3]);
                break;
            case Sound.Rock:
                audioSource.PlayOneShot(audioClips[4]);
                break;
            case Sound.Victory:
                audioSource.Stop();
                audioSource.clip = audioClips[5];
                audioSource.Play();
                break;
            case Sound.Key:
                audioSource.PlayOneShot(audioClips[6]);
                break;
            case Sound.Mana:
                audioSource.PlayOneShot(audioClips[7]);
                break;
            case Sound.Pause:
                audioSource.Pause();
                break;
            case Sound.Door:
                audioSource.PlayOneShot(audioClips[8]);
                break;
            case Sound.Splash:
                audioSource.PlayOneShot(audioClips[9]);
                break;
            case Sound.Jump:
                audioSource.PlayOneShot(audioClips[10]);
                break;
        }
       
    }
}



