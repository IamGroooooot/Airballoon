using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ballon Ship에 대한 스크립트 : 폭탄 투하하게 함
//최적화 O


public class Ball_CtrlOnDetact : MonoBehaviour {

	private Transform PlayerTrans; //플레이어

    public GameObject Skel; //스켈레톤이 있는 열기구 설정

	//public GameObject bomb; //발사할 스켈레톤의 폭탄 prefab
    public float followSpeed = 50f;

    private int time2;
    private float time1;
    public bool canAttack,fire,TimerOn;

	public float speed = 5f;
    private Vector3 myPosition;
    private Quaternion myRotation;
	private Rigidbody Rb;

    //해골이 던지는 폭탄에 대한 설정 값
    public float angle_degr = 60f; //기본각도를 60도로 설정
    private GameObject Skel_Bomb;
    Vector3 BombInitVelocity;
    Vector3 displace;
    float distance;
    Vector3 playerPos;

    void Start () {


		PlayerTrans = PlayerManager.instance.player.transform.GetChild(0);


        canAttack = false;
		fire = false;

        myPosition = new Vector3(0, 0, 0);
        myRotation = new Quaternion(0, 0, 0, 0);
        time1 = 0;
        time2 = 0;
        angle_degr = angle_degr * Mathf.Deg2Rad;// Deg2Rad
    }
	void OnEnable()
    {
        canAttack = false;


    }
	// Update is called once per frame
	void Update () { 
        myPosition = Skel.transform.position;
        myRotation = Skel.transform.rotation;

        transform.position = myPosition;
        transform.rotation = myRotation;


        if (canAttack)
        {
			Vector3 PlayerPosForRotation = new Vector3 (PlayerTrans.position.x,Skel.transform.position.y,PlayerTrans.position.z);
			Vector3 targetDir = PlayerPosForRotation - Skel.transform.position;

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
			Skel.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
        }
        else
        {

            PlayerFollower(); //여기에 빨로빨로미

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
			GameObject bomb = ObjectPooling.pool.GetPoolObject_SkelBomb ();
			if (bomb == null) return;

			bomb.transform.position = Skel.transform.position + (Skel.transform.forward * 20);
			bomb.transform.rotation = Skel.transform.rotation;
			bomb.SetActive (true);

			//Skel_Bomb = Instantiate(bomb, Skel.transform.position + (Skel.transform.forward*20) ,Skel.transform.rotation) as GameObject;
            FireSkelBomb(bomb);
			//Debug.Log ("인스턴스화 완료");
            time2 = 0;
			fire = false;
		}

        

    }

    void PlayerFollower() //플레이어 빨로우 하는 함수
    {
        Skel.GetComponent<Rigidbody>().velocity = (PlayerTrans.position - Skel.transform.position).normalized * followSpeed;
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
        playerPos = PlayerTrans.position;
        displace = playerPos - transform.position;
        distance = Mathf.Pow((displace.x) * (displace.x) + (displace.z) * (displace.z), 0.5f); //수평도달거리 계산

        BombInitVelocity = new Vector3(displace.x, distance * Mathf.Tan(angle_degr), displace.z).normalized; //내가 포물선으로 쏠 벡터의 단위벡터 계산
        BombInitVelocity = BombInitVelocity * Mathf.Sqrt(  Mathf.Abs(Physics.gravity.y) * distance / Mathf.Sin(2*angle_degr)  ); //물리식 속도는 중력에 비례하기 때문에 *중력 수정함*

        Bomb.GetComponent<Rigidbody>().velocity = BombInitVelocity; //폭탄 인스턴트에 속도 부여
		Bomb.GetComponent<TrailRenderer> ().Clear();
		//Bomb.gameObject.SetActive (false);
    }
}
