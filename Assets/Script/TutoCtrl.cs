using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCtrl : MonoBehaviour {

	public GameObject Tuto;

	// Update is called once per frame
	void Update () {
		if (PlayerDB.DB.Tuto == false) {
			Tuto.gameObject.SetActive (true);
		} else {
			Tuto.gameObject.SetActive (false);
		}
	}
}
