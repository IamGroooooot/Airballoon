using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganGunAttack : MonoBehaviour {

    private GameObject Target;
    private Transform FirePos1;
    private Transform FirePos2;
    private Transform FirePos3;

    public float delay = 3f;
    public float bulletSpeed = 400f;
    public int reload = 5;
    public bool CanShoot, TimerOn;
    int time;

    void Start()
    {
        CanShoot = true;
        time = 0;
        FirePos1 = transform.GetChild(1);
        FirePos2 = transform.GetChild(2);
        FirePos3 = transform.GetChild(3);

    }

    void Update()
    {

        if (TimerOn)
        {
            FaceTarget();
            time++;

            if (Target != null)
            {

                if (time == reload)
                {
                    //Flash.gameObject.SetActive(true);
                    GameObject Bullet1 = ObjectPooling.pool.GetPoolObject_Bullet();
                    if (Bullet1 == null) return;
                    Bullet1.transform.position = FirePos1.position;
                    Bullet1.GetComponent<Rigidbody>().velocity = FirePos1.transform.forward*bulletSpeed;
                    Bullet1.SetActive(true);
                    
                    GameObject Bullet2 = ObjectPooling.pool.GetPoolObject_Bullet();
                    if (Bullet2 == null) return;
                    Bullet2.transform.position = FirePos2.position;
                    Bullet2.GetComponent<Rigidbody>().velocity = FirePos2.transform.forward * bulletSpeed;
                    Bullet2.SetActive(true);

                    GameObject Bullet3 = ObjectPooling.pool.GetPoolObject_Bullet();
                    if (Bullet3 == null) return;
                    Bullet3.transform.position = FirePos3.position;
                    Bullet3.GetComponent<Rigidbody>().velocity = FirePos3.transform.forward * bulletSpeed;
                    Bullet3.SetActive(true);


                }
                else if (time == reload * 3.5f)
                {
            
                    time = 0;
                    TimerOn = false;
                    //Flash.gameObject.SetActive(false);
                    
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
            BulletFire();
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
        Debug.Log("Fire!!!");
        //처음에 CanShoot을 false로 만들고(발사불가 시간)
        CanShoot = false;
        //Flash.gameObject.SetActive(false);
        //딜레이 시간만큼 기다리게 한다 false = delay 시간동안 지속
        yield return new WaitForSeconds(delay);
        //딜레이 시간이 지나면 발사 가능
        CanShoot = true;
    }

    void OnTriggerExit(Collider Col)
    {

        //Target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (Target.transform.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 200f);


    }


}
