using UnityEngine;

public class GrabbableItem : InteractableItem
{

    public ItemType PickedUpItem;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public override void Interract()
    {
        Debug.Log("Picked up item: " + this);
        Inventory.Instance.AddItem(PickedUpItem);
        gameObject.SetActive(false);
    }
}
