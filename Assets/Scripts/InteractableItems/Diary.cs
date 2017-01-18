using UnityEngine;

public class Diary : InteractableItem
{

	private SpriteRenderer _spriteRenderer;
	public Sprite[] DiaryEntries;

	public Transform DisplayItem;
	public SpriteRenderer ContentRenderer;

	public override void Interract()
	{
		if (!DisplayItem.gameObject.activeSelf)
		{
			DisplayItem.gameObject.SetActive(true);
			UpdateDiary();
		}

	}

	private void UpdateDiary()
	{
		if (DiaryEntries.Length < TurnManager.CurrentDay)
		{
			ContentRenderer.sprite = null;
		}
		ContentRenderer.sprite = DiaryEntries[TurnManager.CurrentDay];
	}

}
