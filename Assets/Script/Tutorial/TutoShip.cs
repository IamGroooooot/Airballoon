using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoShip : MonoBehaviour
{
    Transform target;
    Transform targetForRotation;
    float DistanceIS;

    public float HP = 300;
    public bool is_die = false;
    public GameObject explosion;

    public bool onHit;
    int random;

    float lastHp;
    float curHp;

    // Use this for initialization
    void Start()
    {
        lastHp = 300f;
        curHp = 300f;
        onHit = false;
        random = 0;
        target = PlayerManager.instance.player.transform;
    }

    void OnEnable()
    {
        lastHp = 300f;
        curHp = 300f;
        onHit = false;
        random = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceIS = Vector3.Distance(target.position, transform.position);

        //Debug.Log (DistanceIS);
        if (DistanceIS > 600f)
        {
            FaceTarget();
            GetComponent<Rigidbody>().velocity = transform.forward * 100f;
        }
        else
        {
            targetForRotation = FindClosest().transform;

            FaceTargetForRotation();

            GetComponent<Rigidbody>().velocity = transform.forward * 30f;
        }

        if (HP<=0 && is_die==false)
        {
            Die();
        }

        curHp = HP;
        if(curHp < lastHp)
        {
            onHit = true;
            lastHp = curHp;
        }
        
        if (onHit)
        {
            if (random == 0)
            {
                transform.GetChild(2).GetChild(6).GetComponent<AudioSource>().Play();

                random = Random.Range(0, 2);
                onHit = false;
            }
            else
            {
                transform.GetChild(2).GetChild(7).GetComponent<AudioSource>().Play();

                random = Random.Range(0, 2);
                onHit = false;
            }


        }

    }

    void OnTriggerEnter(Collider Col)
    {

        if (Col.CompareTag("Bullet"))
        {
            HP -= PlayerDB.DB.CannonDamage;
        }

        if (Col.CompareTag("SmallBullet"))
        {
            HP -= 1;
        }
    }

    public GameObject FindClosest()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Rotation");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }



    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 70f);
    }

    void FaceTargetForRotation()
    {
        Vector3 direction = (targetForRotation.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 100f);
    }


    void TurnTarget()
    {


        Vector3 direction = (target.position - transform.position).normalized;

        float innerProduct = Mathf.Abs(Vector3.Dot(direction, target.transform.forward.normalized));
        Debug.Log(innerProduct);
        if (innerProduct <= 0.9f)
        {//turn To be SideBySide => 포탄 쏨 가능. 여기에 선회하는거 넣으면 됨.
            RotationToCircle();
            Debug.Log("돌아라");
        }
        else
        { //거의 수평 방향 볼 때
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 35f);
        }



    }

    void RotationToCircle()
    {
        Vector3 Turndirection = target.transform.forward.normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(Turndirection.x, 0, Turndirection.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 200f);
    }

    void Die() {
        explosion.gameObject.SetActive(true);
        this.gameObject.transform.parent.gameObject.SetActive(false);
        Tuto.Tutorial.Skull_dead = true;
        GetComponent<AudioSource>().Play();
        is_die = true;
    }
}

