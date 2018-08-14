using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OnBecameInvisible 적이 사라지게 한다.

public class EnemyCtrl : MonoBehaviour {

	public static EnemyCtrl Instance;

	public int HP;
	public bool is_dead;
	private Rigidbody Rb;

	void Awake(){
		Instance = this;
	}

	void Start()
	{
		Rb = this.GetComponent<Rigidbody> ();
	}

	void Update(){
		if (HP<=0) 
		{
			is_dead = true;
			//(Code)중력 적용해서 죽을때 아래로 떨어지도록
			//(오류나네..)this.Rb.useGravity;
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
		this.gameObject.SetActive (false);
		//OBJ Pooling 다시 사용하려면 HP,is_dead,Rb 초기화 해야함
    }
}
