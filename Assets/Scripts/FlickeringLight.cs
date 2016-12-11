using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{

	private SpriteRenderer _spriteRenderer;
	private float _flickerMax = 0.8f;
	private float _flickerMin = 0.6f;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(Flicker());
	}

	private IEnumerator Flicker()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.1f);
			_spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, Random.Range(_flickerMin, _flickerMax));
		}
	}

}
