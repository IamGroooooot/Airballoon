using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ballon Ship에 대한 스크립트 : 폭탄 투하하게 함

public class Bal_Ship : MonoBehaviour {

	public Transform PlayerTrans;
    public GameObject Skel;

	public GameObject bomb;

//	private Transform MyTrans;
//	private Rigidbody MyRigid;
	private int time;
	private Vector3 distance;
	public bool canAttack,fire,TimerOn;

	public float speed = 5f;
    private Vector3 myPosition;
    private Quaternion myRotation;

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

;
            Skel.transform.rotation = Quaternion.Lerp (Skel.transform.rotation, rotation, step);

			float MyAngle = Skel.transform.eulerAngles.y;
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
			}

		}
		if (fire) {
			//인스턴트화하고 폭탄 스크립트에 폭탄 발사 넣기
			Instantiate(bomb, Skel.transform.position + (Skel.transform.forward*20),Skel.transform.rotation);
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
}
