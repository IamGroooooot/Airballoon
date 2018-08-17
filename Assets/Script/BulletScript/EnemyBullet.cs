using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public GameObject Hit;
	//public Transform CollPos;

	//포탄 공격력
	public int damage = 10;

	public float speed = 400f;

	private Rigidbody Rb;

	void Start(){
		Rb = this.GetComponent<Rigidbody> ();
		//Rb.AddForce (transform.forward * speed);
	}

	// Use this for initialization
	void OnEnable () {

		Rb = this.GetComponent<Rigidbody> ();
		Rb.AddForce (transform.forward * speed);
		StartCoroutine (Disable (2.0f));
	}


	private void OnBecameInvisible()
	{
		this.gameObject.SetActive (false);
	}

	//Enemy태그 가진애한테 충돌하면 총알 없앰
	void OnTriggerEnter(Collider CollEnter)
	{
		if (CollEnter.CompareTag("Player")) {
			PlayerDB.DB.cur_Health -= damage;
		}
		//Hit Particle생성

		GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit ();
		if (Hit == null) return;

		Hit.transform.position = CollEnter.transform.position;
		Hit.SetActive (true);

		OnTriggerStay(CollEnter);
	}
	void OnTriggerStay(Collider CollStay)
	{
		if (CollStay.CompareTag ("Player"))
		{
			
			//Instantiate(Hit, CollStay.transform.position, Quaternion.identity);
			this.gameObject.SetActive (false);
		}
	}

	IEnumerator Disable(float waitTime){
		yield return new WaitForSeconds (waitTime);
		this.gameObject.SetActive (false);
	}

}
