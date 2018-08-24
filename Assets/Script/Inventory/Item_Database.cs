using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;


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
		if (id == -1) {
			return null;
		}
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
        database[0].Description = "체력 15% 회복( 가격 3G )";

        database[1].Description = "2배 속력으로 직선이동( 가격 2G )";

        database[2].Description = "적의 총알로부터 방어해주는 방어막 생성( 가격 4G )";

        database[3].Description = "적들을 공격하는 드론 생성( 가격 5G )";

        database[4].Description = "적들에게 접근하여 터지는 폭탄( 가격 10G )";

        database[5].Description = "비가 내리는 구름 생성( 가격 5G )";

        database[6].Description = " ";

        database[7].Description = "적들을 공격하는 구름 생성( 가격 8G )";

        database[8].Description = " ";

        database[9].Description = " ";

        database[10].Description = " ";

        database[11].Description = " ";

        database[12].Description = " ";
    }



}

[System.Serializable]
public class Item
{
	public int ID {get;set;}
	public string Title {get;set;}
	public int Value {get;set;}
	public string Description {get;set;}
	public bool Stackable {get;set;}
	public int Purpose {get;set;}
	public string Slug {get;set;}


	public Item(int id, string title, int value,string description, bool stackable,int purpose, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Description = description;
		this.Stackable = stackable;
		this.Purpose = purpose;//0: 1회용 1: 무제한 2: 퀘스트 템
		this.Slug = slug;
	}

	public Item()
	{
		this.ID = -1;

	}
}
