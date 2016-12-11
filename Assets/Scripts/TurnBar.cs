using UnityEngine;

public class TurnBar : MonoBehaviour
{

	private SpriteRenderer _spriteRenderer;
	private int _turns;

	private void Start ()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_turns = TurnManager.RemainingTurns;

		UpdateTurns();
	}

	private void Update()
	{
		if (_turns != TurnManager.RemainingTurns)
		{
			_turns = TurnManager.RemainingTurns;

			UpdateTurns();
		}
	}

	private void UpdateTurns()
	{
		float turns = (1f / TurnManager.MaxTurns) * _turns;

		MaterialPropertyBlock mpb = new MaterialPropertyBlock();
		_spriteRenderer.GetPropertyBlock(mpb);
		mpb.SetFloat("_FillAmount", turns);
		_spriteRenderer.SetPropertyBlock(mpb);
	}

}
