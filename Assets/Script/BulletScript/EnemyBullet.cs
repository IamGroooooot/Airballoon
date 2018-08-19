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
		
		//Rb.AddForce (transform.forward * speed);
	}

	// Use this for initialization
	void OnEnable () {
		GameObject ImEnemy = FindEnemy ();
		//Debug.Log (ImEnemy.transform.GetChild(0).name);
		Vector3 WhereToShoot = (ImEnemy.transform.GetChild(0).position - transform.position).normalized;

		Rb = this.GetComponent<Rigidbody> ();
		Rb.velocity= WhereToShoot *speed;

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

	public GameObject FindEnemy(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		gos = GameObject.FindGameObjectsWithTag ("EnemyR");
		GameObject closest1 = null;
		float distance1 = Mathf.Infinity;
		position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance1) {
				closest1 = go;
				distance1 = curDistance;
			}
		}
		gos = GameObject.FindGameObjectsWithTag ("EnemyL");
		GameObject closest2 = null;
		float distance2= Mathf.Infinity;
		position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance2) {
				closest2 = go;
				distance2 = curDistance;
			}
		}

		position = transform.position;
		Vector3 Dis1 = Vector3.positiveInfinity;
		Vector3 Dis2 = Vector3.positiveInfinity;
		Vector3 Dis3 = Vector3.positiveInfinity;
		if (closest !=null)	{
			Dis1 = closest.transform.position - position;
		}
		if (closest1 !=null)	{
			Dis2 = closest1.transform.position - position;
		}
		if (closest2 !=null)	{
			Dis3 = closest2.transform.position - position;
		}

		if (Dis1.sqrMagnitude < Dis2.sqrMagnitude && Dis1.sqrMagnitude < Dis3.sqrMagnitude) {
			return closest;
		} else if (Dis2.sqrMagnitude < Dis1.sqrMagnitude && Dis2.sqrMagnitude < Dis1.sqrMagnitude) {
			return closest1;
		} else if (Dis3.sqrMagnitude < Dis1.sqrMagnitude && Dis3.sqrMagnitude < Dis2.sqrMagnitude) {
			return closest2;
		}

		return closest;
	}

}
