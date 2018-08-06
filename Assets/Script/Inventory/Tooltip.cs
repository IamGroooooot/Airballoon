using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
	private Item item;
	private string data;
	private GameObject tooltip;

	void Start()
	{
		tooltip = GameObject.Find("Tooltip");
		tooltip.SetActive (false);
	}

	void Update()
	{
		if (tooltip.activeSelf) 
		{
			tooltip.transform.position = Input.mousePosition;
		}

	}

	public void Activate(Item item)
	{
		this.item = item;
		ConstructDataString ();
		tooltip.SetActive (true);
	}

	public void Deactivate(Item item)
	{
		tooltip.SetActive (false);
	}

	public void ConstructDataString()
	{
		data = "<Color=#0473f0><b>" +item.Title + "</b></color>\n\n" + item.Description + "\n";
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
	}
}
