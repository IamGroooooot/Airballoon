using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public GameObject Hit;
    //public Transform CollPos;

    public bool isDie = false;

	//포탄 공격력 (기본공격력 3)
	public float damage = 3.0f;

    void OnEnable () {
        //Rb.AddForce(transform.forward * speed);
        isDie = false;
		//GameObject ImEnemy = FindEnemy ();
		//Debug.Log (ImEnemy.transform.GetChild(0).name);
		
		
		StartCoroutine (Disable (5.0f));
	}

    private void OnBecameInvisible()
	{
		this.gameObject.SetActive (false);
	}

    //Enemy태그 가진애한테 충돌하면 총알 없앰
    void OnTriggerEnter(Collider CollEnter)
    {
        if (CollEnter.CompareTag("Player"))
        {
            Airship.playerOnHit = true;
            PlayerDB.DB.cur_Health -= damage;
            HP_Bar.IsDamaged = true;
            GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit();
            if (Hit == null) return;

            Hit.transform.position = CollEnter.transform.position;
            Hit.SetActive(true);

            this.gameObject.SetActive(false);
        }
		if (CollEnter.gameObject.CompareTag ("Shield")) {
			this.gameObject.SetActive (false);

		}
        //Hit Particle생성
    }

	IEnumerator Disable(float waitTime){
		yield return new WaitForSeconds (waitTime);
        isDie = true;
		this.gameObject.SetActive (false);
	}


}
