using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl2 : MonoBehaviour {

	public GameObject Hit;
	public Transform CollPos;

	//포탄 공격력
	public int damage = 10;

	// Use this for initialization
	void OnEnable () {
		StartCoroutine (Disable (3.0f));
	}


	private void OnBecameInvisible()
	{
		this.gameObject.SetActive (false);
	}

	//player태그 가진애한테 충돌하면 총알 없앰
	void OnTriggerEnter(Collider CollEnter)
	{
		//Hit Particle생성

		GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit ();
		if (Hit == null) return;

		Hit.transform.position = CollEnter.transform.position;
		Hit.SetActive (true);

		OnTriggerStay(CollEnter);
	}
	void OnTriggerStay(Collider CollStay)
	{
		if (CollStay.gameObject.tag == "Player")
		{

			PlayerDB.DB.cur_Health -= 10;
			HP_Bar.MyHealthBarSetIsTrue = true;
			this.gameObject.SetActive (false);
		}
	}

	IEnumerator Disable(float waitTime){
		yield return new WaitForSeconds (waitTime);
		this.gameObject.SetActive (false);
	}

}
