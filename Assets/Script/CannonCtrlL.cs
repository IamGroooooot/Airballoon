﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 포탄 발사 딜레이, 인스턴트화, 범위에 들어온 적 태그 수정

public class CannonCtrlL : MonoBehaviour
{
    GameObject playerSound;
    AudioSource L1, L2, L3;

    //포탄 발사 딜레이
    public float delay = 3f;
    public int reload = 30;
    public bool CanShoot, TimerOn;
    int time;
    public float bullectLSpeed = 400f;
	public Material TrailMat;

    //발사위치
    public Transform Fire_1;
    public Transform Fire_2;
    public Transform Fire_3;
	public Vector3 WhereToFireLC1;
	public Vector3 WhereToFireLC2;
	public Vector3 WhereToFireLC3;

	GameObject CloseEn1;
	GameObject CloseEn2;
	GameObject CloseEn3;

	private bool FindEnemyL;

    // Use this for initialization
    void Start()
    {
        playerSound = PlayerManager.instance.player.transform.GetChild(6).gameObject;
        L1 = playerSound.transform.GetChild(3).GetComponent<AudioSource>();
        L2 = playerSound.transform.GetChild(4).GetComponent<AudioSource>();
        L3 = playerSound.transform.GetChild(5).GetComponent<AudioSource>();
        CanShoot = true;
        time = 0;
		WhereToFireLC1= new Vector3(0,0,0);
		WhereToFireLC2= new Vector3(0,0,0);
		WhereToFireLC3= new Vector3(0,0,0);
		FindEnemyL=false;



    }

    // Update is called once per frame
    void Update()
    {
		if (FindEnemyL)
        {
            Vector3 closeEnemyPos1;
            Vector3 closeEnemyPos2;
            Vector3 closeEnemyPos3;
            if (GameObject.FindGameObjectWithTag("EnemyL") != null)
            {
				CloseEn1 = FindClosestEnemyC1 ();
				CloseEn2 = FindClosestEnemyC2 ();
				CloseEn3 = FindClosestEnemyC3 ();
				closeEnemyPos1 = new Vector3(CloseEn1.transform.position.x, CloseEn1.transform.position.y, CloseEn1.transform.position.z);
				closeEnemyPos2 = new Vector3(CloseEn2.transform.position.x, CloseEn2.transform.position.y, CloseEn2.transform.position.z);
				closeEnemyPos3 = new Vector3(CloseEn3.transform.position.x, CloseEn3.transform.position.y, CloseEn3.transform.position.z);

                WhereToFireLC1 = closeEnemyPos1 - Fire_1.position;
                WhereToFireLC2 = closeEnemyPos2 - Fire_2.position;
                WhereToFireLC3 = closeEnemyPos3 - Fire_3.position;
            }
            else
            {
                time = 0;
            }
        }

		if (TimerOn)
        {
			time++;
			if (time == reload)
            {
				//Debug.Log ("대포 발사1");
				Vector3 FirePos_1 = Fire_1.position;

				GameObject Bullet = ObjectPooling.pool.GetPoolObject_Bullet ();
				if (Bullet == null) return;

				Bullet.GetComponent<BulletCtrl> ().Enemy = CloseEn1;

				Bullet.transform.position = FirePos_1;


				Bullet.SetActive (true);
                L1.Play();
                Bullet.GetComponent<Rigidbody> ().velocity = WhereToFireLC1.normalized* bullectLSpeed;

				Bullet.GetComponent<TrailRenderer> ().Clear();

            }
            else if (time == reload * 2)
            {
				//Debug.Log ("대포 발사2");
				Vector3 FirePos_2 = Fire_2.position;

				GameObject Bullet = ObjectPooling.pool.GetPoolObject_Bullet ();
				if (Bullet == null) return;

				Bullet.GetComponent<BulletCtrl> ().Enemy = CloseEn2;

				Bullet.transform.position = FirePos_2;

				Bullet.SetActive (true);
                L2.Play();
                Bullet.GetComponent<Rigidbody> ().velocity = WhereToFireLC2.normalized*bullectLSpeed;

				Bullet.GetComponent<TrailRenderer> ().Clear();

			}
            else if (time == reload * 3)
            {
				//Debug.Log ("대포 발사3");
				Vector3 FirePos_3 = Fire_3.position;

				GameObject Bullet = ObjectPooling.pool.GetPoolObject_Bullet ();
				if (Bullet == null) return;

				Bullet.GetComponent<BulletCtrl> ().Enemy = CloseEn3;

				Bullet.transform.position = FirePos_3;

				Bullet.SetActive (true);
                L3.Play();
                Bullet.GetComponent<Rigidbody> ().velocity = WhereToFireLC3.normalized*bullectLSpeed;

				Bullet.GetComponent<TrailRenderer> ().Clear();
				time = 0;

				TimerOn = false;
			}
		}
        else
        {
			FindEnemyL = false;
		}
    }

    void OnTriggerEnter(Collider CollEnter)
    {
        OnTriggerStay(CollEnter);
    }

    void OnTriggerExit(Collider CollExit)
    {
        if (CollExit.transform.tag == "EnemyL")
        {
            CollExit.gameObject.tag = "Enemy";
        }
    }

    void OnTriggerStay(Collider other)
    {
        //발사 범위 충돌 시 발사여부 체크
		if (other.transform.tag == "Enemy"||other.transform.tag == "EnemyR")
        {
            //Debug.Log("EnemyL로 태그 바꿈");
			other.gameObject.tag = "EnemyL";
        }
		if (other.transform.tag == "EnemyL")
		{
            FindEnemyL = true;
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

	public GameObject FindClosestEnemyC1(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("EnemyL");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = Fire_1.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	public GameObject FindClosestEnemyC2(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("EnemyL");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = Fire_2.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
	public GameObject FindClosestEnemyC3(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("EnemyL");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = Fire_3.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
		
}
