using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour {

	void OnTriggerEnter(Collider CollEnter)
	{

		OnTriggerStay (CollEnter);

	}
	void OnTriggerStay(Collider CollStay){
		if (CollStay.gameObject.tag == "Player") {
			GameObject Player = CollStay.gameObject;
			Debug.Log ("나나가가ㅏㅏ나");

			Player.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0,0,0);
			Player.transform.position = CollStay.transform.position + (CollStay.transform.forward * 200);
			Player.gameObject.transform.eulerAngles = transform.eulerAngles;
		}
	}
}
