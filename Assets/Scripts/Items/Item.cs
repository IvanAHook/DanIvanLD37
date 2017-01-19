using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public abstract ItemData Data { get; protected set; }

	private Transform _originalParent;
	private GameObject _placeholder;

	public abstract void Create();

	public abstract void SetSprite(Sprite sprite);

	public void OnBeginDrag(PointerEventData eventData)
	{
		_placeholder = new GameObject();
		_placeholder.name = name + " placehoder";
		_placeholder.transform.SetParent(transform.parent);
		LayoutElement layoutElement = _placeholder.AddComponent<LayoutElement>();
		layoutElement.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
		layoutElement.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
		layoutElement.flexibleWidth = 0;
		layoutElement.flexibleHeight = 0;
		_placeholder.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
		_placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

		_originalParent = transform.parent;
		transform.SetParent(transform.parent.parent);

		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
	    transform.SetParent(_originalParent);
	    transform.SetSiblingIndex(_placeholder.transform.GetSiblingIndex());

	    Destroy(_placeholder);

	    var raycastResults = new List<RaycastResult>();
	    EventSystem.current.RaycastAll(eventData, raycastResults);
	    foreach (var t in raycastResults)
	    {
		    Debug.Log(t.gameObject.name);
	    }

	    GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

public class ItemData
{
	public ItemType Type;
	public Sprite ItemSprite;
	public ItemType[] CombinableWith;
}
