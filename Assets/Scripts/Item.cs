using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	public abstract int SpriteId { get; set; }

	public abstract void UseItem();

    private void OnMouseDown()
    {
        UseItem();
    }

	public abstract void SetSprite(int id);

}
