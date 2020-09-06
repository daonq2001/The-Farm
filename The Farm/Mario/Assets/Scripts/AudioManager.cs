using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject audioSource;

    public AudioClip coin;
    private AudioSource coinSource;
    public AudioClip win;
    private AudioSource winSource;
    public AudioClip die;
    private AudioSource dieSource;

    void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip clip, float volume, bool isLoopback)
    {

    }
}
