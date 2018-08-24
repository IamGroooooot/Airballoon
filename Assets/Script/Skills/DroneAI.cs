using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour {
    GameObject Enemy;
    bool StartFire;
    float distance;
    float Timer;
    public GameObject FirePos1;
    // Use this for initialization
    void Start ()
    {
        Enemy = null;
        StartFire = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Enemy != null)
        {
            distance = Vector3.Distance(Enemy.transform.position,transform.position);

            if (distance > 400f)
            {
                FaceTarget();
                Move();
                StartFire = false;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                FaceTarget();
                StartFire =true;

            }

        }
        if (StartFire)
        {
            Timer += Time.deltaTime;
            if(Timer>2f){
                GameObject enemyBullet1 = ObjectPooling.pool.GetPoolObject_EnemyBullet();
                if (enemyBullet1 == null) return;

                enemyBullet1.transform.position = FirePos1.transform.position;
                enemyBullet1.transform.GetChild(0).GetComponent<TrailRenderer>().Clear();

                enemyBullet1.SetActive(true);
                GetComponent<AudioSource>().Play();
                enemyBullet1.GetComponent<Rigidbody>().velocity = transform.forward * 100f;
                Timer = 0f;
            }
        }


	}
    void OnEnable()
    {
        Enemy = null;

    }

    void OnDisable()
    {
        Enemy = null;

    }
    
    void OnTriggerStay(Collider CollEnter)
    {
        if (Enemy == null)
        {
            if (CollEnter.CompareTag("Enemy") || CollEnter.CompareTag("EnemyR") || CollEnter.CompareTag("EnemyL"))
            {
                Enemy = CollEnter.gameObject;

            }
        }
    }

    void FaceTarget()
    {

        Vector3 direction = (Enemy.transform.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime*100);

    }
    void Move()
    {
        gameObject.GetComponent<Rigidbody>().velocity=transform.forward*50f;


    }
   
}
