using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScrollingMist : MonoBehaviour
{

	private float _scrollSpeed;
	private Vector3 _startPosition;
	private Vector3 _endPosition;

	// Use this for initialization
	void Start ()
	{
		_scrollSpeed = Random.Range(0.2f, 0.8f);
		_startPosition = new Vector3(20, transform.position.y, transform.position.z);
		_endPosition = new Vector3(-20, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, _endPosition, _scrollSpeed * Time.deltaTime);

		if (transform.position.x <= -20)
		{
			transform.position = _startPosition;
		}
	}
}
