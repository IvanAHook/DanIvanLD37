using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStaminaConsumable : Item
{

	public Sprite[] Sprites;
    public AudioClip eatSound;

	void Start ()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Length)];
	}

    private void OnMouseDown()
    {
        UseItem();
    }

    public override void UseItem()
    {
        Messenger<AudioClip>.Broadcast("PlaySound", eatSound);
        TurnManager.IncreaseStamina(1);
	    Messenger<Item>.Broadcast("removeItem", this);
    }
}
