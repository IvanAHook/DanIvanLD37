using UnityEngine;

public class CampfireInteractableItem : InteractableItem
{

    public Wood wood;

    private void Start()
    {
        wood = FindObjectOfType<Wood>();
        TurnManager.newDayCallback += NewDay;
    }

	public override void Interract()
	{
	}

    private void NewDay()
    {
        if (wood.LogCount == 0)
        {
            // TODO: hide fire
        }
    }
}
