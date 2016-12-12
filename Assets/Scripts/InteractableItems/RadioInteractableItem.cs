using UnityEngine;

public class RadioInteractableItem : InteractableItem
{

    public AudioClip staticNoVoices;
    public AudioClip staticVoices;
    public AudioClip switchOn;
    public AudioClip switchOff;

    private AudioSource _audioSource;
    private AudioClip _currentClip;
    private bool _isActuallyPlaying;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = staticNoVoices;
    }

	public override void Interract()
	{
        if (TurnManager.CurrentDay >= 4)
	    {
	        _currentClip = staticVoices;
	    }
	    else
	    {
	        _currentClip = staticNoVoices;
	    }

	    _audioSource.clip = _currentClip;

	    if (_isActuallyPlaying)
	    {
	        _audioSource.Stop();
	        _audioSource.PlayOneShot(switchOff, 3f);
	        _isActuallyPlaying = false;
	    }
	    else
	    {
	        _audioSource.PlayOneShot(switchOn,3f);
	        _audioSource.clip = _currentClip;
	        _audioSource.time = Random.Range(0, _currentClip.length-0.1f);
	        _audioSource.loop = true;
	        _audioSource.Play();
	        _isActuallyPlaying = true;
	    }
	}
}
