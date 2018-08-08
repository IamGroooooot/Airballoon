using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {

	public GameObject _Enter;

	// Use this for initialization
	void Start () {

	}
		
	void OnTriggerEnter(Collider ColEnter)
	{
		if (ColEnter.gameObject.tag == "Player") 
		{
			Debug.Log ("Enter");
			_Enter.gameObject.SetActive (true);
			OnTriggerStay (ColEnter);
		}
	}		
	void OnTriggerStay(Collider ColStay)
	{
		if (ColStay.gameObject.tag == "Player") 
		{
			_Enter.gameObject.SetActive (true);
		}
	}
}
