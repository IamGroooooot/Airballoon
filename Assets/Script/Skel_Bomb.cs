using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skel_Bomb : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.tag == "Player")
        {
            HP_Bar.IsDamaged = true;
            
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay(Collider CollStay)
    {
        OnTriggerEnter(CollStay);
    }
}


