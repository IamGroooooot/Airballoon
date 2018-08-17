using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDB : MonoBehaviour {

	public static PlayerDB DB;

	//HP
	public float max_Health = 100f;
	public float cur_Health;

	//Speed
	public float max_Speed = 300.0f;//속도 제한
	public float rotationSpeed = 100f;//선회 속도

	//Atk
	public float Fire;
	public float Ice;
	public float Water;

	//State
	public enum State {NONE,Thundered};

	//is_equipped? (상점에서)
	public bool is_top;
	public bool is_body;
	public bool is_head;
	public bool is_gun;

	//Resource
	public static int gold;
	public static int log;
	public static int steel;

	//Equip List
	public int Top; // Balloon=0, Normal=1, Speed=2, East=3
	public int Body; //Quick=0, Noraml=1, Iron=2
	public int Head; //Turtle=0, Bird=1, Horse=2
	public int Item; //Deck=0, Machine_Gun=1, Organ=2, Low=3

	public GameObject[] TopList = new GameObject[4];
	public GameObject[] BodyList = new GameObject[3];
	public GameObject[] HeadList = new GameObject[3];
	public GameObject[] ItemList = new GameObject[4];

	//Public Player (싱글턴 참조용)
	public GameObject Player;

	//Item List Int형으로 위와 같이 열거하면 돼

	void Awake(){
		
		//Test
		//Top = 0;
		//Body = 0;
		//Head = 0;
		//Item = 0;

		DB = this;
	}

	void OnEnable()
	{
		//값 불러오기
		PlayerPrefs.SetFloat ("MAX_HP",max_Health);
		PlayerPrefs.SetFloat ("Cur_HP",cur_Health);
		PlayerPrefs.SetFloat ("MAX_SPEED",max_Speed);
		PlayerPrefs.SetFloat ("Rotation_SPEED",rotationSpeed);
		PlayerPrefs.SetFloat ("Fire",Fire);
		PlayerPrefs.SetFloat ("Ice",Ice);
		PlayerPrefs.SetFloat ("Water",Water);

		PlayerPrefs.HasKey("is_top");
		PlayerPrefs.HasKey("is_body");
		PlayerPrefs.HasKey("is_head");
		PlayerPrefs.HasKey("is_gun");

		PlayerPrefs.SetInt ("Top",Top);
		PlayerPrefs.SetInt ("Body",Body);
		PlayerPrefs.SetInt ("Head",Head);
		PlayerPrefs.SetInt ("Item",Item);

		PlayerPrefs.SetInt ("Gold", gold);
		PlayerPrefs.SetInt ("Log", log);
		PlayerPrefs.SetInt ("Steel", steel);

		switch (Top) {

		case 0:
			TopList [0].gameObject.SetActive (true);	

			TopList [1].gameObject.SetActive (false);		
			TopList [2].gameObject.SetActive (false);
			TopList [3].gameObject.SetActive (false);
		break;
		
		case 1:
			TopList [1].gameObject.SetActive (true);

			TopList [0].gameObject.SetActive (false);	
			TopList [2].gameObject.SetActive (false);
			TopList [3].gameObject.SetActive (false);
			break;
		
		case 2:
			TopList [2].gameObject.SetActive (true);

			TopList [0].gameObject.SetActive (false);	
			TopList [1].gameObject.SetActive (false);	
			TopList [3].gameObject.SetActive (false);
			break;
		
		case 3:
			TopList [3].gameObject.SetActive (true);

			TopList [0].gameObject.SetActive (false);	
			TopList [1].gameObject.SetActive (false);	
			TopList [2].gameObject.SetActive (false);	
			break;
		}

		switch (Body) 
		{
		case 0:
			BodyList [0].gameObject.SetActive (true);	

			BodyList [1].gameObject.SetActive (false);
			BodyList [2].gameObject.SetActive (false);
			break;

		case 1:
			BodyList [1].gameObject.SetActive (true);	

			BodyList [0].gameObject.SetActive (false);
			BodyList [2].gameObject.SetActive (false);
			break;
		case 2:
			BodyList [2].gameObject.SetActive (true);		

			BodyList [0].gameObject.SetActive (false);
			BodyList [1].gameObject.SetActive (false);
			break;
		}
		switch (Head) 
		{
		case 0:
			HeadList [0].gameObject.SetActive (true);		

			HeadList [1].gameObject.SetActive (false);
			HeadList [2].gameObject.SetActive (false);
			break;
		case 1:
			HeadList [1].gameObject.SetActive (true);	

			HeadList [0].gameObject.SetActive (false);
			HeadList [2].gameObject.SetActive (false);
			break;
		case 2:
			HeadList [2].gameObject.SetActive (true);		

			HeadList [0].gameObject.SetActive (false);
			HeadList [1].gameObject.SetActive (false);
			break;
		}

		switch (Item) 
		{
		case 0:
			ItemList [0].gameObject.SetActive (true);	

			ItemList [1].gameObject.SetActive (false);
			ItemList [2].gameObject.SetActive (false);
			ItemList [3].gameObject.SetActive (false);
			break;
		case 1:
			ItemList [1].gameObject.SetActive (true);	

			ItemList [0].gameObject.SetActive (false);
			ItemList [2].gameObject.SetActive (false);
			ItemList [3].gameObject.SetActive (false);
			break;
		case 2:
			ItemList [2].gameObject.SetActive (true);	

			ItemList [0].gameObject.SetActive (false);
			ItemList [1].gameObject.SetActive (false);
			ItemList [3].gameObject.SetActive (false);
			break;
		case 3:
			ItemList [3].gameObject.SetActive (true);		

			ItemList [0].gameObject.SetActive (false);
			ItemList [1].gameObject.SetActive (false);
			ItemList [2].gameObject.SetActive (false);
			break;
		}
	}

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	void OnDisable()
	{
		
	}
}
