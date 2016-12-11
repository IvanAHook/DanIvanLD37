using UnityEngine;

public class Diary : MonoBehaviour
{

	private SpriteRenderer _spriteRenderer;
	public Sprite[] DiaryEntries;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void UpdateDiary()
	{
		_spriteRenderer.sprite = DiaryEntries[TurnManager.CurrentDay];
	}

}
