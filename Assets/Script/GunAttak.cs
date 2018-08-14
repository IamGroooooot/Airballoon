using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttak : MonoBehaviour {

	public GameObject Flash;
	private GameObject Target;
	public Transform FirePos;

	public float delay = 3f;
	public int reload = 5;
	public bool CanShoot, TimerOn;
	int time;

	void Start(){
		CanShoot = true;
		time = 0;
	}

	void Update () {

		if (TimerOn) {
			time ++;

			if (Target!=null) {

				if (time == reload)
				{
					Flash.gameObject.SetActive (true);
					GameObject SmallBullet1 = ObjectPooling.pool.GetPoolObject_SmallBullet ();
					if (SmallBullet1 == null) return;
					SmallBullet1.transform.position = FirePos.position;
					SmallBullet1.SetActive (true);
					//Debug.Log ("Fire1");

				}else if (time == reload * 1.5f)
				{
					Flash.gameObject.SetActive (true);
					GameObject SmallBullet2 = ObjectPooling.pool.GetPoolObject_SmallBullet ();
					if (SmallBullet2 == null) return;
					SmallBullet2.transform.position = FirePos.position;
					SmallBullet2.SetActive (true);
					//Debug.Log ("Fire2");
				}else if (time == reload * 2f)
				{
					Flash.gameObject.SetActive (true);
					GameObject SmallBullet3 = ObjectPooling.pool.GetPoolObject_SmallBullet ();
					if (SmallBullet3 == null) return;
					SmallBullet3.transform.position = FirePos.position;
					SmallBullet3.SetActive (true);
					//Debug.Log ("Fire3");

				}else if (time == reload * 2.5f)
				{
					Flash.gameObject.SetActive (true);
					GameObject SmallBullet4 = ObjectPooling.pool.GetPoolObject_SmallBullet ();
					if (SmallBullet4 == null) return;
					SmallBullet4.transform.position = FirePos.position;
					SmallBullet4.SetActive (true);
					//Debug.Log ("Fire4");

				}else if (time == reload * 3f)
				{
					Flash.gameObject.SetActive (true);
					GameObject SmallBullet5 = ObjectPooling.pool.GetPoolObject_SmallBullet ();
					if (SmallBullet5 == null) return;
					SmallBullet5.transform.position = FirePos.position;
					SmallBullet5.SetActive (true);
					//Debug.Log ("Fire5");
				}else if (time == reload * 3.5f)
				{
					Flash.gameObject.SetActive (true);
					GameObject SmallBullet6 = ObjectPooling.pool.GetPoolObject_SmallBullet ();
					if (SmallBullet6 == null) return;
					SmallBullet6.transform.position = FirePos.position;
					SmallBullet6.SetActive (true);
					time = 0;
					TimerOn = false;
					Flash.gameObject.SetActive (false);
					//Debug.Log ("Fire6");
					//Debug.Log ("Reload and Flash is "+ Flash.gameObject.activeSelf);
				} 

			

				//CanShoot = false;
				//StartCoroutine (Fire());
			}
		}			
	}
		
	void OnTriggerEnter(Collider ColEnter)
	{
		OnTriggerStay(ColEnter);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy")) 
		{
			Target = other.gameObject;
			BulletFire ();
		}
	}
		
	public void BulletFire()
	{
		if (CanShoot)
		{
			TimerOn = true;
			StartCoroutine(Fire());
		}
	}

	IEnumerator Fire()
	{
		//처음에 CanShoot을 false로 만들고(발사불가 시간)
		CanShoot = false;
		Flash.gameObject.SetActive (false);
		//딜레이 시간만큼 기다리게 한다 false = delay 시간동안 지속
		yield return new WaitForSeconds(delay);
		//딜레이 시간이 지나면 발사 가능
		CanShoot = true;
	}

	void OnTriggerExit(Collider Col){
	
		//Target = null;
	}
		
}
