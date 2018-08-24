using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDieSound : MonoBehaviour {


    int Once = 0;
	// Use this for initialization
	void Start () {
        Once = 0;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(PlayerDB.DB.cur_Health <=0 && Once==0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            Once++;
        }
	}
}
