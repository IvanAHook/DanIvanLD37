using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class SpriteOutline : MonoBehaviour
{

	public Color Color = Color.white;
	public bool ShowOutline;

	private SpriteRenderer _spriteRenderer;

	void Awake() {
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate() {
		UpdateOutline(ShowOutline);
		ShowOutline = false;
	}

	void UpdateOutline(bool outline) {
		MaterialPropertyBlock mpb = new MaterialPropertyBlock();
		_spriteRenderer.GetPropertyBlock(mpb);
		mpb.SetFloat("_Outline", outline ? 1f : 0);
		mpb.SetColor("_OutlineColor", Color);
		_spriteRenderer.SetPropertyBlock(mpb);
	}
}