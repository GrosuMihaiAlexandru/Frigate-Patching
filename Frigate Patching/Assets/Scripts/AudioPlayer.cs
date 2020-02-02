using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip fireSounds;
    public AudioClip explosionSound;
    public AudioClip coin;
    public AudioClip repair;
    public AudioClip crash;
    public AudioClip lightning;

    public static AudioPlayer Instance;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayExplosion()
    {
        audioSource.clip = explosionSound;
        audioSource.Play();
    }

    public void PlayFire()
    {
        audioSource.clip = fireSounds;
        audioSource.Play();
    }

    public void PlayCoin()
    {
        audioSource.clip = coin;
        audioSource.Play();
    }

    public void PlayRepair()
    {
        audioSource.clip = repair;
        audioSource.Play();
    }

    public void PlayCrash()
    {
        audioSource.clip = crash;
        audioSource.Play();
    }

    public void PlayLightning()
    {
        audioSource.clip = lightning;
        audioSource.Play();
    }
}
