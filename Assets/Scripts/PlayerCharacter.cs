using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerCharacter : MonoBehaviour
{

	private Rigidbody2D _rb2d;
	private SpriteRenderer _spriteRenderer;
	private SpeechBubble _speechBubble;
	private Animator _animator;
	private float _movementSpeed = 2;

	void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
		_speechBubble = GetComponent<SpeechBubble>();
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
					_speechBubble.ShowBubble();
					return;
				}
				StopAllCoroutines();
				StartCoroutine(MoveTo(hit.transform.position, () =>
				{
					if (hit.collider.GetComponent<InteractableItem>() != null)
					{
						hit.collider.GetComponent<InteractableItem>().Interract();
					}
					TurnManager.SpendTurn();
				}));
			}
			if (hit.collider != null && hit.collider.tag == "Scavenge")
			{

			}
		}
	}

	private IEnumerator MoveTo(Vector2 destination, Action reacedDestination)
	{
		var remainingDistance = (Vector2) transform.position - destination;
		var direction = remainingDistance.normalized;

		if (direction.x < 0 && _spriteRenderer.flipX)
		{
			_spriteRenderer.flipX = false;
		}
		if (direction.x > 0 && !_spriteRenderer.flipX)
		{
			_spriteRenderer.flipX = true;
		}
		_animator.SetBool("Moving", true);

		while (remainingDistance.sqrMagnitude > 0.1f)
		{
			Vector2 newPostion = Vector3.MoveTowards(_rb2d.position, destination, _movementSpeed * Time.deltaTime);
			_rb2d.MovePosition(newPostion);

			remainingDistance = (Vector2) transform.position - destination;

			yield return null;
		}
		_animator.SetBool("Moving", false);
		reacedDestination();
	}

}
