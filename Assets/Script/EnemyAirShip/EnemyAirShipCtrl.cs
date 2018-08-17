using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirShipCtrl : MonoBehaviour {
	Transform target;
	float DistanceIS;
	// Use this for initialization
	void Start () {
		target = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		DistanceIS = Vector3.Distance (target.position,transform.position);

		//Debug.Log (DistanceIS);
		if (DistanceIS > 300f) { 
			FaceTarget ();
			GetComponent<Rigidbody> ().velocity= transform.forward*300f;
		}
		else 
		{
			
			TurnTarget ();
			GetComponent<Rigidbody> ().velocity= transform.forward*150f;
		}



	}

	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;

		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x,0,direction.z));
		transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *70f);
	}

	void TurnTarget()
	{

	
		Vector3 direction = (target.position - transform.position).normalized;

		float innerProduct = Mathf.Abs(Vector3.Dot(direction,target.transform.forward.normalized));
		Debug.Log (innerProduct);
		if (innerProduct <= 0.9f) {//turn To be SideBySide => 포탄 쏨 가능. 여기에 선회하는거 넣으면 됨.
			RotationToCircle();
			Debug.Log("돌아라");
		} else { //거의 수평 방향 볼 때
			Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x,0,direction.z));
			transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *35f);
		}



	}

	void RotationToCircle()
	{
		Vector3 Turndirection = target.transform.forward.normalized;

		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(Turndirection.x,0,Turndirection.z));
		transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *200f);


	}
}
