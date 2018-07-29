using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skel_Bomb : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //angle_degr = angle_degr *Mathf.Deg2Rad; // Deg2Rad
        //GameObject player = GameObject.FindGameObjectWithTag ("Player");
        //Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y+33f, player.transform.position.z);
        //Vector3 position = playerPos - transform.position;
        //Vector3 BombInitVelocity = new Vector3(position.x, Mathf.Pow(Mathf.Sqrt(position.x) + Mathf.Sqrt(position.z), 0.5f) * Mathf.Tan(angle_degr), position.z) ;
        //BombInitVelocity = BombInitVelocity.normalized * Mathf.Pow(((Mathf.Sqrt(position.x) + Mathf.Sqrt(position.z)) *Mathf.Abs(Physics.gravity.y))/Mathf.Sin(2*angle_degr), 0.5f);

        //Debug.Log(Mathf.Pow(((Mathf.Sqrt(position.x) + Mathf.Sqrt(position.z)) * Mathf.Abs(Physics.gravity.y)) / Mathf.Sin(2 * angle_degr), 0.5f));
        //GetComponent<Rigidbody> ().velocity = BombInitVelocity*bombSpeed;//강체를 찾을 수 없음?????
        //Destroy(this.gameObject,5f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnCollisionEnter(Collision C)
    //{
    //    if (C.gameObject.tag == "Player")
    //    {
    //        C.gameObject.GetComponent<HP_Bar>().IsDamaged = true;
    //        Destroy(this.gameObject);
    //    }
    //}


    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.tag == "Player")
        {
            Coll.gameObject.GetComponent<HP_Bar>().IsDamaged = true;
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay(Collider CollStay)
    {
        OnTriggerEnter(CollStay);
    }
}


