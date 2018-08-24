using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

	public GameObject Hit;
	public Transform CollPos;
	public GameObject Enemy = null;
	//포탄 공격력
	public int damage = 10;
	float speed = 200f; 
	//public float speed = 10f;

	private Rigidbody Rb;


	// Use this for initialization
	void OnEnable () {
		StartCoroutine (Disable (4.0f));
		if (Enemy != null) {
			StartCoroutine (Bullet ());
		}
	}
		

	IEnumerator Bullet(){
		while (true) {

			Vector3 myNewVelocity = (Enemy.transform.position - transform.position).normalized;
			GetComponent<Rigidbody> ().velocity = myNewVelocity * speed;
			yield return new WaitForSeconds (0.04f);

		}
	}

	private void OnBecameInvisible()
	{
		this.gameObject.SetActive (false);
	}

	//Enemy태그 가진애한테 충돌하면 총알 없앰
	void OnTriggerEnter(Collider CollEnter)
	{
        //Hit Particle생성
        if (CollEnter.CompareTag("Enemy") || CollEnter.CompareTag("EnemyR") || CollEnter.CompareTag("EnemyL"))
        {
            GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit();
            if (Hit == null) return;

            Hit.transform.position = CollEnter.transform.position;
            Hit.SetActive(true);
            if (CollEnter.GetComponent<EnemyAirShipCtrl>() != null)
            {
                CollEnter.GetComponent<EnemyAirShipCtrl>().onHit = true;
            }
            OnTriggerStay(CollEnter);
        }

	}
	void OnTriggerStay(Collider CollStay)
	{
		if (CollStay.CompareTag ("EnemyL")|| CollStay.CompareTag ("EnemyR"))
		{
			
			this.gameObject.SetActive (false);

		}
	}

	IEnumerator Disable(float waitTime){
		yield return new WaitForSeconds (waitTime);
		this.gameObject.SetActive (false);
	}

}
