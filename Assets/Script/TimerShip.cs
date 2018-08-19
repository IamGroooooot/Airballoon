using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerShip : MonoBehaviour {
	bool WaveStart, StartTimer;
	public float PerStageTime = 10f;
	float X;
	float Distance;
	float Velocity;
	// Use this for initialization
	void Start () {
		X = GetComponent<RectTransform> ().anchoredPosition.x;
		Distance = X;
		Velocity = Mathf.Abs(Distance / PerStageTime);
		StartTimer = true; WaveStart = true;//TEst용
		//Distance = X , 속력 = Distance/perStageTime
	

	}
	
	// Update is called once per frame
	void Update () {
		if (StartTimer) {
			StartCoroutine (ShipTimerStart());
			StartTimer = false;
		}
	}

	IEnumerator ShipTimerStart(){
		while (WaveStart) {
			if (GetComponent<RectTransform> ().anchoredPosition.x < 0) {
				X += Velocity * Time.deltaTime;
				GetComponent<RectTransform> ().anchoredPosition = new Vector2 (X, 0);
				yield return new WaitForEndOfFrame ();
			} else {
				WaveStart = false;
			}


		}


	}
}
