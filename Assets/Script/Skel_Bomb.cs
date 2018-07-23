using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skel_Bomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("ShipBody");

		Vector3 wherToFire = player.transform.position - transform.position; 
		GetComponent<Rigidbody> ().velocity = wherToFire *3;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision C){
		if (C.gameObject.tag == "Player" || C.gameObject.tag == "ShipBody") {
			C.gameObject.GetComponent<HP_Bar> ().IsDamaged = true;
			Destroy (this.gameObject);
		}

	}

}
