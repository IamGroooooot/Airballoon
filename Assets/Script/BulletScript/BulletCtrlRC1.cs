using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrlRC1 : MonoBehaviour {
	private GameObject Airship;
	//포탄 공격력
	public int damage = 20;

	//포탄 속도
	public float speed = 8000f;

	//포탄 발사 딜레이
	public float delay = 3f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3f);
    }

	// Update is called once per frame
	void Update () {

	}

	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

    //Enemy태그 가진애한테 충돌하면 총알 없앰
    void OnTriggerEnter(Collider CollEnter)
    {
        OnTriggerStay(CollEnter);
    }
    void OnTriggerStay(Collider CollStay)
    {
        if (CollStay.gameObject.tag == "EnemyR")
        {
            Destroy(this.gameObject);
        }
    }

}
