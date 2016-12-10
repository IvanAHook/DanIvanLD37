using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManual : MonoBehaviour
{

	public Sprite[] Sprites;
	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnEnable()
	{
		_spriteRenderer.sprite = Sprites[0];
	}

	private void OnMouseDown()
	{
		_spriteRenderer.sprite = Sprites[1];
	}
}
