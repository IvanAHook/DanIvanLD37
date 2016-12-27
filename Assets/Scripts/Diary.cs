using UnityEngine;

public class Diary : MonoBehaviour
{

	private SpriteRenderer _spriteRenderer;
	public Sprite[] DiaryEntries;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		Messenger.AddListener("NewDay", UpdateDiary);
		UpdateDiary();
	}

	private void UpdateDiary()
	{
		if (_spriteRenderer == null)
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		if (DiaryEntries.Length < TurnManager.CurrentDay)
		{
			_spriteRenderer.sprite = null;
		}
		_spriteRenderer.sprite = DiaryEntries[TurnManager.CurrentDay];
	}

}
