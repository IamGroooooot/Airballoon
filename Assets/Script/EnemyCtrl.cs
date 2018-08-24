using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OnBecameInvisible 적이 사라지게 한다.
//SKull Balloon용 스크립트
public class EnemyCtrl : MonoBehaviour
{

    public static EnemyCtrl Instance;

    public float Max_Hp;
    public float HP;
    public bool is_dead;
    int OnlyOnce=0;

    public GameObject explosion;


    private Transform Tr;


    public Animator ani;

    void Awake()
    {
        Instance = this;

        //setAirshipPos = true;
    }

    private void OnEnable()
    {
        OnlyOnce = 0;
        is_dead = false;
        HP = 100;
        ani.SetBool("isDie", false);
        explosion.gameObject.SetActive(false);
    }

    void Start()
    {


        Tr = this.GetComponent<Transform>();
        Max_Hp = HP;
        is_dead = false;
    }


    void OnTriggerEnter(Collider Col)
    {

        if (Col.CompareTag("Bullet"))
        {
            HP -= PlayerDB.DB.CannonDamage;
        }

        if (Col.CompareTag("SmallBullet"))
        {
            HP -= 1;
        }
        if (Col.CompareTag("AirBomb"))
        {
            HP -= 300;
        }
    }
    void FixedUpdate()
    {

    }

    void Update()
    {
        
        if (HP <= 0 )
        {
            explosion.gameObject.SetActive(true);
            explosion.transform.position = Tr.position;
            ani.SetBool("isDie", true);
            StartCoroutine(Die());           
        }

        if((HP<=0) && OnlyOnce ==0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            OnlyOnce++;

        }

    }

    private void OnBecameInvisible()
    {
        
        gameObject.transform.GetChild(1).GetComponent<Ball_CtrlOnDetact>().canAttack = false;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);

        is_dead = false;
        HP = Max_Hp;
        gameObject.transform.parent.gameObject.SetActive(false);//얘가 아니라 얘의 부모를 SetActive(false)해야됨

    }

    private void OnDisable()
    {
        
        is_dead = false;
        HP = Max_Hp;
        OnlyOnce = 0;
        ani.SetBool("isDie", false);
        explosion.gameObject.SetActive(false);
    }

    void Kills()
    {
        TimerShip.Instance.kills++;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1.2f);
        Kills();
        is_dead = true;
        
        gameObject.transform.parent.gameObject.SetActive(false); //비활

    }
}
