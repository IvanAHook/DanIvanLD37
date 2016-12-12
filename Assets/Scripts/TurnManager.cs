using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public static class TurnManager
{
	public const int MaxTurns = 8;
	public static int Stamina { get; private set; }

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
		Messenger.Broadcast("newDay");
		InitializeDay();
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
		Messenger.Broadcast("aquireItems");
	}

	public static int[] GetItemsForDay()
	{
		int[] items = new int[4];

		switch (CurrentDay)
		{
			case 0:
				items = new int[1] {1};
				break;
			case 1:
				items = new int[1] {1};
				break;
			case 2:
				items = new int[3] {1,1,1};
				break;
			case 3:
				items = new int[1] {1};
				break;
			case 4:
				items = new int[1] {1};
				break;
		}

		return items;
	}

}
