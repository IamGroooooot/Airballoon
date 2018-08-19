using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMyItemClicked : MonoBehaviour {

	public int WhichSlot;

	GameObject MyInv;
	//GameObject SlotPanel;
	GameObject mySkill;

	inventoryInStore MyInvScript;

	void Start()
	{
		PlayerDB.gold = 1000000;// For Test
		MyInv = GameObject.Find ("Inventory");
		//SlotPanel = transform.parent.parent.parent.gameObject;
		MyInvScript = MyInv.GetComponent<inventoryInStore> ();
	}

	void Update()
	{
		
	}

	public void OnBtnClick()
	{
		switch (WhichSlot)
		{
		case 0:
			if (transform.parent.childCount == 1)
				break;
			mySkill = transform.parent.GetChild (0).gameObject;
			int id1 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId (id1);

			break;
		case 1:
			if (transform.parent.childCount == 1)
				break;
			mySkill = transform.parent.GetChild(0).gameObject;
			int id2 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id2);
			break;

		case 2:
			if (transform.parent.childCount == 1)
				break;
			mySkill =transform.parent.GetChild(0).gameObject;
			int id3 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id3);
			break;

		case 3:
			if (transform.parent.childCount == 1)
				break;
			mySkill = transform.parent.GetChild(0).gameObject;
			int id4 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id4);
			break;

		case 4:
			if (transform.parent.childCount == 1)
				break;
			mySkill =transform.parent.GetChild(0).gameObject;
			int id5= mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id5);
			break;
		case 5:
			if (transform.parent.childCount == 1)
				break;
			mySkill = transform.parent.GetChild(0).gameObject;
			int id6 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id6);
			break;
		case 6:
			if (transform.parent.childCount == 1)
				break;
			mySkill = transform.parent.GetChild(0).gameObject;
			int id7 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id7);
			break;
		case 7:
			if (transform.parent.childCount == 1)
				break;
			mySkill = transform.parent.GetChild(0).gameObject;
			int id8 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id8);
			break;
		case 8:
			if (transform.parent.childCount == 1)
				break;
			mySkill = transform.parent.GetChild(0).gameObject;
			int id9 = mySkill.GetComponent<StoreItemData> ().item.ID;
			OnSellbyId(id9);
			break;
		
		default:
			Debug.Log ("해당하는 스킬 없음");
			break;
		}

	}


	public void OnSellbyId(int id)
	{
		switch (id)
		{
		case 0:
			OnSellId1 ();
			break;
		case 1:
			OnSellId2 ();
			break;

		case 2:
			OnSellId3 ();
			break;

		case 3:
			OnSellId4 ();
			break;

		case 4:
			OnSellId5 ();
			break;
		case 5:
			OnSellId6 ();
			break;
		case 6:
			OnSellId7 ();
			break;
		case 7:
			OnSellId8 ();
			break;
		case 8:
			OnSellId9 ();
			break;
		case 9:
			OnSellId10 ();
			break;
		case 10:
			OnSellId11 ();
			break;
		case 11:
			OnSellId12 ();
			break;
		default:
			break;
		}

	}

	public void OnSellId1()
	{
		
		int cost = 1;

		MyInvScript.items [WhichSlot] = new Item ();
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);
		
		MyInvScript.save();

		//droppedItem.slot = id;

		PlayerDB.gold += cost;

	}
	public void OnSellId2()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}
	public void OnSellId3()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;

	}
	public void OnSellId4()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}
	public void OnSellId5()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;

	}
	public void OnSellId6()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;

	}
	public void OnSellId7()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}
	public void OnSellId8()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}

	public void OnSellId9()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}
	public void OnSellId10()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}
	public void OnSellId11()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}
	public void OnSellId12()
	{
		int cost = 1;
		MyInvScript.items [WhichSlot] = new Item ();
		//Destroy(mySkill);
		if (transform.parent.childCount == 2)
			Destroy(transform.parent.GetChild(0).gameObject);

		MyInvScript.save();

		PlayerDB.gold += cost;


	}




}
