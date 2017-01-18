using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Inventory : MonoBehaviour
{

	private const int ItemWidth = 1;

	public Item[] AvaliableItems;

	private List<Item> _items;
	private List<ItemData> _itemsAtStartOfDay;

	private void Awake()
	{
		_items = new List<Item>();
		_itemsAtStartOfDay = new List<ItemData>();
	}

	private void OnEnable()
	{
		Messenger.AddListener("aquireItems", AquireItems);
		Messenger<Item>.AddListener("removeItem", RemoveItem);
		Messenger.AddListener("resetItemsToLastDay", ResetToLastDayItems);
	}

	private Item GetItem(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.OneStaminaConsumable:
				return AvaliableItems[0];
			default:
				throw new NotImplementedException("item type not found");
		}
	}

	private void AquireItems()
	{
		var newItems = TurnManager.GetItemsForDay();

		for (int i = 0; i < newItems.Length; i++)
		{
			AddItem(newItems[i].Type);
		}

		_itemsAtStartOfDay.Clear();
		for (int i = 0; i < _items.Count; i++)
		{
			var itemData = new ItemData()
			{
				Type = _items[i].Type,
				ItemSprite = _items[i].ItemSprite
			};
			_itemsAtStartOfDay.Add(itemData);
		}
	}

	private void ResetToLastDayItems()
	{
		ClearItems();

		Debug.Log(_itemsAtStartOfDay.Count);

		for (int i = 0; i < _itemsAtStartOfDay.Count; i++)
		{
			Debug.Log(_itemsAtStartOfDay[i].Type);
			AddItem(_itemsAtStartOfDay[i].Type, _itemsAtStartOfDay[i].ItemSprite);
		}

		UpdateItemPositions();
	}

	private void AddItem(ItemType type, Sprite itemSprite = null)
	{
		var position = new Vector2(-1.5f + transform.position.x + _items.Count*ItemWidth, transform.position.y);
		var item = Instantiate(GetItem(type), position, Quaternion.identity);
		item.transform.SetParent(transform);

		if (itemSprite != null)
		{
			item.SetSprite(itemSprite);
		}

		_items.Add(item);
	}

	private void UpdateItemPositions()
	{
		for (int i = 0; i < _items.Count; i++)
		{
			var position = new Vector2(-1.5f + transform.position.x + i*ItemWidth, transform.position.y);
			_items[i].transform.position = position;
		}
	}

	private void RemoveItem(Item item)
	{
		_items.Remove(item);
		Destroy(item.gameObject);
		UpdateItemPositions();
	}

    private void ClearItems()
    {
        if (_items == null)
            return;

        for (int i = 0; i < _items.Count; i++)
        {
	        Destroy(_items[i].gameObject);
        }
	    _items.Clear();
    }

}

public struct ItemData
{
	public ItemType Type;
	public Sprite ItemSprite;
}
