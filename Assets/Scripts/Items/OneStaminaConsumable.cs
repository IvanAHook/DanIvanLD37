using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneStaminaConsumable : Item {

	void Start ()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void OnMouseDown()
    {
        UseItem();
    }

    public override void UseItem()
    {
        Debug.Log("CARROT!");
	    TurnManager.IncreaseStamina(1);
	    Messenger<Item>.Broadcast("removeItem", this);
    }
}
