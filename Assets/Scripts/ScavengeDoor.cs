using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ScavengeDoor : InteractableItem
{

	public Transform Fade;
	public Inventory Inventory;

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
	    Fade.gameObject.SetActive(true);

		yield return new WaitForSeconds(0.2f);

        transitionSnapshot.TransitionTo(3f);

		while (a < 1)
		{

			_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			a += _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}

		_fadeTextSpriteRenderer.enabled = true;
	    var p = audioSource.panStereo;
	    audioSource.panStereo = 0;
	    audioSource.PlayOneShot(transitions[Random.Range(0,transitions.Length-1)], 3f);
	    yield return new WaitForSeconds(6f);
	    roomSnapshot.TransitionTo(2f);


	    AquireItems();
	    while (a > 0)
		{
			_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			_fadeTextSpriteRenderer.color = new Color(textColor.r, textColor.g, textColor.b, a);

			a -= _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}


		_fadeTextSpriteRenderer.enabled = false;
        Fade.gameObject.SetActive(false);
	    audioSource.panStereo = p;
	}

	public void AquireItems()
	{
		Item[] items = new Item[4];
		for (int i = 0; i < 4; i++)
		{
			items[i] = Instantiate(Inventory.GetItem(1), new Vector2(-1000, -1000), Quaternion.identity);
		}
		Inventory.SetItems(items);
	}
}
