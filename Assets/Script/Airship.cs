using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Airship 바람영향받고 밀림 

public class Airship : MonoBehaviour {
	public bool inWindArea = false;
	public GameObject windArea; 

	Rigidbody Airship_rb;

	// Use this for initialization
	void Start ()
    {
		Airship_rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
    {


	}

	private void FixedUpdate()
    {
		//바람 방향으로 ADDFORCE
		if (inWindArea)
        {
		    Airship_rb.AddForce (windArea.GetComponent<WindArea>().direction * windArea.GetComponent<WindArea>().windPower);
			//TempVector = Airship_rb.velocity;
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
