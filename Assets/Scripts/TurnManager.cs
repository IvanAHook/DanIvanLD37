using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using UnityEngine;

public static class TurnManager
{
	public const int MaxTurns = 8;
	private static int _staminaAtStartOfDay;

	public static int CurrentDay { get; private set; }
	public static int Stamina { get; private set; }
	public static bool Death { get { return Stamina - 4 < 0; } }

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
		Messenger.Broadcast("NewDay");
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

	public static ItemData[] GetItemsForDay()
	{
		ItemData[] items = new ItemData[4];

		switch (CurrentDay)
		{
			case 0:
				items = new ItemData[] {new ItemData(){ Type = ItemType.OneStaminaConsumable }};
				break;
			case 1:
				items = new ItemData[1] {new ItemData(){ Type = ItemType.OneStaminaConsumable }};
				break;
			case 2:
				items = new ItemData[3] {new ItemData(){ Type = ItemType.OneStaminaConsumable },
											new ItemData(){ Type = ItemType.OneStaminaConsumable },
											new ItemData(){ Type = ItemType.OneStaminaConsumable }};
				break;
			case 3:
				items = new ItemData[1] {new ItemData(){ Type = ItemType.OneStaminaConsumable }};
				break;
			case 4:
				items = new ItemData[1] {new ItemData(){ Type = ItemType.OneStaminaConsumable }};
				break;
		}

		return items;
	}

}
