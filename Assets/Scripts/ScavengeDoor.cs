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

	public AudioMixerSnapshot RoomSnapshot;
    public AudioMixerSnapshot TransitionSnapshot;
    public AudioClip[] Transitions;
    public AudioClip DeathMusic;

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
		var color = _fadeSpriteRenderer.color;
		var textColor = _fadeTextSpriteRenderer.color;
	    var p = _audioSource.panStereo;

	    _fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, 0);
	    Fade.gameObject.SetActive(true);

		yield return new WaitForSeconds(0.2f);

		yield return StartCoroutine(FadeIn(color, textColor));

	    StartTransitionSFX();

	    yield return new WaitForSeconds(6f);

		yield return StartCoroutine(FadeOut(color, textColor));

		yield return StartCoroutine(DayText(textColor));


		_fadeTextSpriteRenderer.enabled = false;
		Fade.gameObject.SetActive(false);
		_audioSource.panStereo = p;
	}

    private void StartTransitionSFX()
    {
		_audioSource.panStereo = 0;

		if (TurnManager.Stamina - 4 < 0)
	    {
		    _audioSource.PlayOneShot(DeathMusic, 3f);
		    TurnManager.ResetToLastDay();
	    }
	    else
	    {
		    _audioSource.PlayOneShot(Transitions[Random.Range(0,Transitions.Length-1)], 3f);
		    TurnManager.NextDay();
	    }
    }

    private IEnumerator FadeIn(Color color, Color textColor)
    {
        TransitionSnapshot.TransitionTo(3f);

        var duration = 0f;
        while (duration < 1)
        {

            _fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, duration);
            duration += _fadeSpeed;
            yield return new WaitForSeconds(0.01f);
        }

        SetFadeMessage();
        _fadeTextSpriteRenderer.enabled = true;
        _fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, 1);
        Messenger.Broadcast("KillRadio");
    }

    private IEnumerator FadeOut(Color color, Color textColor)
    {
        RoomSnapshot.TransitionTo(2f);

        var duration = 1f;
        while (duration > 0)
        {
            _fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, duration);
            _fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, duration);

            duration -= _fadeSpeed;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator DayText(Color textColor)
    {
        var duration = 1.2f;
        _fadeTextSpriteRenderer.sprite = DayNumberTextArray[TurnManager.CurrentDay - 1];
        while (duration > 0)
        {
            _fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, Mathf.Clamp01(duration));

            duration -= _dayFadeSpeed;
            yield return new WaitForSeconds(0.01f);
        }


        _fadeTextSpriteRenderer.enabled = false;
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
