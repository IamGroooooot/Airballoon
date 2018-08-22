using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour {

	public Transform[] points;

	//GameObject Island;
	int RadomNum=0;
	public float createTime = 7f;
	public static IslandSpawner instance = null;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		points = GameObject.Find ("Island_SpawnPoint").GetComponentsInChildren<Transform> ();

		if (points.Length >0) {
			StartCoroutine (CreateGull ());
		}
	}

	IEnumerator CreateGull()
	{
		while (true) 
		{
			yield return new WaitForSeconds (createTime);

			RadomNum = Random.Range (1, 9);
			GameObject Island = null;
			if (RadomNum == 1) {
				Island = ObjectPooling.pool.GetPoolObject_Island1 ();
			
			} else if (RadomNum == 2) {
				Island = ObjectPooling.pool.GetPoolObject_Island2 ();

			} else if (RadomNum == 3) {
				Island = ObjectPooling.pool.GetPoolObject_Island3 ();

			} else if (RadomNum == 4) {
				Island = ObjectPooling.pool.GetPoolObject_Island4 ();
			
			} else if (RadomNum == 5) {
				Island = ObjectPooling.pool.GetPoolObject_Island5 ();
		
			} else if (RadomNum == 6) {
				Island = ObjectPooling.pool.GetPoolObject_Island6 ();

			} else if (RadomNum == 7) {
				Island = ObjectPooling.pool.GetPoolObject_Island7 ();
		
			} else {
				Island = ObjectPooling.pool.GetPoolObject_Island8 ();
			
			}

			if (Island != null && !Island.activeSelf) {
				int Place_idx = Random.Range (1, points.Length);
				Island.transform.position = points [Place_idx].position;
		

				Island.SetActive (true);
			} else {
				
			}

		}


	}



}