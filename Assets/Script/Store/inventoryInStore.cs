using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class inventoryInStore : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
	Item_Database database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;
	public GameObject SellByTouch;
	public Transform canvas;
	int slotAmount;


	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();
	List<Item> Loadeditems;

	void Start()
	{


		database = GetComponent<Item_Database> ();//같은 object에 있어야함

		slotAmount = 9;
		inventoryPanel = GameObject.Find ("Inventory_Panel");
		slotPanel = inventoryPanel.transform.Find("Slot_Panel").gameObject;


		for (int i = 0; i < slotAmount; i++) {
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].GetComponent<StoreSlot> ().id = i;
			slots [i].transform.SetParent (slotPanel.transform);

			GameObject SBTouch = Instantiate (SellByTouch, slots[i].transform);
			SBTouch.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			SBTouch.GetComponent<OnMyItemClicked>().WhichSlot = i;

		}
			

		Load ();
	}

	public void AddItem(int id)
	{
		Item itemToAdd = database.FindItemByID (id);
		if (itemToAdd.Stackable && CheckIfItemIsInInventory (itemToAdd)) { //stack가능할 경우
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
					//itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;

					itemObj.transform.parent.GetChild (0).SetAsLastSibling();

					save ();

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

	public void save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.dataPath + "/Resources/Inventory1.dat");
		bf.Serialize (file,items);
		file.Close ();
		Debug.Log ("Saved");
	}

	private void Load()
	{
		if (File.Exists (Application.dataPath + "/Resources/Inventory1.dat")) 
		{
			//BinaryFormatter bf = new BinaryFormatter ();
			//FileStream file = File.Open (Application.persistentDataPath + "/Inventory.dat",FileMode.Open);
			using (Stream stream = File.Open (Application.dataPath + "/Resources/Inventory1.dat", FileMode.Open)) 
			{
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Loadeditems = (List<Item>)bformatter.Deserialize (stream); 

			}
			Debug.Log ("File Exists");
		}

		foreach(Item Myitem in Loadeditems) 
		{
			if (Myitem.ID == -1) {
				Debug.Log (Myitem.ID);
				continue;
			}
			Debug.Log (Myitem.ID);
			AddItem (Myitem.ID);

		}



	}
}
