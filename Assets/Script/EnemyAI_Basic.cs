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
	public float velocity = 3.0f;

	public float BulletSpeed = 500f;
	public float attackDist = 100.0f;
	public float traceDist = 1000.0f;
	public bool isDie = false;



	// Use this for initialization
	void Start () {

		Tr = this.gameObject.GetComponent<Transform> ();
		PlayerTr = PlayerManager.instance.player.transform;

		StartCoroutine(this.CheckState());
		StartCoroutine(this.Action());

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
				//Logic: attak-idle-(delay)-attak-idle..순서로
				//총알 발사 딜레이 시간 넣어줘 (스크립트 재사용 해야하니 미지수로) 
				StartCoroutine (Fire());
				
				break;

			case State.die: 
				//사망루틴(SetActive(false)-변수 초기화-폭발이펙트)			
				break;
			}	
			yield return null;
		}	
	}

	IEnumerator Fire()
	{
		GameObject enemyBullet = ObjectPooling.pool.GetPoolObject_EnemyBullet ();
		//if (enemyBullet == null) return;

		enemyBullet.transform.position = FirePos.position;


		enemyBullet.SetActive (true);
		yield return null;
	}
}
