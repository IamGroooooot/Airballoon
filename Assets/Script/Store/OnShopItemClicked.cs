using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnShopItemClicked : MonoBehaviour {

	public int WhichSlot;
	//GameObject MyStore;
	GameObject MyInv;
    StoreToolTip Tooltip;
    Item_Database Myitem_Database;
    inventoryInStore MyInvScript;

	void Start()
	{
		//MyStore = GameObject.Find ("Store");
		MyInv = GameObject.Find ("Inventory");
        
        Tooltip = GameObject.Find("Store").GetComponent<StoreToolTip>();
        MyInvScript = MyInv.GetComponent<inventoryInStore> ();
        Myitem_Database = GameObject.Find("Store").GetComponent<Item_Database>();

    }

	public void OnBtnClick()
	{
		switch (WhichSlot)
		{
		case 0:
			OnItem1Clicked ();
			break;
		case 1:
			OnItem2Clicked ();
			break;

		case 2:
			OnItem3Clicked ();
			break;

		case 3:
			OnItem4Clicked ();
			break;

		case 4:
			OnItem5Clicked ();
			break;
		case 5:
			OnItem6Clicked ();
			break;
		case 6:
			OnItem7Clicked ();
			break;
		case 7:
			OnItem8Clicked ();
			break;
		case 8:
			OnItem9Clicked ();
			break;
		case 9:
			OnItem10Clicked ();
			break;
		case 10:
			OnItem11Clicked ();
			break;
		case 11:
			OnItem12Clicked ();
			break;
		
		default:
			Debug.Log ("해당하는 스킬 없음");
			break;
		}

	}


	public void OnItem1Clicked()
	{
		int cost = 3;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (0);
			PlayerDB.DB.gold -= cost;
		} else {
			Debug.Log ("No Money");
		}

	}
	public void OnItem2Clicked()
	{
		int cost = 2;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (1);
            PlayerDB.DB.gold -= cost;
		}

	}
	public void OnItem3Clicked()
	{
		int cost = 4;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (2);
            PlayerDB.DB.gold -= cost;
		}
	}
	public void OnItem4Clicked()
	{
		int cost = 5;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (3);
            PlayerDB.DB.gold -= cost;
		}

	}
	public void OnItem5Clicked()
	{
		int cost = 3;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (4);
            PlayerDB.DB.gold -= cost;
		}
	}
	public void OnItem6Clicked()
	{
		int cost = 1;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (5);
            PlayerDB.DB.gold -= cost;
		}
	}
	public void OnItem7Clicked()
	{
		int cost = 1000000;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (6);
            PlayerDB.DB.gold -= cost;
		}


	}
	public void OnItem8Clicked()
	{
		int cost = 1000000;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (7);
            PlayerDB.DB.gold -= cost;
		}

	}
	public void OnItem9Clicked()
	{
		int cost = 1000000;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (8);
            PlayerDB.DB.gold -= cost;
		}

	}
	public void OnItem10Clicked()
	{
		int cost = 1000000;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (9);
            PlayerDB.DB.gold -= cost;
		}

	}
	public void OnItem11Clicked()
	{
		int cost = 1000000;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (10);
            PlayerDB.DB.gold -= cost;
		}
	}
	public void OnItem12Clicked()
	{
		int cost = 1000000;
		if (PlayerDB.DB.gold >= cost) {
			MyInvScript.AddItem (11);
            PlayerDB.DB.gold -= cost;
		}

	}

    public void OnLongClicked()
    {
        Item myItem;
        myItem = Myitem_Database.FindItemByID(WhichSlot);
        Tooltip.Activate(myItem);



    }



}
