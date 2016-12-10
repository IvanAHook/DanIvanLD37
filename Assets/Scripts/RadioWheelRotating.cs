using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioWheelRotating : MonoBehaviour
{

	private bool _active;
	private float _angle;

	public float AngleValue
	{
		get { return Util.RemapFloat(_angle, -180, 180, 0, 1); }
	}

	private void Update ()
	{
		if (_active)
		{
			var pos = Camera.main.WorldToScreenPoint(transform.position);
			var dir = Input.mousePosition - pos;
			_angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
		}
	}

	private void OnMouseDown()
	{
		_active = true;
	}

	private void OnMouseUp()
	{
		_active = false;
	}
}
