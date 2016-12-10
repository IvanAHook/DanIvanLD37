using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

	public void OnLevelWasLoaded()
	{
		//TurnManager.Initialize();
	}

	void Start ()
	{
		TurnManager.Initialize();
	}
	
	void Update ()
	{

	}
}
