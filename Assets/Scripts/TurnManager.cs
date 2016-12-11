using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public static class TurnManager
{
	public const int MaxTurns = 8;
	public static int RemainingTurns { get; private set; }

	public static int CurrentDay { get; private set; }

	public static void Initialize()
	{
		CurrentDay = 0;
		RemainingTurns = 4;
	}

	public static bool SpendTurn()
	{
		if (RemainingTurns <= 0)
		{
			return false;
		}

		RemainingTurns -= 1;
		return true;
	}

	public static void IncreaseTurnCount(int count)
	{
		RemainingTurns += count;
	}

	public static void NextDay()
	{
		CurrentDay += 1;

		if (RemainingTurns < 4)
		{
			RemainingTurns = 4;
		}
	}

	public static int[] GetItemsForDay()
	{
		int[] items = new int[4];
		switch (CurrentDay)
		{
			case 1:
				items = new int[4] {0,0,0,0};
				break;
			case 2:
				items = new int[4] {1,1,1,1};
				break;
			case 3:
				items = new int[4] {0,0,0,0};
				break;
			case 4:
				items = new int[4] {0,0,0,0};
				break;
		}

		return items;
	}

}
