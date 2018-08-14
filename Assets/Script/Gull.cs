using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gull : MonoBehaviour {//(0~300)
    public float gullSpeed=300f;
    Transform playerTrans;
    Vector3 nearPlayerPos;

 	// Use this for initialization
	void Start ()
    {
		playerTrans = PlayerManager.instance.player.transform;
        float X = playerTrans.position.x + Random.Range(-300f, 300f);
      //float Y = playerTrans.position.y + Random.Range(-300f, 300f);
        float Z = playerTrans.position.z + Random.Range(-300f, 300f);
        

        nearPlayerPos = new Vector3(X, 0, Z);

        Vector3 direction = (nearPlayerPos - transform.position).normalized * gullSpeed;

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(direction.x,0,direction.z);
        gameObject.GetComponent<Transform>().rotation = Quaternion.LookRotation(-1f * new Vector3(direction.x, 0, direction.z));

        float WhenToDestroy = 10000f / (new Vector3(direction.x, 0, direction.z).magnitude);
        Destroy(this.gameObject, WhenToDestroy);
    }
}
