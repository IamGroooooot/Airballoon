using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {

	public GameObject _Enter;

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
		if (ColStay.gameObject.tag == "Player") {
			_Enter.gameObject.SetActive (true);
		}
	}
	void OnTriggerExit(Collider ColExit)
	{
		if (ColExit.gameObject.tag == "Player") {
			_Enter.gameObject.SetActive (false);
		}
	}
}
