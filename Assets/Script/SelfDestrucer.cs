using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestrucer : MonoBehaviour {

	public enum State{idle, trace, attak, die};
	public State state = State.idle;

	public GameObject explosion;

	private Transform Tr;
	private Transform PlayerTr;
	private Vector3 direction;
	public float velocity = 4.0f;
    //public float acceleration;

    public int HP = 25; //대포업그레이드 추가하면 HP높아짐 (박쥐<유령<오징어)
	public float attackDist = 30.0f;
	public float traceDist = 1000.0f;
	public bool isDie = false;

	public float damage;

	//private Rigidbody Rb;

	// Use this for initialization
	void Start () {
		//Rb = this.GetComponent<Rigidbody> ();
		Tr = this.gameObject.GetComponent<Transform> ();
		PlayerTr = PlayerManager.instance.player.transform;

		StartCoroutine(this.CheckState());
		StartCoroutine(this.Action());

	}

    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Bullet"))
        {
            HP -= 10;
        }

        if (Col.CompareTag("SmallBullet"))
        {
            HP -= 1;
        }
    }

    void Update()
    {
        if (HP <= 0)
        {
            isDie = true;
            gameObject.transform.parent.gameObject.SetActive(false); //비활
        }

        if (isDie == true)
        {
            explosion.gameObject.SetActive(true);
            explosion.transform.position = Tr.position;
        }
    }

    IEnumerator CheckState()
	{
		while (!isDie) 
		{
			yield return new WaitForSeconds (0.2f);

			float dist = Vector3.Distance(PlayerTr.position,Tr.position);

			if (dist <= attackDist) {
				state = State.attak;
			}

			else if (dist <= traceDist) {
				state = State.trace;
			} 
			else 
			{
				state = State.idle;
			}
		}

	}

	IEnumerator Action()
	{
		while (!isDie) 
		{
			switch (state) {
			case State.idle:
				break;

			case State.trace:
				//Debug.Log ("trace");
				//direction = (PlayerTr.position - Tr.position).normalized;
				//acceleration = 5f;
				//velocity = (velocity + acceleration) * Time.deltaTime;

				Quaternion rot = Quaternion.LookRotation(PlayerTr.position - Tr.position);
				//tr.Rotate(new Vector3(Player_tr.position.x, 0, 0));
				Tr.rotation = Quaternion.Slerp(this.Tr.rotation, rot, Time.deltaTime*2f);
				Tr.Translate (new Vector3(0, 0,1)* velocity);

				break;

			case State.attak:

				PlayerDB.DB.cur_Health -= damage;
				HP_Bar.MyHealthBarSetIsTrue = true;
				explosion.gameObject.SetActive (true);
				explosion.transform.position = Tr.position;
				this.gameObject.SetActive (false);
				//this.Rb.AddForce (new Vector3 (0, 0, 1) * velocity);
				break;
			}	
			yield return null;
		}	
	}

}
