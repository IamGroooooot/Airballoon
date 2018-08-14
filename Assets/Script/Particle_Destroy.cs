using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Destroy : MonoBehaviour {

    //private ParticleSystem ps;
    // Use this for initialization
    void Start () {
       // ps = GetComponent<ParticleSystem>();       

		StartCoroutine((Disable(1.0f)));
    }
	
	// Update is called once per frame
	/*void Update () {
        if (ps)
        {
            if (!ps.IsAlive())
            {
				
            }
        }
    }*/

	IEnumerator Disable(float waitTime){
		yield return new WaitForSeconds (waitTime);
		this.gameObject.SetActive (false);
	}
}
