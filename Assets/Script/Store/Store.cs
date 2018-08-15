using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {
	GameObject storePanel;
	GameObject slotPanel;

	Item_Database database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;
	public GameObject BuyByTouch;
	public Transform canvas;
	int slotAmount;

	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start()
	{


		database = GetComponent<Item_Database> ();//같은 object에 있어야함
		slotAmount = 12;
		storePanel = GameObject.Find ("Store_Panel");
		slotPanel = storePanel.transform.Find("Slot_Panel").gameObject;



		for (int i = 0; i < slotAmount; i++) {
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].GetComponent<StoreSlot> ().id = i;
			slots [i].transform.SetParent (slotPanel.transform);
		}



		AddItem (0);
		AddItem (1);
		AddItem (2);
		AddItem (3);
		AddItem (4);
		AddItem (5);
		AddItem (6);
		AddItem (7);
		AddItem(8);
		AddItem(9);
		AddItem(10);
		AddItem(11);
		AddItem(12);


	}

	public void AddItem(int id)
	{
		Item itemToAdd = database.FindItemByID (id);
		if (itemToAdd.Stackable && CheckIfItemIsInInventory (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {	
				if (items [i].ID == id) {
					StoreItemData data = slots [i].transform.GetChild (0).GetComponent<StoreItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		} 
		else 
		{
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == -1) {
					items [i] = itemToAdd;
					GameObject itemObj = Instantiate (inventoryItem);

					itemObj.GetComponent<StoreItemData> ().item = itemToAdd;
					itemObj.GetComponent<StoreItemData> ().slot = i;
					itemObj.GetComponent<StoreItemData>().amount = 1;
					itemObj.transform.SetParent (slots [i].transform);
					itemObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;

					GameObject BBTouch = Instantiate (BuyByTouch, itemObj.transform);
					BBTouch.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
					BBTouch.GetComponent<OnShopItemClicked>().WhichSlot = id;
					break;
				}
			}
		}

	}
	bool CheckIfItemIsInInventory(Item item)
	{
		for (int i = 0; i < items.Count; i++) 
		{	
			if (items [i].ID == item.ID)
				return true;
		}
		return false;
	}



}
