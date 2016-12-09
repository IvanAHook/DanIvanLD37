using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Config : MonoBehaviour
{

    private static Config _config;

    public Config Instance
    {
        get { return _config; }
    }

    private Camera _mainCamera;

    public int Ppu = 32;

	void Awake ()
	{
	    if (_config == null)
	    {
	        _config = this;
	    }

	    // CAMERA
        _mainCamera = Camera.main;

	    var verticalResolution = 240;
	    var horizontalResolution = (verticalResolution / 3) * 4;

	    var orthoSize = horizontalResolution / (((horizontalResolution / verticalResolution) * 2) * Ppu);

	    _mainCamera.orthographicSize = orthoSize;
	    Screen.SetResolution(horizontalResolution, verticalResolution, true);
	    //


	}

}
