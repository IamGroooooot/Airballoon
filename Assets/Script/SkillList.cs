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


	void Awake(){
		
		Skill_List = this;
	}

	//쿨타임은 해당스킬 버튼 ~초(변수:스킬마다 다르게 설정 후 대입)동안 
	//비활성화 시키면서 시간 뜨게하고, 
	//색 어둡게 변경하면 될듯!

	//Using Skill List
	void Repair () 
	{
		//전체 체력의 10%를 수리한다. 쿨타임 20초, 소모품:(Item갯수 -1)
		//(Code)~번 스킬 창 쿨타임 ON (20초)
		PlayerDB.DB.cur_Health = PlayerDB.DB.cur_Health + (PlayerDB.DB.max_Health*0.1f);

	}

	void Booster () 
	{
		// 일시적으로 속도를 150% 증가시킨다, 소모품
		//(Code)~번 스킬 창 쿨타임 ON (20초)
		PlayerDB.DB.max_Speed+= (PlayerDB.DB.max_Speed*0.5f);
		// (Code)임시 카운트(2초) 이후 속도 그대로
		PlayerDB.DB.max_Speed-=(PlayerDB.DB.max_Speed*0.5f);

	}

	void Shield()
	{
		//임시 방어막을 생성한다, 소모품
		shield.gameObject.SetActive(true);
		//(Code)~번 스킬 창 쿨타임 ON (5초)
		//(Code) Lasting Time(2sec)이후 비활성화

	}

	//Instantiate Skill List
	void Drone()
	{
		//드론을 생성한다,소모품
		Instantiate(drone,PlayerTr);
		//(Code)~번 스킬 창 쿨타임 ON (15초)
		//드론은 10초 후에 자동 소멸(SetActive(false)) : Drone Script참조
	}

	void Balloon()
	{
		//풍선을 생성한다, 소모품
		//(Code)~번 스킬 창 쿨타임 ON (2초)
		Instantiate(balloon,PlayerTr);
	}

	void Rain()
	{
		//비구름 생성, 소모품
		//(Code)~번 스킬 창 쿨타임 ON (8초)
		Instantiate(rain,PlayerTr2);
	}

	void SpeedCloud()
	{
		//근두운 생성, 소모품
		//(Code)~번 스킬 창 쿨타임 ON (8초)
		Instantiate(speed,PlayerTr2);
	}

	void Thunder()
	{
		//번개구름생성, 소모품
		//(Code)~번 스킬 창 쿨타임 ON (8초)
		Instantiate(thunder,PlayerTr2);
	}
		
	//Fire Skill List - ReadyFire Obj생성 후 위치 선정되면 스킬 구현
	void Anchor()
	{
		// 닻 발사
		anchor.gameObject.SetActive(true);
	}
		
	void Chain()
	{
		chain.gameObject.SetActive(true);
	}

	void WaterBomb()
	{
		water.gameObject.SetActive (true);
	}
}
