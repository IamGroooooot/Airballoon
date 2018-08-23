using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirShipCtrl : MonoBehaviour {
	Transform target;
	Transform targetForRotation;
	float DistanceIS;
    private Transform Tr;
    public float HP = 1000;
    public bool is_dead;
    public GameObject explosion;
    public Animator ani;

    int OnlyOnce, random;
    public float MAX_HP;
    public float damping = 20f; //선회속도
    public float Speed = 100f;

    public bool onHit;
    //Effects
    public GameObject Fire1;

    // Use this for initialization
    void Start () {
        onHit = false;
        OnlyOnce = 0;
        random = 0;
		target = PlayerManager.instance.player.transform;
        Tr = GetComponent<Transform>();
	}

    private void OnEnable()
    {
        onHit = false;
        is_dead = false;
        HP = 1000;
        ani.SetBool("isDie", false);
        explosion.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        if (HP <= 0 && is_dead == false)
        {
            explosion.gameObject.SetActive(true);
            
            explosion.transform.position = Tr.position;
            ani.SetBool("isDie", true);
            StartCoroutine(Die());
        }

        if((HP<=0) && OnlyOnce == 0)
        {

            gameObject.GetComponent<AudioSource>().Play();
            OnlyOnce++;
        }


        if (HP / 1000 <= 0.5)
        {
            Fire1.gameObject.SetActive(true);

        }
        else
        {
            Fire1.gameObject.SetActive(false);
        }

        DistanceIS = Vector3.Distance (target.position,transform.position);

		//Debug.Log (DistanceIS);
		if (DistanceIS > 600f) { 
			FaceTarget ();
			GetComponent<Rigidbody> ().velocity= transform.forward*Speed;
		}
		else 
		{
			targetForRotation = FindClosest ().transform;

			FaceTargetForRotation ();

			GetComponent<Rigidbody> ().velocity= transform.forward*Speed*0.3f;
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


    public GameObject FindClosest(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("Rotation");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
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



	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;

		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x,0,direction.z));
		transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *damping);
	}

	void FaceTargetForRotation()
	{
		Vector3 direction = (targetForRotation.position - transform.position).normalized;

		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x,0,direction.z));
		transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *damping);
	}


	void TurnTarget()
	{

	
		Vector3 direction = (target.position - transform.position).normalized;

		float innerProduct = Mathf.Abs(Vector3.Dot(direction,target.transform.forward.normalized));
		Debug.Log (innerProduct);
		if (innerProduct <= 0.9f) {//turn To be SideBySide => 포탄 쏨 가능. 여기에 선회하는거 넣으면 됨.
			RotationToCircle();
			Debug.Log("돌아라");
		} else { //거의 수평 방향 볼 때
			Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x,0,direction.z));
			transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *damping);
		}



	}

	void RotationToCircle()
	{
		Vector3 Turndirection = target.transform.forward.normalized;

		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(Turndirection.x,0,Turndirection.z));
		transform.rotation = Quaternion.RotateTowards (transform.rotation,lookRotation,Time.deltaTime *damping);
	}

    IEnumerator Die() {
        yield return new WaitForSeconds(1.2f);
        Kills();
        is_dead = true;
        Fire1.gameObject.SetActive(false);

        gameObject.transform.parent.gameObject.SetActive(false); //비활

    }

    private void OnDisable()
    {
        is_dead = false;
        HP = 1000;
        ani.SetBool("isDie", false);
        OnlyOnce = 0;
        onHit = false;
    }
    void Kills()
    {
        TimerShip.Instance.kills++;
    }
}
