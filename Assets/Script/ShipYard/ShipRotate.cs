using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotate : MonoBehaviour {

	float speed = 2f;

	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3 (0, 45, 0) * speed * Time.deltaTime);	
	}
}
