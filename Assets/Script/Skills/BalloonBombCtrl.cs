using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBombCtrl : MonoBehaviour {
    GameObject Enemy;


    // Use this for initialization
    void Start()
    {
        Enemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy != null)
        { 
            gameObject.GetComponent<SphereCollider>().radius = 9.5f;

            FaceTarget();
            Move();
            
        }
    }

    void OnTriggerEnter(Collider CollEnter)
    {
        //Hit Particle생성
        if (this.gameObject.tag == "Bullet")
        {
            if (CollEnter.CompareTag("Enemy") || CollEnter.CompareTag("EnemyR") || CollEnter.CompareTag("EnemyL"))
            {
                GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit();
                if (Hit == null) return;

                Hit.transform.position = CollEnter.transform.position;
                Hit.SetActive(true);
                if (CollEnter.GetComponent<EnemyAirShipCtrl>() != null)
                {
                    CollEnter.GetComponent<EnemyAirShipCtrl>().onHit = true;
                }
                this.gameObject.SetActive(false);
            }
        }
    }
    

    void OnEnable()
    {
        Enemy = null;
        gameObject.GetComponent<SphereCollider>().radius = 200f;
        gameObject.tag = "Untagged";
    }

    void OnDisable()
    {
        Enemy = null;
        gameObject.GetComponent<SphereCollider>().radius = 200f;
        gameObject.tag = "Untagged";
    }

    void OnTriggerStay(Collider CollEnter)
    {
        if (Enemy == null)
        {

            if (CollEnter.CompareTag("Enemy") || CollEnter.CompareTag("EnemyR") || CollEnter.CompareTag("EnemyL"))
            {
                Enemy = CollEnter.gameObject;
                gameObject.GetComponent<SphereCollider>().radius = 9.5f;
                gameObject.tag = "Bullet";
            }
        }
}

    void FaceTarget()
    {

        Vector3 direction = (Enemy.transform.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 100);

    }
    void Move()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 140f;
    }


}
