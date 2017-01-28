using UnityEngine;

public class CampfireInteractableItem : InteractableItem
{

    public Wood Wood;
    public GameObject FauxLight;
    public GameObject Particles;
    public Sprite CampFireBase;

    private void Start()
    {
        Wood = FindObjectOfType<Wood>();
        TurnManager.newDayCallback += NewDay;
        GetComponent<Animator>().SetBool("Fire", true);
    }

	public override void Interract()
	{
	    Debug.Log("Playing with fiyyaahhh");
	}

    private void NewDay()
    {
        if (Wood.LogCount == 0)
        {
            KillFire();
        }
    }

    private void KillFire()
    {
        GetComponent<Animator>().SetBool("Fire", false);
        FauxLight.gameObject.SetActive(false);
        Particles.gameObject.SetActive(false);
        GetComponent<AudioSource>().enabled = false;
    }

    private void StartFire()
    {
        //TODO
    }
}
