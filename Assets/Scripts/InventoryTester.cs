using UnityEngine;

public class InventoryTester : MonoBehaviour
{

    public Item Item;
    public Inventory Inventory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        SetItemInBar();
    }

    public void SetItemInBar()
    {
        Item[] items = new Item[4];
        for (int i = 0; i < 4; i++)
        {
            items[i] = Instantiate(Item, new Vector2(-1000, -1000), Quaternion.identity);
        }
	    Inventory.SetItems(items);
    }
}
