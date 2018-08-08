using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler, IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler {
	public Item item;
	public int amount;
	public int slot; //슬롯 위치


	private Inventory inv;
	private Tooltip tooltip;
	private Vector2 offset;

	void Start(){
		inv = GameObject.Find ("Inventory").GetComponent<Inventory>();
		tooltip = inv.GetComponent<Tooltip> ();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (item != null) 
		{
			this.transform.SetParent (this.transform.parent.parent.parent.parent);

			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}


	}

	public void OnPointerDown(PointerEventData eventData)
	{
        
		offset = eventData.position - (Vector2)this.transform.position;
		this.transform.position = eventData.position - offset;
    }

	public void OnDrag(PointerEventData eventData)
	{
		if (item != null) 
		{
			this.transform.position = eventData.position - offset;
		}

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent (inv.slots[slot].transform);
        
		this.transform.position = inv.slots[slot].transform.position;
        this.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0); //위치오류수정
        GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate (item);

	}
	public void OnPointerExit(PointerEventData eventData)
	{

		tooltip.Deactivate (item);
	}

}
