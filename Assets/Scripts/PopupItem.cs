using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupItem : MonoBehaviour
{

	public Transform DisplayItem;

	public void Interract()
	{
		if (!DisplayItem.gameObject.activeSelf)
		{
			DisplayItem.gameObject.SetActive(true);
		}
	}

}
