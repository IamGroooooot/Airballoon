using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible()

	{
		Off ();
	}

	void OnBecameVisible()

	{
		ON ();
	}

	void Off()
	{
		this.gameObject.SetActive (false);		
	}
		
	void ON()
	{
		this.gameObject.SetActive (true);		
	}
}
