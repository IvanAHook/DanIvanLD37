using UnityEngine;

public class RadioInteractableItem : InteractableItem
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
