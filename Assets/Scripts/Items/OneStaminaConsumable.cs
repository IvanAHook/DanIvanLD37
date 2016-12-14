using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStaminaConsumable : Item
{
	private SpriteRenderer _spriteRenderer;

	public Sprite[] Sprites;
    public AudioClip eatSound;

	public override Sprite ItemSprite { get; set; }

	public override ItemType Type
	{
		get { return ItemType.OneStaminaConsumable; }
		protected set { }
	}

	void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();

		ItemSprite = Sprites[Random.Range(0, Sprites.Length)];
		_spriteRenderer.sprite = ItemSprite;
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

	public override void SetSprite(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
	}
}
