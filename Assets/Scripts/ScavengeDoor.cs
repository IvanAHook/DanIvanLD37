using System.Collections;
using UnityEngine;

public class ScavengeDoor : InteractableItem
{

	public Transform Fade;
	public Inventory Inventory;
	private float _fadeSpeed = 0.01f;

	public override void Interract()
	{
		var fadeSpriteRenderer = Fade.GetComponent<SpriteRenderer>();
		StartCoroutine(SmoothFade(fadeSpriteRenderer));
	}

	private IEnumerator SmoothFade(SpriteRenderer fadeSpriteRenderer)
	{
		var a = 0f;
		var color = fadeSpriteRenderer.color;

		fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
		fadeSpriteRenderer.enabled = true;

		yield return new WaitForSeconds(0.2f);

		while (a < 1)
		{

			fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			a += _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}

		yield return new WaitForSeconds(2f);
		AquireItems();

		while (a > 0)
		{

			fadeSpriteRenderer.color = new Color(color.r, color.g, color.b, a);
			a -= _fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}
		fadeSpriteRenderer.enabled = false;
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
