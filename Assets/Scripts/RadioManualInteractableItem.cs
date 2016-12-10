using UnityEngine;

public class RadioManualInteractableItem : InteractableItem
{

	public Transform DisplayItem;

	public override void Interract()
	{
		if (!DisplayItem.gameObject.activeSelf)
		{
			DisplayItem.gameObject.SetActive(true);
		}
	}

}
