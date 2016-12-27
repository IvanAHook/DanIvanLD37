using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ScavengeDoor : InteractableItem
{

	public Transform Fade;
	public Inventory Inventory;

	public Sprite[] FadeTextArray;

	public Sprite[] DayNumberTextArray;

	public AudioMixerSnapshot roomSnapshot;
    public AudioMixerSnapshot transitionSnapshot;
    public AudioClip[] transitions;
    public AudioClip deathMusic;

	private float _fadeSpeed = 0.01f;
	private float _dayFadeSpeed = 0.005f;
	private SpriteRenderer _fadeSpriteRenderer;
	private SpriteRenderer _fadeTextSpriteRenderer;
	private AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public override void Interract()
	{
		_fadeSpriteRenderer = Fade.GetComponent<SpriteRenderer>();
		_fadeTextSpriteRenderer = Fade.FindChild("FadeText").GetComponent<SpriteRenderer>();
		StartCoroutine(SmoothFade());
	}

	private IEnumerator SmoothFade( )
	{
		_audioSource.Play();
	    var a = 0f;
		var color = _fadeSpriteRenderer.color;
		var textColor = _fadeTextSpriteRenderer.color;

		_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
	    Fade.gameObject.SetActive(true);

		yield return new WaitForSeconds(0.2f);

        transitionSnapshot.TransitionTo(3f);

		while (a < 1)
		{

			_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			a += _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}

		SetFadeMessage();
		_fadeTextSpriteRenderer.enabled = true;
		_fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, 1);

	    Messenger.Broadcast("KillRadio");

		var p = _audioSource.panStereo;
		_audioSource.panStereo = 0;

		if (TurnManager.Stamina - 4 < 0)
	    {
		    _audioSource.PlayOneShot(deathMusic, 3f);
		    TurnManager.ResetToLastDay();
	    }
	    else
	    {
		    _audioSource.PlayOneShot(transitions[Random.Range(0,transitions.Length-1)], 3f);
		    TurnManager.NextDay();

	    }
	    yield return new WaitForSeconds(6f);
	    roomSnapshot.TransitionTo(2f);

		while (a > 0)
		{
			_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			_fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, a);

			a -= _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}

		a = 1.2f;
		_fadeTextSpriteRenderer.sprite = DayNumberTextArray[TurnManager.CurrentDay - 1];
		while (a > 0)
		{
			_fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, Mathf.Clamp01(a));

			a -= _dayFadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}


		_fadeTextSpriteRenderer.enabled = false;
		Fade.gameObject.SetActive(false);
		_audioSource.panStereo = p;
	}

	private void SetFadeMessage()
	{
		if (TurnManager.Stamina < 4)
		{
			_fadeTextSpriteRenderer.sprite = FadeTextArray[1];
			return;
		}

		_fadeTextSpriteRenderer.sprite = FadeTextArray[0];
	}

}
