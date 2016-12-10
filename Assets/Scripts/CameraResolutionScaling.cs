using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolutionScaling : MonoBehaviour {

	private Camera _mainCamera;

	public int Ppu = 32;

	void Awake ()
	{
		_mainCamera = Camera.main;

		var verticalResolution = 240;
		var horizontalResolution = (verticalResolution / 3) * 4;

		var orthoSize = horizontalResolution / (((horizontalResolution / verticalResolution) * 2) * Ppu);

		_mainCamera.orthographicSize = orthoSize;
		Screen.SetResolution(horizontalResolution, verticalResolution, true);
	}
}
