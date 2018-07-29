using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ballon Ship에 대한 스크립트 : 폭탄 투하하게 함

public class Ball_CtrlOnDetact : MonoBehaviour {

	public Transform PlayerTrans; //플레이어
    public GameObject Skel; //스켈레톤이 있는 열기구 설정

	public GameObject bomb; //발사할 스켈레톤의 폭탄 prefab
    
	private int time;
	public bool canAttack,fire,TimerOn;

	public float speed = 5f;
    private Vector3 myPosition;
    private Quaternion myRotation;

    //해골이 던지는 폭탄에 대한 설정 값
    public float angle_degr = 45f; //기본각도를 45도로 설정0.0174532924
    public float bombSpeed = 1f;
    private GameObject Skel_Bomb;
    Vector3 BombInitVelocity;
    Vector3 displace;
    float distance;
    Vector3 playerPos;


    //	public GameObject currentHitObject;
    //
    //	public float sphereRadius;
    //	public float maxDistance;
    //	public LayerMask layerMask;
    //
    //	private Vector3 origin;
    //	private Vector3 direction;
    //
    //	private float currentHitDistance;
    //


    // Use this for initialization
    void Start () {
		canAttack = false;
		fire = false;
        //		MyTrans = Skel.GetComponent<Transform>();
        myPosition = new Vector3(0, 0, 0);
        myRotation = new Quaternion(0, 0, 0, 0);
		time = 0;
        angle_degr = angle_degr * Mathf.Deg2Rad;// Deg2Rad
    }
	
	// Update is called once per frame
	void Update () { 
        myPosition = Skel.transform.position;
        myRotation = Skel.transform.rotation;

        transform.position = myPosition;
        transform.rotation = myRotation;

		if (canAttack) {
			Vector3 targetDir = PlayerTrans.position - Skel.transform.position;

			float step = speed * Time.deltaTime;

			Vector3 newDir = Vector3.RotateTowards (Skel.transform.forward, targetDir, step, 0.0f);
			Quaternion rotation = Quaternion.LookRotation (newDir);
			//transform.rotation = Quaternion.LookRotation (newDir);

            Skel.transform.rotation = Quaternion.Lerp (Skel.transform.rotation, rotation, step);

			float MyAngle = Skel.transform.eulerAngles.y;
			float PlayerAngle = PlayerTrans.eulerAngles.y;

			float RotAngle = PlayerAngle - MyAngle;

			if (Mathf.Abs (RotAngle) < 110 && Mathf.Abs (RotAngle) > 89) {
				TimerOn = true;
			}
		}

		if (TimerOn) {
			
			time++;
			if (time == 3 *60) {
				fire = true;
			}

		}
		if (fire) {
			//인스턴트화하고 폭탄 스크립트에 폭탄 발사 넣기
			Skel_Bomb = Instantiate(bomb, Skel.transform.position + (Skel.transform.forward*20) ,Skel.transform.rotation) as GameObject;
            FireSkelBomb(Skel_Bomb);
			Debug.Log ("인스턴스화 완료");
            time = 0;
			fire = false;
		}

//		origin = transform.position;
//		direction = transform.forward;
//
//		RaycastHit hit;
//		if(Physics.SphereCast(origin,sphereRadius,direction,out hit,maxDistance,layerMask,QueryTriggerInteraction.UseGlobal)){
//			currentHitObject = hit.transform.gameObject;
//			currentHitDistance = hit.distance;
//		}  else{
//			currentHitDistance = maxDistance;
//			currentHitObject = null;
//		}
	}


//	private void OnDrawGizmosSelected(){
//		Gizmos.color = Color.red;
//		Debug.DrawLine (origin, origin + direction * currentHitDistance);
//		Gizmos.DrawWireSphere (origin + direction * currentHitDistance,sphereRadius);
//	}

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

    void FireSkelBomb(GameObject Bomb)
    {
        
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 33f, player.transform.position.z);
        playerPos = new Vector3(PlayerTrans.position.x, PlayerTrans.position.y, PlayerTrans.position.z); //보정값
        //안바뀜
        displace = playerPos - transform.position;
        //안바뀜
        distance = Mathf.Pow((displace.x) * (displace.x) + (displace.z) * (displace.z), 0.5f);
        //아래에서 오류발생
        BombInitVelocity = new Vector3(displace.x, distance * Mathf.Tan(angle_degr), displace.z).normalized;
        Debug.Log("Nomal Vector체크 " + BombInitVelocity);
        //위에서 오류 발생, y축 속도가 누락?됨
        

        BombInitVelocity = BombInitVelocity * Mathf.Sqrt( Mathf.Abs(Physics.gravity.y)*distance/Mathf.Cos(angle_degr) );

        //Debug.Log("변위벡터는 " + displace);
        //Debug.Log("거리는 " + distance);
        Debug.Log("최종 초기 속력 값은 ? " + BombInitVelocity);
        Bomb.GetComponent<Rigidbody>().velocity = BombInitVelocity * bombSpeed;//강체를 찾을 수 없음?????

        Destroy(Bomb.gameObject, 5f);
    }

}
