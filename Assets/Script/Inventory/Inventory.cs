using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Inventory : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
    GameObject skillPanel;
	Item_Database database;
	public GameObject inventorySlot;
    public GameObject SkillSlot;
    public GameObject inventoryItem;

    public Transform SkillSlotPos1;
    public Transform SkillSlotPos2;
    public Transform SkillSlotPos3;
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
        skillPanel = GameObject.Find("Skill_Panel");



        inventoryPanel.SetActive (false);

		for (int i = 0; i < slotAmount; i++) {
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].GetComponent<Slot> ().id = i;
			slots [i].transform.SetParent (slotPanel.transform);
		}
        //skill slot 정의
        
        for (int i = slotAmount; i < slotAmount+3; i++)
        {
            items.Add(new Item());
            GameObject Temp;
            if (i == slotAmount)
            {
                Temp = Instantiate(SkillSlot, SkillSlotPos1);
                Temp.name = "SkillSlot1";
                slots.Add(Temp);
                slots[i].GetComponent<Slot>().id = i;
                slots[i].transform.SetParent(skillPanel.transform);
                SkillSlotPos1.transform.SetParent(canvas.transform);
            }
            else if (i == (slotAmount+1))
            {
                Temp = Instantiate(SkillSlot, SkillSlotPos2);
                Temp.name = "SkillSlot2";
                slots.Add(Temp);
                slots[i].GetComponent<Slot>().id = i;
                slots[i].transform.SetParent(skillPanel.transform);
                SkillSlotPos2.transform.SetParent(canvas.transform);
            }
            else if (i == (slotAmount + 2))
            {
                Temp = Instantiate(SkillSlot, SkillSlotPos3);
                Temp.name = "SkillSlot3";
                slots.Add(Temp);
                slots[i].GetComponent<Slot>().id = i;
                slots[i].transform.SetParent(skillPanel.transform);
                SkillSlotPos3.transform.SetParent(canvas.transform);
            }


        }

		Load ();
		//AddItem (1);
		//AddItem (1);

		//AddItem (1);
		//AddItem (1);
		//AddItem (0);
		//AddItem (1);
		//AddItem (1);
		//AddItem (1);
		//AddItem (2);
		//AddItem (3);
        //AddItem(4);
        //AddItem(5);
        //AddItem(6);
        //AddItem(7);
        //AddItem(8);
        //AddItem(9);

		//save ();
       
    }

	public void AddItem(int id)
	{
		Item itemToAdd = database.FindItemByID (id);
		if (itemToAdd == null) {
			Debug.Log("Blank Space");
			return;
		}
		if (itemToAdd.Stackable && CheckIfItemIsInInventory (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == id) {
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
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
					itemObj.GetComponent<ItemData> ().item = itemToAdd;
					itemObj.GetComponent<ItemData> ().slot = i;
					itemObj.GetComponent<ItemData>().amount = 1;
					itemObj.transform.SetParent (slots [i].transform);
                    itemObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

                    //itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;

					save ();//Logically this souldn't be needed => 베포전 삭제하기

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
		FileStream file = File.Create (Application.persistentDataPath + "/Inventory.dat");
		bf.Serialize (file,items);
		file.Close ();
		Debug.Log ("Saved");
	}

	private void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/Inventory.dat")) 
		{
			//BinaryFormatter bf = new BinaryFormatter ();
			//FileStream file = File.Open (Application.persistentDataPath + "/Inventory.dat",FileMode.Open);
			using (Stream stream = File.Open (Application.persistentDataPath + "/Inventory.dat", FileMode.Open)) 
			{
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Loadeditems = (List<Item>)bformatter.Deserialize (stream); 

			}
			Debug.Log ("File Exists");

			foreach(Item Myitem in Loadeditems) 
			{
				if (Myitem.ID == -1) {
					continue;
				}

				AddItem (Myitem.ID);

			}
		}

	}

}
