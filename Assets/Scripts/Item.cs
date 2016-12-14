using UnityEngine;

public abstract class Item : MonoBehaviour
{
	public abstract Sprite ItemSprite { get; set; }
	public abstract ItemType Type { get; protected set; }

	public abstract void UseItem();

    private void OnMouseDown()
    {
        UseItem();
    }

	public abstract void SetSprite(Sprite sprite);


}
