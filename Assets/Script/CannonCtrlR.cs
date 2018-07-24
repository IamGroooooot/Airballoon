using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 포탄 발사 딜레이, 인스턴트화, 범위에 들어온 적 태그 수정

public class CannonCtrlR : MonoBehaviour
{

	//포탄 발사 딜레이
	public float delay = 3f;
	public int reload = 30;
	public bool CanShoot, TimerOn;
	int time;

	//발사위치
	public Transform Fire_1;
	public Transform Fire_2;
	public Transform Fire_3;
	public Vector3 WhereToFireRC1;
	public Vector3 WhereToFireRC2;
	public Vector3 WhereToFireRC3;

	//복제할 총알 오브젝트
	public GameObject BulletRC1;
	public GameObject BulletRC2;
	public GameObject BulletRC3;
	private GameObject TempBulletRC1;
	private GameObject TempBulletRC2;
	private GameObject TempBulletRC3;

	private bool FindEnemyR;

	// Use this for initialization
	void Start()
	{
		CanShoot = true;
		time = 0;
		WhereToFireRC1= new Vector3(0,0,0);
		WhereToFireRC2= new Vector3(0,0,0);
		WhereToFireRC3= new Vector3(0,0,0);
		FindEnemyR=false;
	}

	// Update is called once per frame
	void Update()
	{
		if (FindEnemyR) {
			WhereToFireRC1 = FindClosestEnemyC1 ().transform.position - Fire_1.position;
			WhereToFireRC2 = FindClosestEnemyC1 ().transform.position - Fire_2.position;
			WhereToFireRC3 = FindClosestEnemyC1 ().transform.position - Fire_3.position;
		}
		if (TimerOn) {
			time++;
			if (time == reload) {
				//Debug.Log ("대포 발사1");
				Vector3 FirePos_1 = Fire_1.position;
				TempBulletRC1 = Instantiate (BulletRC1, FirePos_1, BulletRC1.transform.rotation) as GameObject;
				TempBulletRC1.name = "tempBullectRC1"; 
				GameObject.Find ("tempBullectRC1").GetComponent<Rigidbody> ().velocity = Vector3.Scale (WhereToFireRC1.normalized, new Vector3 (60, 60, 60));
			} else if (time == reload * 2) {
				//Debug.Log ("대포 발사2");
				Vector3 FirePos_2 = Fire_2.position;
				TempBulletRC2 = Instantiate (BulletRC2, FirePos_2, BulletRC2.transform.rotation);
				TempBulletRC2.name = "tempBullectRC2";
				GameObject.Find ("tempBullectRC2").GetComponent<Rigidbody> ().velocity = Vector3.Scale (WhereToFireRC2.normalized, new Vector3 (60, 60, 60));
			} else if (time == reload * 3) {
				//Debug.Log ("대포 발사3");
				Vector3 FirePos_3 = Fire_3.position;
				TempBulletRC3 = Instantiate (BulletRC3, FirePos_3, BulletRC3.transform.rotation);
				TempBulletRC3.name = "tempBullectRC3";
				GameObject.Find ("tempBullectRC3").GetComponent<Rigidbody> ().velocity = Vector3.Scale (WhereToFireRC3.normalized, new Vector3 (60, 60, 60));
				time = 0;
				TimerOn = false;
			}
		} else {
			FindEnemyR = false;
		}
	}

	void OnTriggerStay(Collider other)
	{
		//발사 범위 충돌 시 발사여부 체크
		if (other.transform.tag == "Enemy"||other.transform.tag == "EnemyL")
		{
			//Debug.Log("EnemyL로 태그 바꿈");
			other.gameObject.tag = "EnemyR";
		}
		if (other.transform.tag == "EnemyR")
		{
			//Debug.Log("발사범위 접촉");
			playerFire();
		}

		FindEnemyR = true;
		//Debug.Log(FindClosestEnemy().name);
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
		gos = GameObject.FindGameObjectsWithTag ("EnemyR");
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
		gos = GameObject.FindGameObjectsWithTag ("EnemyR");
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
		gos = GameObject.FindGameObjectsWithTag ("EnemyR");
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
