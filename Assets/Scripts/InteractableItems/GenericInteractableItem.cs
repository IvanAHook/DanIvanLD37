using UnityEngine;

public class GenericInteractableItem : InteractableItem
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
