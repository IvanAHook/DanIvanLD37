using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TurnManager
{
	public static int RemainingTurns { get; private set; }

	public static void Initialize()
	{
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

}
