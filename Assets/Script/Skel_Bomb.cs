using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skel_Bomb : MonoBehaviour {

    public float angle = 45f * Mathf.Deg2Rad; //기본각도를 45도로 설정0.0174532924
    public float bombSpeed = 10f;

    // Use this for initialization
    void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y+33f, player.transform.position.z);
        Vector3 position = playerPos - transform.position;
        Vector3 BombInitVelocity = new Vector3(position.x, Mathf.Pow(Mathf.Sqrt(position.x) + Mathf.Sqrt(position.z), 0.5f) * Mathf.Tan(angle), position.z) ;
        BombInitVelocity = BombInitVelocity.normalized * Mathf.Pow(((Mathf.Sqrt(position.x) + Mathf.Sqrt(position.z)) *Mathf.Abs(Physics.gravity.y))/Mathf.Sin(2*angle), 0.5f);

        Debug.Log(Mathf.Pow(((Mathf.Sqrt(position.x) + Mathf.Sqrt(position.z)) * Mathf.Abs(Physics.gravity.y)) / Mathf.Sin(2 * angle), 0.5f));
        GetComponent<Rigidbody> ().velocity = BombInitVelocity*bombSpeed;
        Destroy(this.gameObject,5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision C){
		if (C.gameObject.tag == "Player") {
			C.gameObject.GetComponent<HP_Bar> ().IsDamaged = true;
			Destroy (this.gameObject);
		}
	}

}
