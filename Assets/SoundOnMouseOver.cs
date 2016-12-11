using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnMouseOver : MonoBehaviour
{

    public GameObject nonDiegeticSource;
    public AudioClip sound;
    private AudioSource _audioSource;

	// Use this for initialization
	void Start ()
	{
	    _audioSource = nonDiegeticSource.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        _audioSource.PlayOneShot(sound,1);
    }
}
