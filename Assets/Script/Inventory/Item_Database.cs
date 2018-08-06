using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Item_Database : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemData;
	TextAsset file;

	void Start()
	{
		file = Resources.Load<TextAsset>("Items");
		string jsonString = file.ToString();

		itemData = JsonMapper.ToObject (jsonString);

			
		ConstructItemDatabase ();

	}

	public Item FindItemByID(int id)
	{
		for (int i = 0; i<database.Count; i++) 
		{
			if (database [i].ID == id) 
			{
				return database[i];
			}
		}

		return null;
	}

	void ConstructItemDatabase()
	{
		for (int i = 0; i < itemData.Count; i++) 
		{
			database.Add (new Item ((int)itemData[i]["id"],itemData[i]["title"].ToString(),(int)itemData[i]["value"],
				itemData[i]["description"].ToString(),(bool)itemData[i]["stackable"],(int)itemData[i]["purpose"],
				itemData[i]["slug"].ToString()
			));
		}

	}



}

public class Item
{
	public int ID {get;set;}
	public string Title {get;set;}
	public int Value {get;set;}
	public string Description {get;set;}
	public bool Stackable {get;set;}
	public int Purpose {get;set;}
	public string Slug {get;set;}
	public Sprite Sprite {get;set;}

	public Item(int id, string title, int value,string description, bool stackable,int purpose, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Description = description;
		this.Stackable = stackable;
		this.Purpose = purpose;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("Sprites/Items/"+slug);
	}

	public Item()
	{
		this.ID = -1;

	}
}
