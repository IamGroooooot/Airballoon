using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OnBecameInvisible 적이 사라지게 한다.

public class EnemyCtrl : MonoBehaviour {

	public static EnemyCtrl Instance;
	float WhereY;
    public float Max_Hp;
    public float HP;
	public bool is_dead;
	int count;
	public GameObject explosion;

	private Transform Tr;
	private Rigidbody Rb;

    bool YPositionSet;

	void Awake(){
		Instance = this;
        YPositionSet = true;
    }

	void Start()
	{
		count = 0;
		Tr = this.GetComponent<Transform> ();
		Max_Hp = HP;
		Rb = this.GetComponent<Rigidbody> ();
		is_dead = false;
        YPositionSet = true;

    }

	void OnTriggerEnter(Collider Col)
	{

		if (Col.CompareTag("Bullet")) {
            HP -= PlayerDB.DB.CannonDamage;
        }

		if (Col.CompareTag("SmallBullet")) {
			HP -= 1;
		}
	}
	void FixedUpdate()
	{
        if (YPositionSet)
        {
            Tr.position = new Vector3(transform.position.x, PlayerManager.instance.player.transform.position.y, transform.position.z);
            YPositionSet = false;
        }


        if (WhereY < -2000f) {
			OnBecameInvisible ();
		}
	}

	void Update(){
		if (HP<=0)
		{
			is_dead = true;
			WhereY = GetComponent<Transform> ().position.y;
			this.Rb.AddForce (0,-1000,0);
			gameObject.transform.GetChild (1).gameObject.SetActive (false); //BallCtlOnDetect비활
			this.Rb.useGravity = true;
		}

		if (is_dead == true && count ==0) {
			//Explosion Effect 왜 실행이 안되는거지 ㅠㅠ
			explosion.gameObject.SetActive (true);
			explosion.transform.position = Tr.position;
			count = 1;
		}
	}
		
    private void OnBecameInvisible()
    {
		gameObject.transform.GetChild (1).gameObject.SetActive (true);

		this.Rb.velocity = Vector3.zero;
		is_dead = false;
		this.Rb.useGravity = false;
		HP = Max_Hp;
		WhereY = 100;
		count = 0;
		gameObject.transform.parent.gameObject.SetActive (false);//얘가 아니라 얘의 부모를 SetActive(false)해야됨

    }
	
}
