using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public static class TurnManager
{
	public const int MaxTurns = 8;
	public static int Stamina { get; private set; }
	private static int _staminaAtStartOfDay;

	public static int CurrentDay { get; private set; }

	public static void Initialize()
	{
		CurrentDay = 0;
		InitializeDay();
	}

	public static void IncreaseStamina(int amount)
	{
		Stamina += amount;
	}

	public static void NextDay()
	{
		CurrentDay += 1;
		//Messenger.Broadcast("newDay");
		InitializeDay();
	}

	public static void ResetToLastDay()
	{
		Stamina = _staminaAtStartOfDay;
		Messenger.Broadcast("resetItemsToLastDay");
	}

	private static void InitializeDay()
	{
		if (CurrentDay == 0)
		{
			Stamina = 7;
		}
		else
		{
			Stamina -= 4;
		}

		_staminaAtStartOfDay = Stamina;
		if (Stamina >= 0)
		{
			Messenger.Broadcast("aquireItems");
		}
	}

	public static ItemType[] GetItemsForDay()
	{
		ItemType[] items = new ItemType[4];

		switch (CurrentDay)
		{
			case 0:
				items = new ItemType[] {ItemType.OneStaminaConsumable};
				break;
			case 1:
				items = new ItemType[1] {ItemType.OneStaminaConsumable};
				break;
			case 2:
				items = new ItemType[3] {ItemType.OneStaminaConsumable, ItemType.OneStaminaConsumable, ItemType.OneStaminaConsumable};
				break;
			case 3:
				items = new ItemType[1] {ItemType.OneStaminaConsumable};
				break;
			case 4:
				items = new ItemType[1] {ItemType.OneStaminaConsumable};
				break;
		}

		return items;
	}

}
