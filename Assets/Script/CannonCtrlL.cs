using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 포탄 발사 딜레이, 인스턴트화, 범위에 들어온 적 태그 수정

public class CannonCtrlL : MonoBehaviour
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
	public Vector3 WhereToFireLC1;
	public Vector3 WhereToFireLC2;
	public Vector3 WhereToFireLC3;

    //복제할 총알 오브젝트
	public GameObject BulletLC1;
	public GameObject BulletLC2;
	public GameObject BulletLC3;
	private GameObject TempBulletLC1;
	private GameObject TempBulletLC2;
	private GameObject TempBulletLC3;

	private bool FindEnemyL;

    // Use this for initialization
    void Start()
    {
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
		if (FindEnemyL) {
			WhereToFireLC1 = FindClosestEnemyC1 ().transform.position - Fire_1.position;
			WhereToFireLC2 = FindClosestEnemyC1 ().transform.position - Fire_2.position;
			WhereToFireLC3 = FindClosestEnemyC1 ().transform.position - Fire_3.position;
		}

		if (TimerOn) {
			time++;
			if (time == reload) {
				//Debug.Log ("대포 발사1");
				Vector3 FirePos_1 = Fire_1.position;
				TempBulletLC1 = Instantiate (BulletLC1, FirePos_1, BulletLC1.transform.rotation) as GameObject;
				TempBulletLC1.name = "tempBullectLC1"; 
				GameObject.Find ("tempBullectLC1").GetComponent<Rigidbody> ().velocity =  Vector3.Scale(WhereToFireLC1.normalized,new Vector3 (60,60,60));
            } else if (time == reload * 2) {
				//Debug.Log ("대포 발사2");
				Vector3 FirePos_2 = Fire_2.position;
				TempBulletLC2 = Instantiate (BulletLC2, FirePos_2, BulletLC2.transform.rotation);
				TempBulletLC2.name = "tempBullectLC2";
				GameObject.Find ("tempBullectLC2").GetComponent<Rigidbody> ().velocity =  Vector3.Scale(WhereToFireLC2.normalized,new Vector3 (60, 60, 60));
			} else if (time == reload * 3) {
				//Debug.Log ("대포 발사3");
				Vector3 FirePos_3 = Fire_3.position;
				TempBulletLC3 =Instantiate (BulletLC3, FirePos_3, BulletLC3.transform.rotation);
				TempBulletLC3.name = "tempBullectLC3";
				GameObject.Find ("tempBullectLC3").GetComponent<Rigidbody> ().velocity =  Vector3.Scale(WhereToFireLC3.normalized,new Vector3 (60, 60, 60));
				time = 0;
				TimerOn = false;
			}
		} else {
			FindEnemyL = false;
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
