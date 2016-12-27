using UnityEngine;

public class InputHandler : MonoBehaviour
{

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Messenger<InputType>.Broadcast("PlayerInput", InputType.Mouse0);
		}
		if (Input.GetMouseButtonDown(1))
		{
			Messenger<InputType>.Broadcast("PlayerInput", InputType.Mouse1);
		}
	}

}
