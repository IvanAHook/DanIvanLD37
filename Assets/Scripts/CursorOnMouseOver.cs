using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnMouseOver : MonoBehaviour
{

    public Texture2D toCursor;
    private Texture2D _prevCursor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        Cursor.SetCursor(toCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
