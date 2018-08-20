using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIsland : MonoBehaviour {
	public float IslandSpeed=100f;
	private Transform playerTrans;
	Vector3 nearPlayerPos;
	WindArea mWindArea;
	float X, Z;

	void Update(){





	


	}
	// Use this for initialization
	void OnEnable ()
	{
		mWindArea = GameObject.FindGameObjectWithTag("WindArea").GetComponent<WindArea>();


		X =mWindArea.direction.x*IslandSpeed*Time.deltaTime; //-player.GetComponent<Rigidbody>().velocity.x/ (2*playerMaxSpeed); 
		Z =mWindArea.direction.z*IslandSpeed*Time.deltaTime; 

		float WhenToDestroy = 60f*1.5f;
		StartCoroutine((Disable(WhenToDestroy)));
		//Destroy(this.gameObject, WhenToDestroy);


		StartCoroutine (Move ());
	}

	IEnumerator Disable(float waitTime){
		yield return new WaitForSeconds (waitTime);
		this.gameObject.SetActive (false);
	}

	IEnumerator Move(){
		while (true) {
			transform.Translate (new Vector3 (-X, 0, -Z));
			yield return new WaitForSeconds (Time.deltaTime);
		}
	}
}


/*
 * 
 * float X = playerTrans.position.x + Random.Range(-300f, 300f);
		//float Y = playerTrans.position.y + Random.Range(-300f, 300f);
		float Z = playerTrans.position.z + Random.Range(-300f, 300f);


		nearPlayerPos = new Vector3(X, 0, Z);

		Vector3 direction = (nearPlayerPos - transform.position).normalized * IslandSpeed;

		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(direction.x,0,direction.z);
*/
