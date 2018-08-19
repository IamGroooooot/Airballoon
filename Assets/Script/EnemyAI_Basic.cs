using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Basic : MonoBehaviour {

	public enum State{idle, trace, attak, die};
	public State state = State.idle;

	public GameObject explosion;

	public Transform FirePos;
	private Transform Tr;
	private Transform PlayerTr;
	private Vector3 direction;


	private Vector3 WhereToFire;
	//public float acceleration;
	public float HP = 50;
	public float velocity = 2.0f;

	public float BulletSpeed = 800f;
	public float attackDist = 100.0f;
	public float traceDist = 1000.0f;
	public bool isDie = false;


	bool onFire;
	float timer;
	public float fireDelay =3f;


	// Use this for initialization
	void Start () {

		Tr = this.gameObject.GetComponent<Transform> ();
		PlayerTr = PlayerManager.instance.player.transform;

		StartCoroutine(this.CheckState());
		StartCoroutine(this.Action());


		onFire = false;
		timer = 0f;
	}
		
	void Update(){
		
		if (onFire) 
		{
			timer += Time.deltaTime;
			if (timer >= fireDelay) 
			{
				Fire ();
				timer = 0f;
				onFire = false;
			}

		}


	}



	IEnumerator CheckState()
	{
		while (!isDie) 
		{
			yield return new WaitForSeconds (0.2f);

			float dist = Vector3.Distance(PlayerTr.position,Tr.position);

			if (HP <= 0) {
				state = State.die;
			}

			else if (dist <= attackDist) {
				state = State.attak;
			}

			else if (dist <= traceDist) {
				state = State.trace;
			} 
			else 
			{
				state = State.idle;
			}
		}

	}

	IEnumerator Action()
	{
		while (!isDie) 
		{
			switch (state) {
			case State.idle:
				break;

			case State.trace:
				
				Quaternion rot = Quaternion.LookRotation(PlayerTr.position - Tr.position);

				Tr.rotation = Quaternion.Slerp(this.Tr.rotation, rot, Time.deltaTime*2f);
				Tr.Translate (new Vector3(0, 0,1)* velocity);

				break;

			case State.attak:
				Quaternion rot1 = Quaternion.LookRotation(PlayerTr.position - Tr.position);

				Tr.rotation = Quaternion.Slerp(this.Tr.rotation, rot1, Time.deltaTime*2f);
				//Logic: attak-idle-(delay)-attak-idle..순서로
				//총알 발사 딜레이 시간 넣어줘 (스크립트 재사용 해야하니 미지수로) 
				onFire = true;
				
				break;

			case State.die: 
				//사망루틴(SetActive(false)-변수 초기화-폭발이펙트)		

				gameObject.SetActive (false);
				HP = 50f;
				state = State.idle;
				break;
			}
			yield return null;
		}	
	}

	void Fire()
	{
		/*GameObject enemyBullet = ObjectPooling.pool.GetPoolObject_EnemyBullet ();
		//if (enemyBullet == null) return;

		enemyBullet.transform.position = FirePos.position;
		enemyBullet.transform.rotation = this.Tr.rotation;
		enemyBullet.GetComponent <TrailRenderer> ().Clear();

		enemyBullet.SetActive (true);
		//yield return null;*/
	}
}
