using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBulletCtrl : MonoBehaviour {
	public GameObject Hit;
	public Transform CollPos;

	//포탄 공격력
	public int damage = 2;

	public float speed = 800f;

	private Rigidbody Rb;


	// Use this for initialization
	void Start () {
		Rb = GetComponent<Rigidbody> ();
		StartCoroutine (Disable (2.5f));
	}

	void Update(){
		this.Rb.velocity = new Vector3(0,0,1) * speed;
	}

	private void OnBecameInvisible()
	{
		this.gameObject.SetActive (false);
	}

	//Enemy태그 가진애한테 충돌하면 총알 없앰
	void OnTriggerEnter(Collider CollEnter)
	{
		OnTriggerStay(CollEnter);
	}
	void OnTriggerStay(Collider CollStay)
	{
		if (CollStay.CompareTag ("Enemy"))
		{
			//Hit Particle생성

			GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit ();
			if (Hit == null) return;

			Hit.transform.position = CollStay.transform.position;
			Hit.SetActive (true);

			//Instantiate(Hit, CollStay.transform.position, Quaternion.identity);
			this.gameObject.SetActive (false);
		}
	}

	IEnumerator Disable(float waitTime){
		yield return new WaitForSeconds (waitTime);
		this.gameObject.SetActive (false);
	}

}
