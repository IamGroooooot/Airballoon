using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAitshipCannonL : MonoBehaviour {
    AudioSource L1, L2, L3;

    //포탄 발사 딜레이
    public float delay = 3f;
	public int reload = 30;
	public bool CanShoot, TimerOn,FindPlayerL;
	int time;
	public float bullectLSpeed = 100f;

    //발사위치
    public Transform FirePos1;
    public Transform FirePos2;
    public Transform FirePos3;


    public Vector3 WhereToFireLC1;
    public Vector3 WhereToFireLC2;
    public Vector3 WhereToFireLC3;
    //복제할 총알 오브젝트
    //public GameObject BulletLC1;



	// Use this for initialization
	void Start()
	{
        L1 = transform.parent.parent.GetChild(2).GetChild(3).GetComponent<AudioSource>();
        L2 = transform.parent.parent.GetChild(2).GetChild(4).GetComponent<AudioSource>();
        L3 = transform.parent.parent.GetChild(2).GetChild(5).GetComponent<AudioSource>();
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
			WhereToFireLC1 = PlayerPos1 - FirePos1.transform.position;
            WhereToFireLC2 = PlayerPos1 - FirePos2.transform.position;
            WhereToFireLC3 = PlayerPos1 - FirePos3.transform.position;
        }

		if (TimerOn)
		{
			time++;
			if (time == reload)
			{
				//Debug.Log ("대포 발사1");
				GameObject enemyBullet1 = ObjectPooling.pool.GetPoolObject_EnemyBullet ();
				if (enemyBullet1 == null) return;

				enemyBullet1.transform.position = FirePos1.transform.position;
                enemyBullet1.transform.GetChild(0).GetComponent<TrailRenderer>().Clear();

                enemyBullet1.SetActive (true);
                L1.Play();
                enemyBullet1.GetComponent<Rigidbody> ().velocity =  WhereToFireLC1.normalized* bullectLSpeed;

			}
			else if (time == reload * 2)
			{
                GameObject enemyBullet2 = ObjectPooling.pool.GetPoolObject_EnemyBullet();
                if (enemyBullet2 == null) return;

                enemyBullet2.transform.position = FirePos2.transform.position;
                enemyBullet2.transform.GetChild(0).GetComponent<TrailRenderer>().Clear();

                enemyBullet2.SetActive(true);
                L2.Play();
                enemyBullet2.GetComponent<Rigidbody>().velocity = WhereToFireLC2.normalized * bullectLSpeed;
                

            }
			else if (time == reload * 3)
			{
                GameObject enemyBullet3 = ObjectPooling.pool.GetPoolObject_EnemyBullet();
                if (enemyBullet3 == null) return;

                enemyBullet3.transform.position = FirePos3.transform.position;
                enemyBullet3.transform.GetChild(0).GetComponent<TrailRenderer>().Clear();

                enemyBullet3.SetActive(true);
                L3.Play();
                enemyBullet3.GetComponent<Rigidbody>().velocity = WhereToFireLC3.normalized * bullectLSpeed;
                

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
