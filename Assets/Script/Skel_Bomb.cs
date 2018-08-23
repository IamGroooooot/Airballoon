using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skel_Bomb : MonoBehaviour
{

	public string poolItemName = "Skel_bomb";

	void Update(){
		if (this.transform.position.y < 20f) 
		{
			this.gameObject.SetActive (false);
		}
	}

    void OnTriggerEnter(Collider Coll)
    {
		if (Coll.CompareTag ("Player"))
        {
            Airship.playerOnHit = true;
            PlayerDB.DB.cur_Health -= 10;
			GameObject Hit = ObjectPooling.pool.GetPoolObject_Hit ();
			if (Hit == null) return;

			Hit.transform.position = Coll.transform.position;
			Hit.SetActive (true);

            //Instantiate(Hit,Coll.transform.position,Quaternion.identity);

			//Bullet Active False
			this.gameObject.SetActive (false);
        }
        if (Coll.gameObject.CompareTag("Shield"))
        {
            this.gameObject.SetActive(false);

        }
    }
    void OnTriggerStay(Collider CollStay)
    {
        OnTriggerEnter(CollStay);
    }
}


