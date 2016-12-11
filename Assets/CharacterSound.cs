using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterSound : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioClip[] cloth;
    private AudioSource _audioSource;

	// Use this for initialization
	void Start ()
	{
	    _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
