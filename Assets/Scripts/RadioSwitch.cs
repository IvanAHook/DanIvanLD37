using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSwitch : MonoBehaviour
{

	private Quaternion _originalRotation;

	private bool _flipped;
	private float _flipRotationDegree = 90f;

	private void Awake()
	{
		_originalRotation = transform.rotation;
	}

	private void OnMouseDown()
	{
		if (!_flipped)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _flipRotationDegree);
			_flipped = true;
			return;
		}
		transform.rotation = _originalRotation;
		_flipped = false;
	}

}
