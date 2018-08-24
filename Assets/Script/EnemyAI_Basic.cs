using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Basic : MonoBehaviour
{

    public enum State { idle, trace, attak, die };
    public State state = State.idle;

    public GameObject explosion;

    public Transform FirePos;
    private Transform Tr;
    private Transform PlayerTr;
    private Vector3 direction;

    //private Rigidbody Rb;
    private Vector3 WhereToFire;
    //public float acceleration;
    public float HP = 50;
    public float velocity = 2.0f;
    public float damping = 10f; //회전속도

    public float BulletSpeed = 500f;
    public float attackDist = 300.0f;
    public float traceDist = 1000.0f;
    public bool isDie = false;



    bool onFire;
    float timer;
    public float fireDelay = 3f;
    bool Slow;
    private bool DamPer3sec = false;
    float damTimer;
    public float thunderOrSnowDamage = 10f;

    // Use this for initialization
    void Awake()
    {
        Slow = false;
        DamPer3sec = false;
        damTimer = 0f;
        Tr = this.gameObject.GetComponent<Transform>();
        //Rb = this.GetComponent<Rigidbody>();
        onFire = false;
        timer = 0f;
    }

    private void Start()
    {
        Slow = false;
        DamPer3sec = false;
        damTimer = 0f;
        PlayerTr = PlayerManager.instance.player.transform;
    }

    private void OnEnable()
    {
        Slow = false;
        DamPer3sec = false;
        damTimer = 0f;
        StartCoroutine(this.CheckState());
        StartCoroutine(this.Action());
    }

    void Update()
    {

        if (DamPer3sec)
        {
            damTimer += Time.deltaTime;
            if (damTimer >= 3f)
            {
                HP -= thunderOrSnowDamage;
                damTimer = 0f;
            }
        }

        if (onFire)
        {
            timer += Time.deltaTime;
            if (timer >= fireDelay)
            {
                Fire();
                timer = 0f;
                onFire = false;
            }

        }

        


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
        if (Col.gameObject.CompareTag("Cloud"))
        {
            if (Col.GetComponent<RainCtrl>() != null || Col.GetComponent<SnowCtrl>() != null)
            {

                Slow = true;

            }
            

            if ((Col.GetComponent<ThunderCtrl>() != null && Col.GetComponent<ThunderCtrl>().makeThemThundered == true) || (Col.GetComponent<SnowCtrl>() != null && Col.GetComponent<SnowCtrl>().makeThemSlow == true))
            {
                DamPer3sec = true;

            }
            

        }
    }

    void OnTriggerExit(Collider Exit)
    {
        if (Exit.gameObject.CompareTag("Cloud"))
        {
            DamPer3sec = false;
            Slow = false;
        }
    }

    IEnumerator CheckState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(PlayerTr.position, Tr.position);

            if (HP <= 0)
            {
                
                explosion.gameObject.SetActive(true);
                //explosion.GetComponent<AudioSource>().Play();
                explosion.transform.position = this.transform.position;
                state = State.die;
            }

            else if (dist <= attackDist)
            {
                state = State.attak;
            }

            else if (dist <= traceDist)
            {
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
            switch (state)
            {
                case State.idle:
                    break;

                case State.trace:

                    Quaternion rot = Quaternion.LookRotation(PlayerTr.position - Tr.position);

                    Tr.rotation = Quaternion.Lerp(this.Tr.rotation, rot, Time.deltaTime * damping);
                    if (Slow)
                    {
                        Tr.Translate(new Vector3(0, 0, 1) * velocity*0.5f);
                    }
                    else
                    {
                        Tr.Translate(new Vector3(0, 0, 1) * velocity);
                    }

                    break;

                case State.attak:
                    Quaternion rot1 = Quaternion.LookRotation(PlayerTr.position - Tr.position);

                    Tr.rotation = Quaternion.Slerp(this.Tr.rotation, rot1, Time.deltaTime * damping);
                    //Logic: attak-idle-(delay)-attak-idle..순서로
                    //총알 발사 딜레이 시간 넣어줘 (스크립트 재사용 해야하니 미지수로) 
                    onFire = true;

                    break;

                case State.die:
                    //사망루틴(SetActive(false)-변수 초기화)	
                    gameObject.transform.parent.gameObject.SetActive(false); //패런츠를 비활성화
                    HP = 50f;
                    state = State.idle;
                    Kills();
                    isDie = true;

                    break;
            }
            yield return null;
        }
    }

    void Fire()
    {
        GameObject enemyBullet = ObjectPooling.pool.GetPoolObject_EnemyBullet();
        if (enemyBullet == null) return;

        enemyBullet.transform.position = FirePos.position;
        enemyBullet.transform.rotation = this.Tr.rotation;

        WhereToFire = PlayerTr.position - FirePos.position;

        enemyBullet.GetComponent<Rigidbody>().velocity = WhereToFire.normalized * BulletSpeed;
        enemyBullet.transform.GetChild(0).GetComponent<TrailRenderer>().Clear();

        enemyBullet.SetActive(true);
    }

    private void OnDisable()
    {
        isDie = false;
    }

    void Kills()
    {
        TimerShip.Instance.kills++;
    }
}
