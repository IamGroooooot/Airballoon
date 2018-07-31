﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ballon Ship에 대한 스크립트 : 폭탄 투하하게 함

public class Ball_CtrlOnDetact : MonoBehaviour {

	public Transform PlayerTrans; //플레이어
    public GameObject Skel; //스켈레톤이 있는 열기구 설정

	public GameObject bomb; //발사할 스켈레톤의 폭탄 prefab
    
	private int time2;
    private float time1;
    public bool canAttack,fire,TimerOn;

	public float speed = 5f;
    private Vector3 myPosition;
    private Quaternion myRotation;

    //해골이 던지는 폭탄에 대한 설정 값
    public float angle_degr = 60f; //기본각도를 60도로 설정
    private GameObject Skel_Bomb;
    Vector3 BombInitVelocity;
    Vector3 displace;
    float distance;
    Vector3 playerPos;

    void Start () {
		canAttack = false;
		fire = false;

        myPosition = new Vector3(0, 0, 0);
        myRotation = new Quaternion(0, 0, 0, 0);
        time1 = 0;
        time2 = 0;
        angle_degr = angle_degr * Mathf.Deg2Rad;// Deg2Rad
    }
	
	// Update is called once per frame
	void Update () { 
        myPosition = Skel.transform.position;
        myRotation = Skel.transform.rotation;

        transform.position = myPosition;
        transform.rotation = myRotation;

        if (canAttack)
        {
            Vector3 targetDir = PlayerTrans.position - Skel.transform.position;

            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(Skel.transform.forward, targetDir, step, 0.0f);
            Quaternion rotation = Quaternion.LookRotation(newDir);

            //Skel.transform.rotation = Quaternion.Lerp(Skel.transform.rotation, rotation, step);           //rotation 처음에 끊김
            Skel.transform.rotation = Quaternion.RotateTowards(Skel.transform.rotation, rotation, step);

            time1 =time1+(speed  * Time.deltaTime);

            if (time1>(1/step))
            {
                TimerOn = true;
            }

        }
        else
        {
            TimerOn = false;
            time1 = 0;
        }


		if (TimerOn)
        {
			time2++;
			if (time2 == 3 *60)
            {
				fire = true;
			}
		}

		if (fire) {
			//인스턴트화하고 폭탄 스크립트에 폭탄 발사 넣기
			Skel_Bomb = Instantiate(bomb, Skel.transform.position + (Skel.transform.forward*20) ,Skel.transform.rotation) as GameObject;
            FireSkelBomb(Skel_Bomb);
			Debug.Log ("인스턴스화 완료");
            time2 = 0;
			fire = false;
		}
	}


	void OnTriggerStay(Collider C){
		if(C.gameObject.tag == "Player")
			canAttack = true;
	}

	void OnTriggerExit(Collider C){
		if (C.gameObject.tag == "Player") {
			canAttack = false;
			TimerOn = false;
		}
	}


    //포물선으로 쏘는것
    void FireSkelBomb(GameObject Bomb)
    {
        playerPos = new Vector3(PlayerTrans.position.x, PlayerTrans.position.y-10f, PlayerTrans.position.z);
        displace = playerPos - transform.position;
        distance = Mathf.Pow((displace.x) * (displace.x) + (displace.z) * (displace.z), 0.5f); //수평도달거리 계산

        BombInitVelocity = new Vector3(displace.x, distance * Mathf.Tan(angle_degr), displace.z).normalized; //내가 포물선으로 쏠 벡터의 단위벡터 계산
        BombInitVelocity = BombInitVelocity * Mathf.Sqrt(  Mathf.Abs(Physics.gravity.y) * distance / Mathf.Sin(2*angle_degr)  ); //물리식 속도는 중력에 비례하기 때문에 *중력 수정함*

        Bomb.GetComponent<Rigidbody>().velocity = BombInitVelocity; //폭탄 인스턴트에 속도 부여

        Destroy(Bomb.gameObject, 5f);
    }
}