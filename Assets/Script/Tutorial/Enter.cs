using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {

	public GameObject _Enter;

	void OnTriggerEnter(Collider ColEnter)
	{
		if (ColEnter.gameObject.tag == "Player") 
		{
            Tuto.Tutorial.EnterCircle = true;
		}
	}		
}
