using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skel_Bomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		Vector3 whereToFire = player.transform.position - transform.position; 
		GetComponent<Rigidbody> ().velocity = whereToFire *3;
        Destroy(this.gameObject,5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision C){
		if (C.gameObject.tag == "Player") {
			C.gameObject.GetComponent<HP_Bar> ().IsDamaged = true;
			Destroy (this.gameObject);
		}
	}

}
