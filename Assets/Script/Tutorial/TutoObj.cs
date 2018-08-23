using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoObj : MonoBehaviour {

    public GameObject Explosion;
    public float HP;
    public bool is_dead;

    private Transform Tr;
    int once;
	// Use this for initialization
	void Start () {
        once = 0;
        Tr = this.GetComponent<Transform>();
        HP = 50;
	}


    void Update()
    {
        if (HP <= 0)
        {
            is_dead = true;
        }

        if(HP<=0 && once == 0)
        {
            transform.parent.parent.parent.GetComponent<AudioSource>().Play();
            once++;
        }

        if (is_dead)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Bullet"))
        {
             HP -= PlayerDB.DB.CannonDamage;
        }
    }
    void Die() {

        Explosion.gameObject.SetActive(true);
        Explosion.transform.position = this.Tr.position;
        Tuto.Tutorial.Obj_dead = true;
        this.gameObject.SetActive(false);


        is_dead = false;
    }
}
