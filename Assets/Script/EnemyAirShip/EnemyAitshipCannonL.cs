using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAitshipCannonL : MonoBehaviour {


	//포탄 발사 딜레이
	public float delay = 3f;
	public int reload = 30;
	public bool CanShoot, TimerOn,FindPlayerL;
	int time;
	public float bullectLSpeed = 100f;

	//발사위치


	public Vector3 WhereToFireLC1;


	//복제할 총알 오브젝트
	public GameObject BulletLC1;

	private GameObject TempBulletLC1;

	// Use this for initialization
	void Start()
	{
		CanShoot = true;
		time = 0;
		WhereToFireLC1= new Vector3(0,0,0);

		FindPlayerL=false;
	}

	// Update is called once per frame
	void Update()
	{
		if (FindPlayerL)
		{
			Vector3 PlayerPos1;

			PlayerPos1 = FindPlayer ().transform.position;
			WhereToFireLC1 = PlayerPos1 - transform.position;
		}

		if (TimerOn)
		{
			time++;
			if (time == reload)
			{
				//Debug.Log ("대포 발사1");
				GameObject enemyBullet = ObjectPooling.pool.GetPoolObject_EnemyBullet ();
				if (enemyBullet == null) return;

				enemyBullet.transform.position = transform.position;
				enemyBullet.GetComponent <TrailRenderer> ().Clear();

				enemyBullet.SetActive (true);

				enemyBullet.GetComponent<Rigidbody> ().velocity =  WhereToFireLC1.normalized* bullectLSpeed;

			}
			else if (time == reload * 2)
			{
				
			}
			else if (time == reload * 3)
			{
				time = 0;
				TimerOn = false;
			}
		}
		else
		{
			FindPlayerL = false;
		}
	}

	void OnTriggerEnter(Collider CollEnter)
	{
		OnTriggerStay(CollEnter);
	}

	void OnTriggerStay(Collider other)
	{
		//발사 범위 충돌 시 발사여부 체크

		if (other.transform.tag == "Player")
		{
			FindPlayerL = true;
			//Debug.Log("발사범위 접촉");
			playerFire();
		}
	}

	public void playerFire()
	{
		if (CanShoot)
		{
			//Debug.Log("대포 발사");
			TimerOn = true;

			StartCoroutine(Fire());
		}
	}

	IEnumerator Fire()
	{
		//처음에 CanShoot을 false로 만들고(발사불가 시간)
		CanShoot = false;
		//딜레이 시간만큼 기다리게 한다 false = delay 시간동안 지속
		yield return new WaitForSeconds(delay);
		//딜레이 시간이 지나면 발사 가능
		CanShoot = true;
	}

	public GameObject FindPlayer(){
		return GameObject.FindGameObjectWithTag ("Player");
	}


}
