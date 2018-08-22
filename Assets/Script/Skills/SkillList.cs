using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour{

	public static SkillList Skill_List;

    public GameObject heal;
    public GameObject booster;
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

	public float RainLastTime = 15;
	public float ThunderLastTime = 15;
    public float SpeedCloudLastTime = 15f;



    void Awake(){
		
		Skill_List = this;
	}
 
	//색 어둡게 변경하면 될듯!

	//Using Skill List
	public void Repair () //0 쿨20초
	{
		HP_Bar.IsHeal = true;
		Debug.Log ("Repair성공");
        heal.gameObject.SetActive(true);

        //string DescriptionKor = "10% 회복한다";
	}

	public void Booster () //1 쿨20초
	{
		Joystick2.max_Speed = PlayerDB.DB.max_Speed;
		Joystick2.BoostRate = 2.0f; // 200%증가
		Joystick2.BoostTime = 3f;
		Joystick2.BoostTimerOn = true;
        booster.gameObject.SetActive(true);
        //string DescriptionKor = "일시적으로 속도가 증가한다";
    }

	public void Shield() //2 쿨2초
	{
		shield.gameObject.SetActive(true);
		StartCoroutine(LastTime(shield,2f));
        //string DescriptionKor = "방어막을 생성한다";
    }

	//Instantiate Skill List
	public void Drone() //3
	{
        //GameObject myDrone = Instantiate(drone,PlayerTr);
        GameObject Drone = ObjectPooling.pool.GetPoolObject_Drone_skill();
        if (Drone == null) return;

        Drone.transform.position = PlayerTr.position;
        Drone.transform.rotation = PlayerTr.rotation;

        Drone.SetActive(true);
		StartCoroutine(LastTime(Drone, 15f));
        //string DescriptionKor = "드론을 생성한다";
    }

	public void Balloon() //4
	{
        //GameObject myBalloon = Instantiate(balloon,PlayerTr);
        //myBalloon.SetActive (true);

        GameObject Bomb = ObjectPooling.pool.GetPoolObject_AirBomb();
        if (Bomb == null) return;
        Bomb.transform.position = PlayerTr.position;
        Bomb.transform.rotation = PlayerTr.rotation;

        Bomb.SetActive(true);
        //string DescriptionKor = "풍선 폭탄을 생성한다";
    }

	public void Rain() //5 비구름
	{
        //GameObject myRain = Instantiate(rain,PlayerTr2);
        //myRain.SetActive (true);
        //SlowParticle.play()
        GameObject myRain = ObjectPooling.pool.GetPoolObject_Rain_skill();
        if (myRain == null) return;
        myRain.transform.position = PlayerTr2.position;
        myRain.transform.rotation = PlayerTr2.rotation;

        StartCoroutine(LastTime(myRain,RainLastTime));
       // string DescriptionKor = "적을 느려지게 하는 비구름을 생성한다";
    }

	public void SpeedCloud() //6
	{
        GameObject mySpeed = ObjectPooling.pool.GetPoolObject_Cloud();
        if (mySpeed == null) return;
        mySpeed.transform.position = PlayerTr2.position;
        mySpeed.transform.rotation = PlayerTr2.rotation;

        StartCoroutine(LastTime(mySpeed, SpeedCloudLastTime));
        //string DescriptionKor = "?";
    }

	public void Thunder() //7
	{
        //GameObject myThunder = Instantiate(thunder,PlayerTr2);
        //myThunder.SetActive (true);
        GameObject myThunder = ObjectPooling.pool.GetPoolObject_Thunder_skill();
        if (myThunder == null) return;
        myThunder.transform.position = PlayerTr2.position;
        myThunder.transform.rotation = PlayerTr2.rotation;

        StartCoroutine(LastTime(myThunder,ThunderLastTime));
        //string DescriptionKor = "적을 감전시키는 번개구름을 생성한다";
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


	IEnumerator LastTime(GameObject go,float lastingTime)
	{
		yield return new WaitForSeconds (lastingTime);
		Debug.Log (go.name + "나 소멸");
		go.SetActive (false);

	}

}
