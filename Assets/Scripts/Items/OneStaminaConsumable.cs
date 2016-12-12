using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStaminaConsumable : Item
{

	public Sprite[] Sprites;

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
	    TurnManager.IncreaseStamina(1);
	    Messenger<Item>.Broadcast("removeItem", this);
    }
}
