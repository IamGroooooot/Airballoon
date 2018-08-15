using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {

	//ItemList(대입)

	//Top
	public GameObject Balloon;
	public GameObject Sail1;
	public GameObject Sail2;

	//Body
	public GameObject Normal;
	public GameObject Speed;
	public GameObject Iron;

	//Head
	public GameObject Turtle;
	public GameObject Bird;
	public GameObject Horse;

	//Item
	public GameObject Gun;
	public GameObject Organ;
	public GameObject Deck;

	//Index(변수)
	public GameObject[] index = new GameObject[3];
	public int page = 0;
	public bool Tap;

	/*public bool sail;
	public bool body;
	public bool head;
	public bool item;*/

	//버튼 누르면 대입
	public void Sail()
	{
		Clear ();
		Tap = true;
		index [0] = Balloon;
		index [1] = Sail1;
		index [2] = Sail2;
		//대입 후 초기화(index[0]부터)
		Initialize ();
	}

	public void Body()
	{
		Clear ();
		Tap = true;
		index [0] = Normal;
		index [1] = Speed;
		index [2] = Iron;
		//대입 후 초기화(index[0]부터)
		Initialize ();
	}

	public void Head()
	{
		Clear ();
		Tap = true;
		index [0] = Turtle;
		index [1] = Bird;
		index [2] = Horse;
		//대입 후 초기화(index[0]부터)
		Initialize ();
	}

	public void Item()
	{
		Clear ();
		Tap = true;
		index [0] = Gun;
		index [1] = Organ;
		index [2] = Deck;
		//대입 후 초기화(index[0]부터)
		Initialize ();
	}

	void Initialize()
	{
		// x-1, x, x+1
		index [0].gameObject.SetActive (true);

		index [1].gameObject.SetActive (false);
		index [2].gameObject.SetActive (false);
	}

	void Clear()
	{
		index [0].gameObject.SetActive (false);
		index [1].gameObject.SetActive (false);
		index [2].gameObject.SetActive (false);
	}

	//다음 Index[i].gameObject.SetActive 상호작용
	public void Next()
	{
		if (Tap) {
			int LimitPage=page++;

			if (LimitPage == 3) {
				page = 0;
			}
			Debug.Log (page + "," + LimitPage);

			switch(page){

			case 0:
				index [0].gameObject.SetActive (true);
				index [1].gameObject.SetActive (false);
				index [2].gameObject.SetActive (false);
				break;

			case 1:
				index [1].gameObject.SetActive (true);
				index [0].gameObject.SetActive (false);
				index [2].gameObject.SetActive (false);
				break;

			case 2:
				index [2].gameObject.SetActive (true);
				index [0].gameObject.SetActive (false);
				index [1].gameObject.SetActive (false);
				break;
			}
		}
	}
}
