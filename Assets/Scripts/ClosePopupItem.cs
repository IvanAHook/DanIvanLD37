using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopupItem : MonoBehaviour {

	public Transform DisplayItem;

	private void OnMouseDown()
	{
		if (DisplayItem.gameObject.activeSelf)
		{
			DisplayItem.gameObject.SetActive(false);
		}
	}
}
