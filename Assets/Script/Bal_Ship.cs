using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ballon Ship에 대한 스크립트 : 폭탄 투하하게 함

public class Bal_Ship : MonoBehaviour {

	public Transform PlayerTrans;

	public GameObject bomb;

	private Transform MyTrans;
	private Rigidbody MyRigid;
	private int time;
	private Vector3 distance;
	public bool canAttack,fire,TimerOn;

	public float speed = 5f;


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
		MyTrans = gameObject.GetComponent<Transform>();
		MyRigid = GetComponent<Rigidbody>();
		//MyRigid.maxAngularVelocity = 1;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (canAttack) {
			Vector3 targetDir = PlayerTrans.position - MyTrans.position;

			float step = speed * Time.deltaTime;

			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
			Debug.DrawRay (transform.position, newDir, Color.red);
			Quaternion rotation = Quaternion.LookRotation (newDir);
			//transform.rotation = Quaternion.LookRotation (newDir);

			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, step);

			float MyAngle = MyTrans.eulerAngles.y;
			float PlayerAngle = PlayerTrans.eulerAngles.y;

			float RotAngle = PlayerAngle - MyAngle;

			if (Mathf.Abs (RotAngle) < 110 && Mathf.Abs (RotAngle) > 89) {
				TimerOn = true;
			}
//			if (Mathf.Abs(RotAngle) > 180)
//			{
//				if (RotAngle > 0)
//				{ //270
//					RotAngle = RotAngle - 360;
//				}
//				else if (RotAngle < 0)
//				{
//					RotAngle = RotAngle + 360;
//				}
//			}
//			if (RotAngle > 1) {
//				//MyRigid.AddTorque (0, Mathf.Clamp (1.5f + 5 * RotAngle / 180f, 0, 1), 0);
//			} else if (RotAngle < -1) {
//				//MyRigid.AddTorque (0, Mathf.Clamp (-1.5f + 5 * RotAngle / 180f, -1, 0), 0);
//			} else {
//				MyRigid.angularVelocity = new Vector3 (0, 0, 0);
//				TimerOn = true;
//			}

		}
		if (TimerOn) {
			
			time++;
			if (time == 3 *60) {
				fire = true;
				time = 0;
			}

		}
		if (fire) {
			//인스턴트화하고 폭탄 스크립트에 폭탄 발사 넣기
			Instantiate(bomb, MyTrans.transform.position + (MyTrans.transform.forward*10),transform.rotation);
			Debug.Log ("인스턴스화 완료");
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




}
