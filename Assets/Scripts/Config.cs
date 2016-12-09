using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Config : MonoBehaviour
{

    private Camera _mainCamera;

	void Awake () {
        _mainCamera = Camera.main;

	    var verticalResolution = 240;
	    var horizontalResolution = (verticalResolution / 3) * 4;

	    Debug.Log(horizontalResolution);

	    var ppu = 32;

	    var orthoSize = horizontalResolution / (((horizontalResolution / verticalResolution) * 2) * ppu);

	    _mainCamera.orthographicSize = orthoSize;
	    Screen.SetResolution(horizontalResolution, verticalResolution, true);
	}
	
	void Update () {
		
	}
}
