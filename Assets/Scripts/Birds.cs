using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{

    public Transform start;
    public Transform stop;
    public float movementSpeed;

	// Use this for initialization
	void Start ()
	{
	    gameObject.transform.position = start.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var delta = movementSpeed * Time.deltaTime;
	    if ((transform.position.x - stop.position.x) < delta)
	    {
	        transform.position = start.position;
	    }
	    else
	    {
	        transform.position = Vector2.MoveTowards(transform.position, stop.position, delta);

	    }
	}
}
