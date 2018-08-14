using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirShipCtrl : MonoBehaviour {
	Transform target;
	// Use this for initialization
	void Start () {
		target = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		FaceTarget ();
		GetComponent<Rigidbody> ().velocity= transform.forward*5f;
	}

	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;

		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x,0,direction.z));
		transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *20f);
	}
}
