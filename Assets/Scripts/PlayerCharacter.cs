using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerCharacter : MonoBehaviour
{

    public GameObject shadow;
    public Texture2D moveCursor;
	private Rigidbody2D _rb2d;
	private SpriteRenderer _spriteRenderer;
	private SpeechBubble _speechBubble;
	private Animator _animator;
    private CharacterSound _characterSound;
	private float _movementSpeed = 3;
    private Boolean _blockInput;

	private void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
		_speechBubble = GetComponent<SpeechBubble>();
	    _characterSound = GetComponent<CharacterSound>();
	    _blockInput = false;
	}

	private void Update ()
	{
	    if(!_blockInput)
		    UpdateCursor();

//		if (Input.GetKey(KeyCode.A))
//		{
//			Application.LoadLevel(Application.loadedLevel);
//		}
	}

	private void UpdateCursor()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

	    if (hit.collider != null)
	    {
	        Cursor.SetCursor(moveCursor, Vector2.zero, CursorMode.Auto);

	        var spriteOutline = hit.collider.GetComponent<SpriteOutline>();
	        if (spriteOutline != null)
	        {
	            spriteOutline.ShowOutline = true;
	        }
	    }
	    else
	    {
	        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

	    }

		if (Input.GetMouseButtonDown(0))
		{
			if (hit.collider != null && hit.collider.tag == "Interactable")
			{

				if (TurnManager.RemainingTurns < 1)
				{
					_speechBubble.ShowBubble(0);
					return;
				}

				StopAllCoroutines();
				StartCoroutine(MoveTo(hit.transform.position, () =>
				{
					if (hit.collider.GetComponent<InteractableItem>() != null)
					{
						hit.collider.GetComponent<InteractableItem>().Interract();
					}
					if (hit.collider.GetComponent<ScavengeDoor>() != null)
					{
						StartCoroutine(MoveToBed());
					}
					//TurnManager.SpendTurn();
				}));
			}
			if (hit.collider != null && hit.collider.tag == "Scavenge")
			{

			}
		}
	}

	private IEnumerator MoveTo(Vector2 destination, Action reacedDestination)
	{
		var clampedDestination = new Vector2(destination.x, Mathf.Clamp(destination.y, -2.7f, -2.4f));

		var remainingDistance = (Vector2) transform.position - clampedDestination;
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
			Vector2 newPostion = Vector3.MoveTowards(_rb2d.position, clampedDestination, _movementSpeed * Time.deltaTime);
			_rb2d.MovePosition(newPostion);

			remainingDistance = (Vector2) transform.position - clampedDestination;

			yield return new WaitForEndOfFrame();
		}
		_animator.SetBool("Moving", false);

		yield return new WaitForSeconds(0.2f);
		reacedDestination();
	}

	private IEnumerator MoveToBed()
	{
		yield return new WaitForSeconds(8f);
	    _blockInput = true;
		transform.position = new Vector3(-8f, -2.4f, 0f);
	    GetComponent<Animator>().Play("RipleyAwake",0);;
	}

    public void BlockInput(){_blockInput = true;}
    public void UnblockInput(){_blockInput = false;}
    public void ShowShadow(){shadow.SetActive(true);}
    public void HideShadow(){shadow.SetActive(false);}
}
