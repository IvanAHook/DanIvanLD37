using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public Texture2D cursor;

	private void Awake()
	{
		TurnManager.Initialize();
	}
}
