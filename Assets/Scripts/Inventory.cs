using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject[] itemSlot;
    private Item[] _items;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SetItems(Item[] items)
    {
        ClearItems();
        _items = items;
        for(int i = 0; i < _items.Length; i++)
        {
            _items[i].transform.SetParent(this.transform);
            _items[i].transform.position = itemSlot[i].transform.position;
        }
    }

    private void ClearItems()
    {
        if (_items == null)
            return;

        for (int i = 0; i < _items.Length; i++)
        {
            DestroyImmediate(_items[i].gameObject);
        }
    }

}
