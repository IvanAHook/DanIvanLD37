using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class CameraResolutionScaling : MonoBehaviour {

	private Camera _mainCamera;

	public int Ppu = 32;
    public int PpuScale = 1;

	void Awake ()
	{
		_mainCamera = Camera.main;

		var verticalResolution = 360;
		var horizontalResolution = (verticalResolution / 9) * 16;
	    	   
	    _mainCamera.orthographicSize = (float)verticalResolution/(2*Ppu);
		Screen.SetResolution(horizontalResolution, verticalResolution, true);
		Screen.fullScreen = false;
	}
}
