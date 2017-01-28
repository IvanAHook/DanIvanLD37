using UnityEngine;

public class CampfireInteractableItem : InteractableItem
{

    public Wood Wood;
    public GameObject FauxLight;
    public GameObject Particles;

    private void Start()
    {
        Wood = FindObjectOfType<Wood>();
        TurnManager.newDayCallback += NewDay;
    }

	public override void Interract()
	{
	}

    private void NewDay()
    {
        if (Wood.LogCount == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            FauxLight.gameObject.SetActive(false);
            Particles.gameObject.SetActive(false);
        }
    }
}
