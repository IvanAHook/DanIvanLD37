using UnityEngine;

public class TurnBar : MonoBehaviour
{

	private SpriteRenderer _spriteRenderer;
	private int _turns;

	private void Start ()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_turns = TurnManager.Stamina;

		UpdateTurns();
	}

	private void Update()
	{
		if (_turns != TurnManager.Stamina)
		{
			_turns = TurnManager.Stamina;

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
