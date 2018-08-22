using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBulletCtrl : MonoBehaviour {
	public GameObject Hit;
	public Transform CollPos;
    private GameObject myMachineGun;
	//포탄 공격력
	public int damage = 2;

	public float speed = 400f;

	private Rigidbody Rb;


	// Use this for initialization
	void Start () {
		Rb = GetComponent<Rigidbody> ();
        myMachineGun = GameObject.Find("Machine Gun");

    }

	void OnEnable(){
		Rb = GetComponent<Rigidbody> ();
		StartCoroutine (Disable (2.5f));
	}

	void Update(){
		this.Rb.velocity = myMachineGun.transform.forward.normalized * speed;
	}

	private void OnBecameInvisible()
	{
		this.gameObject.SetActive (false);
	}

	//Enemy태그 가진애한테 충돌하면 총알 없앰
	void OnTriggerEnter(Collider CollEnter)
	{
		//Hit Particle생성

		GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit ();
		if (Hit == null) return;

		Hit.transform.position = CollEnter.transform.position;
		//Hit.transform.localScale = Vector3 (1, 1, 1);
		Hit.SetActive (true);

		OnTriggerStay(CollEnter);
	}
	void OnTriggerStay(Collider CollStay)
	{
		if (CollStay.CompareTag ("Enemy"))
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
