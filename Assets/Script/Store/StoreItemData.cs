using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreItemData : MonoBehaviour {
	public Item item;
	public int amount;
	public int slot; //슬롯 위치

	public Sprite mySprite;

	void Start(){
		
		mySprite = Resources.Load<Sprite> ("Sprites/Items/"+item.Slug);

		GetComponent<Image> ().sprite = mySprite;
	}

	void Update(){
		


	}
}
