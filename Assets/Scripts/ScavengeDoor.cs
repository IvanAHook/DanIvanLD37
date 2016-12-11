using System.Collections;
using UnityEngine;

public class ScavengeDoor : InteractableItem
{

	public Transform Fade;
	public Inventory Inventory;

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
		var a = 0f;
		var color = _fadeSpriteRenderer.color;
		var textColor = _fadeTextSpriteRenderer.color;

		_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
		_fadeSpriteRenderer.enabled = true;

		yield return new WaitForSeconds(0.2f);

		while (a < 1)
		{

			_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			a += _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}

		_fadeTextSpriteRenderer.enabled = true;
		_fadeTextSpriteRenderer.color = new Color(color.r, color.g, color.b, 1f);

		yield return new WaitForSeconds(4f);

		TurnManager.NextDay();
		AquireItems();

		while (a > 0)
		{
			_fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			_fadeTextSpriteRenderer.color = new Color(color.r, color.g, color.b, a);

			a -= _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}
		_fadeTextSpriteRenderer.enabled = false;
		_fadeSpriteRenderer.enabled = false;
	}

	public void AquireItems()
	{
		Item[] items = new Item[4];
		var itemIds = TurnManager.GetItemsForDay();
		for (int i = 0; i < 4; i++)
		{
			items[i] = Instantiate(Inventory.GetItem(itemIds[i]), new Vector2(-1000, -1000), Quaternion.identity);
		}
		Inventory.SetItems(items);
	}

}
