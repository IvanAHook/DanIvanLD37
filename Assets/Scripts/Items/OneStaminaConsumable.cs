using UnityEngine;
using UnityEngine.UI;

public class OneStaminaConsumable : Item
{
//	private SpriteRenderer _spriteRenderer;

	public Sprite[] Sprites;
    public AudioClip eatSound;

	public override ItemData Data { get; protected set; }

	public override void Create()
	{
		Data = new ItemData
		{
			Type = ItemType.OneStaminaConsumable,
			ItemSprite = Sprites[Random.Range(0, Sprites.Length)]
		};
		GetComponent<Image>().sprite = Data.ItemSprite;
	}

	public override void SetSprite(Sprite sprite)
	{
        Data.ItemSprite = sprite;
		GetComponent<Image>().sprite = Data.ItemSprite;
	}

//    private Vector3 _originalPosition;
//
//	void Awake()
//	{
//		Data.ItemSprite = Sprites[Random.Range(0, Sprites.Length)];
//	}
//
//    private void OnMouseDown()
//    {
//        //UseItem();
//    }
//
//    private void OnMouseDrag()
//    {
//        _spriteRenderer.sortingOrder = 1;
//        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        GetComponent<BoxCollider2D>().enabled = false;
//    }
//
//    private void OnMouseUp()
//    {
//        _spriteRenderer.sortingOrder = 0;
//        transform.position = _originalPosition;
//
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
//
//        if (hit.collider != null && hit.collider.GetComponent<Item>())
//        {
//            // combine item stuff here
//            Debug.Log(hit.collider.name);
//        }
//
//        GetComponent<BoxCollider2D>().enabled = true;
//    }

}
