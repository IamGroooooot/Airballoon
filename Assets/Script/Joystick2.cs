﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 조이스틱 정의, 조이스틱 값을 이용하여 배의 움직임 제어(ADDFORCE ADDTORQUE 사용함)

public class Joystick2 : MonoBehaviour {

	// 공개
	public Transform Player;        // 플레이어.
	public Rigidbody RB_Player;		
	public static float max_Speed = 300.0f;//속도 제한
	public float rotationSpeed = 100f;//선회 속도
	public Transform Stick;         // 조이스틱.


	// 비공개
	private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
	private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
	private float Radius;           // 조이스틱 배경의 반 지름.
	private bool MoveFlag;          // 플레이어 움직임 스위치.
	//int count = 0;


	void Start()
	{
		Radius = GetComponent<RectTransform>().sizeDelta.y * 0.15f;
		StickFirstPos = Stick.transform.position;

		// 캔버스 크기에대한 반지름 조절.
		float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
		Radius *= Can;

		MoveFlag = false;

    }

	void Update()
	{
		//Debug.Log (Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg+360);
	}
	//조이스틱방향으로 ADDFORCE
	void FixedUpdate() {

		if (MoveFlag) {
			//Player.transform.Translate(0,0,1* Time.deltaTime * 100f);
			//R	B_Player.velocity = Player.forward * 1 * Time.deltaTime * 10000f;
			if (Mathf.Abs (RB_Player.velocity.z) < max_Speed) {
				RB_Player.AddForce (Player.forward * 1 * 100f); //앞으로 가기 
			}

            RotateShip();
		}

	}

	// 드래그
	public void Drag(BaseEventData _Data)
	{
		MoveFlag = true;
		PointerEventData Data = _Data as PointerEventData;
		Vector3 Pos = Data.position;

		// 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
		JoyVec = (Pos - StickFirstPos).normalized;

		// 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
		float Dis = Vector3.Distance(Pos, StickFirstPos);

		// 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는 곳으로 이동.
		if (Dis < Radius)
			Stick.position = StickFirstPos + JoyVec * Dis;
		// 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
		else
			Stick.position = StickFirstPos + JoyVec * Radius;
	}


	// 드래그 끝.
	public void DragEnd()
	{
		Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
		JoyVec = Vector3.zero;          // 방향을 0으로.
		MoveFlag = false;
	}

	//배의 회전 구현
    public void RotateShip()
    {
        //Player.eulerAngles = new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0); 

		//위는 바로 돌리는 함수
//------------------------------------------------------------------------------------------------------//
		//아래는 토크를 이용하여 돌게만드는 함수

        //RB_Player.AddTorque(0,Player.eulerAngles.y-(360-Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg), 0);
        if (Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg > 0)
        {//0~180
            float JAngle = Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg;//조이스틱 각
            float MyAngle = Player.eulerAngles.y;
            float RotAngle = JAngle - MyAngle;
            if (Mathf.Abs(RotAngle) > 180)
            {
                if (RotAngle > 0)
                { //270
                    RotAngle = RotAngle - 360;
                }
                else if (RotAngle < 0)
                {
                    RotAngle = RotAngle + 360;
                }
            }
            if (RotAngle > 0)
            {
                RB_Player.AddTorque(0, 0.05f + RotAngle / 180f, 0);
            }
            else if (RotAngle < 0)
            {
                RB_Player.AddTorque(0, -0.05f + RotAngle / 180f, 0);
            }

        }
        else
        {                  //Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg+360 // 180~360
            float JAngle = Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg + 360; //조이스틱 각
            float MyAngle = Player.eulerAngles.y;
            float RotAngle = JAngle - MyAngle;
            if (Mathf.Abs(RotAngle) > 180)
            {
                if (RotAngle > 0)
                { //270
                    RotAngle = RotAngle - 360;
                }
                else if (RotAngle < 0)
                {
                    RotAngle = RotAngle + 360;
                }
            }
            if (RotAngle > 0)
            {
                RB_Player.AddTorque(0, 0.05f + RotAngle / 180f, 0);
            }
            else if (RotAngle < 0)
            {
                RB_Player.AddTorque(0, -0.05f + RotAngle / 180f, 0);
            }
        }
    }

}