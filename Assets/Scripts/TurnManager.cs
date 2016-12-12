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
		Stamina = 0;
	}

	public static void IncreaseStamina(int amount)
	{
		Stamina += amount;
	}

	public static void NextDay()
	{
		CurrentDay += 1;

		Stamina = 0;
	}

	public static int[] GetItemsForDay()
	{
		int[] items = new int[4];

		switch (CurrentDay)
		{
			case 1:
				items = new int[4] {0,2,1,2};
				break;
			case 2:
				items = new int[4] {1,2,1,1};
				break;
			case 3:
				items = new int[4] {0,2,0,1};
				break;
			case 4:
				items = new int[4] {0,2,0,1};
				break;
		}

		return items;
	}

}
