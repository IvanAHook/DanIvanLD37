﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterSound : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioClip[] cloth;
    public AudioClip action;
    private AudioSource _audioSource;
    public AudioSource nonDiegeticSource;

	void Start ()
	{
	    _audioSource = GetComponent<AudioSource>();
	}

    private void OnEnable()
    {
        Messenger<AudioClip>.AddListener("PlaySound", PlaySound);
    }

    public void PlayFootStep()
    {
        int i = Random.Range(0, 9);
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.PlayOneShot(footsteps[i],1);
    }

    public void PlayCloth()
    {
        int i = Random.Range(0, 6);
        _audioSource.pitch = 1;
        _audioSource.PlayOneShot(cloth[i],1);
    }

    public void PlayAction()
    {
        nonDiegeticSource.PlayOneShot(action);
    }

    public void PlaySound(AudioClip sound)
    {
        _audioSource.PlayOneShot(sound, 2f);
    }
}
