using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject[] ItemSlot;
	public Item[] AvaliableItems;

	private List<Item> _items;

	private List<int> _itemsAtStartOfDay;
	private int _itemCountAtStartOfDay;


	private void Awake()
	{
		_items = new List<Item>();
		_itemsAtStartOfDay = new List<int>();
	}

	private void OnEnable()
	{
		Messenger.AddListener("aquireItems", AquireItems);
		Messenger<Item>.AddListener("removeItem", RemoveItem);
		Messenger.AddListener("resetItemsToLastDay", ResetToLastDayItems);
	}

	public void SetItems(Item[] items)
	{
		for (int i = 0; i <items.Length; i++)
		{
			_items.Add(items[i]);
		}

        for(int i = 0; i < _items.Count; i++)
        {
            _items[i].transform.SetParent(transform);
            _items[i].transform.position = ItemSlot[i].transform.position;
        }

		_itemsAtStartOfDay.Clear();
		_itemCountAtStartOfDay = _items.Count;
		for (int i = 0; i < _items.Count; i++)
		{
			_itemsAtStartOfDay.Add(_items[i].SpriteId);
		}
	}

	public void ResetToLastDayItems()
	{
		ClearItems();

		var itemsList = new Item[_itemsAtStartOfDay.Count];

		for (int i = 0; i < _itemCountAtStartOfDay; i++)
		{
			itemsList[i] = Instantiate(GetItem(0), new Vector2(-1000, -1000), Quaternion.identity);
			itemsList[i].SetSprite(_itemsAtStartOfDay[i]);
		}

		SetItems(itemsList);
	}

	public Item GetItem(int i)
	{
		return AvaliableItems[i];
	}

	private void AquireItems()
	{
		var newItems = TurnManager.GetItemsForDay();
		var itemsList = new Item[newItems.Length];

		for (int i = 0; i < newItems.Length; i++)
		{
			itemsList[i] = Instantiate(GetItem(0), new Vector2(-1000, -1000), Quaternion.identity);
		}
		SetItems(itemsList);
	}

	private void RemoveItem(Item item) // TODO implement and use message
	{
		_items.Remove(item);
		Destroy(item.gameObject);
	}

    private void ClearItems()
    {
        if (_items == null)
            return;

        for (int i = 0; i < _items.Count; i++)
        {
		    DestroyImmediate(_items[i].gameObject);
        }
	    _items.Clear();
    }

}
