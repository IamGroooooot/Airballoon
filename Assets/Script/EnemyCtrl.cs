using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OnBecameInvisible 적이 사라지게 한다.

public class EnemyCtrl : MonoBehaviour {

	public static EnemyCtrl Instance;

	public int Max_Hp;
	public int HP;
	public bool is_dead;

	void Awake(){
		Instance = this;
	}

	void Start()
	{
		Max_Hp = HP;
	}

	void Update(){
		if (HP<=0) 
		{
			is_dead = true;

			gameObject.transform.parent.GetChild (1).gameObject.SetActive (false); //BallCtlOnDetect비활
			GetComponent<Rigidbody> ().useGravity = true;
			float WhereY = GetComponent<Transform> ().position.y;
			if (WhereY < -2000f) {
				OnBecameInvisible ();

			}
		}
	}

	void OnTriggerEnter(Collider Col)
	{
		if (Col.CompareTag("Bullet")) {
			HP -= 10;
		}

		if (Col.CompareTag("SmallBullet")) {
			HP -= 1;
		}
	}

    private void OnBecameInvisible()
    {
		gameObject.transform.parent.GetChild (1).gameObject.SetActive (true);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		is_dead = false;
		GetComponent<Rigidbody> ().useGravity = false;
		HP = Max_Hp;

		this.gameObject.SetActive (false);//얘가 아니라 얘의 부모를 SetActive(false)해야됨

    }
	
}
