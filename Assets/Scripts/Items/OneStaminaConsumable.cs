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

    private Vector3 _originalPosition;

	void Awake()
	{
	    _originalPosition = transform.position;
		_spriteRenderer = GetComponent<SpriteRenderer>();

		ItemSprite = Sprites[Random.Range(0, Sprites.Length)];
		_spriteRenderer.sprite = ItemSprite;
	}

    private void OnMouseDown()
    {
        //UseItem();
    }

    private void OnMouseDrag()
    {
        _spriteRenderer.sortingOrder = 1;
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnMouseUp()
    {
        _spriteRenderer.sortingOrder = 0;
        transform.position = _originalPosition;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null && hit.collider.GetComponent<Item>())
        {
            // combine item stuff here
            Debug.Log(hit.collider.name);
        }

        GetComponent<BoxCollider2D>().enabled = true;
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
