using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrlRC1 : MonoBehaviour {
	private GameObject Airship;
	//포탄 공격력
	public int damage = 20;

	//포탄 속도
	public float speed = 8000f;

	//포탄 발사 딜레이
	public float delay = 3f;

	// Use this for initialization
	void Start () {
		////Airship = GameObject.Find ("Player");
		//이 부분에서 가장 가까운 적(태그:Enemy)찾고 최단거리 적 방향으로 발사하도록
		////GetComponent<Rigidbody>().AddForce(Airship.transform.right * speed);
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

	//Enemy태그 가진애한테 충돌하면 총알 없앰
	void OnCollisionEnter (Collision C){
		//if (C.gameObject.tag == "Enemy") {
		Destroy (this.gameObject);
		//}

	}

}
