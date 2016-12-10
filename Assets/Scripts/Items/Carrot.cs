using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Item {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        UseItem();
    }

    public override void UseItem()
    {
        Debug.Log("CARROT!");
    }
}
