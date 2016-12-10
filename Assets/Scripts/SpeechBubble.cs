using System.Collections;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{

	public Transform Bubble;
	public Sprite[] BubbleMessages;

	private int _bubbleVisibleDuration = 5;
	private SpriteRenderer _dilogueSpriteRenderer;

	void Awake() {
		_dilogueSpriteRenderer = Bubble.FindChild("Dilogue").GetComponent<SpriteRenderer>();
	}
	public void ShowBubble(int messageId)
	{
		_dilogueSpriteRenderer.sprite = BubbleMessages[messageId];
		Bubble.gameObject.SetActive(true);
		CancelInvoke();
		Invoke("HideBubble" , _bubbleVisibleDuration);
	}

	private void HideBubble()
	{
		Bubble.gameObject.SetActive(false);
	}

}
