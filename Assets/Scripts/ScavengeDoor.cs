using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ScavengeDoor : InteractableItem
{

	public Transform Fade;
	public Inventory Inventory;

	public Sprite[] FadeTextArray;

    public AudioMixerSnapshot roomSnapshot;
    public AudioMixerSnapshot transitionSnapshot;
    public AudioClip[] transitions;

	private float _fadeSpeed = 0.01f;
	private SpriteRenderer _fadeSpriteRenderer;
	private SpriteRenderer _fadeTextSpriteRenderer;

	public override void Interract()
	{
		_fadeSpriteRenderer = Fade.GetComponent<SpriteRenderer>();
		_fadeTextSpriteRenderer = Fade.FindChild("FadeText").GetComponent<SpriteRenderer>();

		StartCoroutine(SmoothFade());
	}

	private IEnumerator SmoothFade( )
	{
	    var audioSource = GetComponent<AudioSource>();
	    audioSource.Play();
	    var a = 0f;
		var color = _fadeSpriteRenderer.color;
		var textColor = _fadeTextSpriteRenderer.color;

		_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
		_fadeSpriteRenderer.enabled = true;

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

		var p = audioSource.panStereo;
	    audioSource.panStereo = 0;
	    audioSource.PlayOneShot(transitions[Random.Range(0,transitions.Length-1)], 3f);
	    roomSnapshot.TransitionTo(6f);
	    yield return new WaitForSeconds(6f);

		TurnManager.NextDay();
		AquireItems();
	    while (a > 0)
		{
			_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			_fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, a);

			a -= _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}


		_fadeTextSpriteRenderer.enabled = false;
		_fadeSpriteRenderer.enabled = false;
	    audioSource.panStereo = p;
	}

	private void SetFadeMessage()
	{
		if (TurnManager.Stamina < 1)
		{
			_fadeTextSpriteRenderer.sprite = FadeTextArray[1];
			return;
		}

		_fadeTextSpriteRenderer.sprite = FadeTextArray[0];
	}

	private void AquireItems()
	{
		var itemsList = new Item[4];
		var newItems = TurnManager.GetItemsForDay();

		for (int i = 0; i < 4; i++)
		{
			itemsList[i] = Instantiate(Inventory.GetItem(newItems[i]), new Vector2(-1000, -1000), Quaternion.identity);
		}
		Inventory.SetItems(itemsList);
	}
}
