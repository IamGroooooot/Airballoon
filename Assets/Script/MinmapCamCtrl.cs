using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinmapCamCtrl : MonoBehaviour {

	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 newPos =PlayerManager.instance.player.transform.position;
		GetComponent<Transform> ().position =  new Vector3(newPos.x,newPos.y+3000,newPos.z);
		transform.eulerAngles = new Vector3 (90, 0, 0);
	}

}
