﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
	public int id;//위치
	private Inventory inv;



	public void OnDrop(PointerEventData eventData)
	{
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData> ();

		if(inv.items[id].ID == -1)
		{


            inv.items[droppedItem.slot] = new Item();
			inv.items[id] = droppedItem.item;
			droppedItem.slot = id;
            droppedItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);//위치오류수정


        }
		// 여기 가끔 오류나더라
		else if(droppedItem.slot != id)//인벤토리에 아이템이 있으면 swap하기
		{


            Transform item =  this.transform.GetChild(0);

            item.GetComponent<ItemData>().slot = droppedItem.slot;
            
			item.transform.SetParent(inv.slots[droppedItem.slot].transform);
			item.transform.position = inv.slots[droppedItem.slot].transform.position;
            item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0); //위치오류수정

            droppedItem.slot = id;
			droppedItem.transform.SetParent(this.transform);

            droppedItem.transform.position = this.transform.position;
            droppedItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0); //위치오류수정

            inv.items[droppedItem.slot] =  item.GetComponent<ItemData>().item;
			inv.items[id] = droppedItem.item;


        }


	}

	// Use this for initialization
	void Start () {
		inv = GameObject.Find ("Inventory").GetComponent<Inventory>();

	}

}
