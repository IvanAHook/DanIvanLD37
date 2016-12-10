using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	private Rigidbody2D _rb2d;
	private SpriteRenderer _spriteRenderer;
	private Animator _animator;

	void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		UpdateCursor();
	}

	private void UpdateCursor()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

		if (hit.collider != null)
		{
			var spriteOutline = hit.collider.GetComponent<SpriteOutline>();
			if (spriteOutline != null)
			{
				spriteOutline.ShowOutline = true;
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (hit.collider != null && hit.collider.tag == "Interactable")
			{
				if (TurnManager.RemainingTurns < 1)
				{
					Debug.Log("YO out of turns fool, go find food lol!");
					return;
				}
				StopAllCoroutines();
				StartCoroutine(MoveTo(hit.transform.position, () =>
				{
					hit.collider.GetComponent<PopupItem>().Interract();
					TurnManager.SpendTurn();
				}));
			}
		}
	}

	private IEnumerator MoveTo(Vector2 destination, Action reacedDestination)
	{
		var remainingDistance = (Vector2) transform.position - destination;
		var direction = remainingDistance.normalized;

		if (direction.x > 0 && _spriteRenderer.flipX)
		{
			_spriteRenderer.flipX = false;
		}
		if (direction.x < 0 && !_spriteRenderer.flipX)
		{
			_spriteRenderer.flipX = true;
		}
		//_animator.SetBool("Walking", true);

		while (remainingDistance.sqrMagnitude > 0.1f)
		{
			Vector2 newPostion = Vector3.MoveTowards(_rb2d.position, destination, Time.deltaTime);
			_rb2d.MovePosition(newPostion);

			remainingDistance = (Vector2) transform.position - destination;

			yield return null;
		}
		//_animator.SetBool("Walking", false);
		reacedDestination();
	}

}
