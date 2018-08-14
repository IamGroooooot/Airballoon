using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour{

	public static SkillList Skill_List;

	public GameObject shield;
	public GameObject anchor;
	public GameObject drone;
	public GameObject balloon;
	public GameObject rain;
	public GameObject thunder;
	public GameObject speed;
	public GameObject water;
	public GameObject chain;

	public Transform PlayerTr;
	public Transform PlayerTr2;

	public float cool0 = 20f;
	public float cool1 = 20f;
	public float cool2 =2f;
	public float cool3 =15f;
	public float cool4 = 2f;
	public float cool5 =8f;
	public float cool6 = 8f;
	public float cool7 = 8f;
	public float cool8 = 15f;
	public float cool9 = 15f;
	public float cool10 = 15f;


	void Awake(){
		
		Skill_List = this;
	}
 
	//색 어둡게 변경하면 될듯!

	//Using Skill List
	public void Repair () //0 쿨20초
	{
		//소모품:(Item갯수 -1)
	
		HP_Bar.IsHeal = true;
		Debug.Log ("Repair성공");
	}

	public void Booster () //1 쿨20초
	{
		// 소모품
		Joystick2.max_Speed = PlayerDB.DB.max_Speed;
		Joystick2.BoostRate = 1.5f; // 150%증가
		Joystick2.BoostTime = 2f;
		Joystick2.BoostTimerOn = true;

	}

	public void Shield() //2 쿨2초
	{
		//임시 방어막을 생성한다, 소모품
		shield.gameObject.SetActive(true);
		//(Code) Lasting Time(2sec)이후 비활성화 : 스크립트달아야할듯

	}

	//Instantiate Skill List
	public void Drone() //3
	{
		//드론을 생성한다,소모품
		Instantiate(drone,PlayerTr);
		//드론은 10초 후에 자동 소멸(SetActive(false)) : Drone Script참조

	}

	public void Balloon() //4
	{
		//풍선을 생성한다, 소모품
		Instantiate(balloon,PlayerTr);

	}

	public void Rain() //5
	{
		//비구름 생성, 소모품
		Instantiate(rain,PlayerTr2);

	}

	public void SpeedCloud() //6
	{
		//근두운 생성, 소모품
		Instantiate(speed,PlayerTr2);

	}

	public void Thunder() //7
	{
		//번개구름생성, 소모품
		Instantiate(thunder,PlayerTr2);

	}
		
	//Fire Skill List - ReadyFire Obj생성 후 위치 선정되면 스킬 구현
	public void Anchor() //8
	{
		// 닻 발사
		anchor.gameObject.SetActive(true);

	}

	public void WaterBomb() //9
	{
		water.gameObject.SetActive (true);

	}

	public void Chain() //10
	{
		chain.gameObject.SetActive(true);

	}


}
