using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStaminaConsumable : Item
{

	private SpriteRenderer _spriteRenderer;

	public Sprite[] Sprites;

	public override int SpriteId { get; set; }

	void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();

		SpriteId = Random.Range(0, Sprites.Length);
		_spriteRenderer.sprite = Sprites[SpriteId];
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

	public override void SetSprite(int id)
	{
		_spriteRenderer.sprite = Sprites[id];
	}
}
