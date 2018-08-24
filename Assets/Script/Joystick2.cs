using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 조이스틱 정의, 조이스틱 값을 이용하여 배의 움직임 제어(ADDFORCE)
// 플레이어 회전을 토크로 구현 (ADDTORQUE)

public class Joystick2 : MonoBehaviour {

	// 공개
	private Transform Player;        // 플레이어.
	private Rigidbody RB_Player;		
	public static float max_Speed;//속도 제한
	public float rotationSpeed;//선회 속도
	public Transform Stick;         // 조이스틱.
	//부스터 스킬
	public static bool BoostTimerOn;
	public static float BoostTime;
	public static float BoostRate;

	private float OriginSpeed;
	// 비공개
	private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
	private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
	private float Radius;           // 조이스틱 배경의 반 지름.
	private bool MoveFlag;          // 플레이어 움직임 스위치.


	void Start()
	{
		BoostTimerOn = false;
		BoostTime = 2f;
		BoostRate = 1.5f;


		Player = PlayerManager.instance.player.transform; //.parent
		RB_Player = PlayerManager.instance.player.transform.GetComponent<Rigidbody>();

		max_Speed = PlayerDB.DB.max_Speed;
		rotationSpeed = PlayerDB.DB.rotationSpeed;


		Radius = GetComponent<RectTransform>().sizeDelta.y * 0.15f;
		StickFirstPos = Stick.transform.position;

		// 캔버스 크기에대한 반지름 조절.
		float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
		Radius *= Can;

		MoveFlag = false;

    }
	void Update(){
		if (BoostTimerOn) //빠르게
		{
			BoostTime -= Time.deltaTime;
            Player.Translate(-1f*Player.right * 10f);
            if (BoostTime <= 0) //느리게
			{
				BoostTimerOn = false;
			}

		}

	}

	//조이스틱방향으로 ADDFORCE
	void FixedUpdate() {

		if (MoveFlag) {
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
			//Stick.GetComponent<RectTransform> ().anchoredPosition = StickFirstPos+ JoyVec * Dis;
			Stick.position = StickFirstPos + JoyVec * Dis;

		// 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
		else
			//Stick.GetComponent<RectTransform> ().anchoredPosition = StickFirstPos + JoyVec * Radius;
			Stick.position = StickFirstPos + JoyVec * Radius;
	}


	// 드래그 끝.
	public void DragEnd()
	{
		Stick.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;
		//Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
		StickFirstPos = Stick.transform.position;
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
        {
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