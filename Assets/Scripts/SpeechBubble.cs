using System.Collections;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{

	public Transform Bubble;
	private int _bubbleVisibleDuration = 5;

	public void ShowBubble()
	{
		Bubble.gameObject.SetActive(true);
		CancelInvoke();
		Invoke("HideBubble" , _bubbleVisibleDuration);
	}

	private void HideBubble()
	{
		Bubble.gameObject.SetActive(false);
	}

}
