using UnityEngine;

public class CampfireInteractableItem : InteractableItem
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
