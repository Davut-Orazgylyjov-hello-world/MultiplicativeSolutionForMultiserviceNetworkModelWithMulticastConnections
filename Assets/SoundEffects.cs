using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects soundEffects;
    
    public AudioClip error;
    public AudioClip connection;
    
    
    private AudioSource _audioSource;

    private void Awake()
    {
        soundEffects = this;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayError()
    {
        _audioSource.clip = error;
        _audioSource.Play();
    }
    
    public void PlayConnection()
    {
        _audioSource.clip = connection;
        _audioSource.Play();
    }
}
