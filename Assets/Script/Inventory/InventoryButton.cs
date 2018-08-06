using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour {
	GameObject inventoryPanel;


	void Start(){
		inventoryPanel = GameObject.Find ("Inventory_Panel");

	}

	public void OnInvButtonClicked(){
		if (!inventoryPanel.activeSelf)
			inventoryPanel.SetActive (true);
		else 
			inventoryPanel.SetActive (false);
	}

}
