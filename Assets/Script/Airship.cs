using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Airship 바람영향받고 밀림 

public class Airship : MonoBehaviour {
	public bool inWindArea = false;
	public GameObject windArea; 
    public static bool playerOnHit=false;
    AudioSource playerOnHitSound1, playerOnHitSound2;
    int random=0;
	//Rigidbody Airship_rb; 바람 저항 걍 없앰 2018-8-23

	// Use this for initialization
	void Start ()
    {
		//Airship_rb = gameObject.GetComponent<Rigidbody> ();
        playerOnHitSound1 = transform.GetChild(6).GetChild(7).GetComponent<AudioSource>();
        playerOnHitSound2 = transform.GetChild(6).GetChild(8).GetComponent<AudioSource>();
    }
	
	private void FixedUpdate()
    {
		//바람 방향으로 ADDFORCE
		if (inWindArea)
        {
		    //Airship_rb.AddForce (windArea.GetComponent<WindArea>().direction * windArea.GetComponent<WindArea>().windPower);
			//TempVector = Airship_rb.velocity;
		}
	}
    void Update()
    {
        if (playerOnHit)
        {
            if(random == 0)
            {
                playerOnHitSound1.Play();
                random = Random.Range(0,2);
                playerOnHit = false;
            }
            else
            {
                playerOnHitSound2.Play();
                random = Random.Range(0,2);
                playerOnHit = false;
            }
          
        }



    }
    void OnTriggerEnter(Collider Coll)
    {
		if (Coll.gameObject.tag == "WindArea")
        {
			windArea = Coll.gameObject;
			inWindArea = true;
		}
	}

	void OnTriggerExit(Collider C)
    {
        if (C.gameObject.tag == "WindArea")
        {
            inWindArea = false;
        }
	}


}
