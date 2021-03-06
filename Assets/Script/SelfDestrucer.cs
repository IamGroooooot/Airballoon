﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestrucer : MonoBehaviour
{

    public enum State { idle, trace, attak, die };
    public State state = State.idle;

    public GameObject explosion;

    private Transform Tr;
    private Transform PlayerTr;
    private Vector3 direction;
    public float velocity = 4.0f;
    //public float acceleration;

    public float MAX_HP = 25;
    public float HP = 25; //대포업그레이드 추가하면 HP높아짐 (박쥐<유령<오징어)
    public float attackDist = 30.0f;
    public float traceDist = 1000.0f;
    public bool isDie = false;

    public float damage = 10f;
    bool Slow;
    private bool DamPer3sec = false;
    float damTimer;
    public float thunderOrSnowDamage = 10f;
    //private Rigidbody Rb;

    // Use this for initialization
    private void OnEnable()
    {
        Slow = false;
        DamPer3sec = false;
        damTimer = 0f;
        isDie = false;
        HP = MAX_HP;
        explosion.gameObject.SetActive(false);
    }

    void Start()
    {
        Slow = false;
        DamPer3sec = false;
        damTimer = 0f;
        //Rb = this.GetComponent<Rigidbody> ();
        Tr = this.gameObject.GetComponent<Transform>();
        PlayerTr = PlayerManager.instance.player.transform;

        StartCoroutine(this.CheckState());
        StartCoroutine(this.Action());

    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Bullet"))
        {
            HP -= PlayerDB.DB.CannonDamage;
        }

        if (Col.CompareTag("SmallBullet"))
        {
            HP -= 2;
        }

        if (Col.CompareTag("Player"))
        {
            PlayerDB.DB.cur_Health -= damage;
        }
        if (Col.CompareTag("AirBomb"))
        {
            HP -= 300;
        }
    }

    void OnTriggerStay(Collider Col)
    {
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

        if (HP <= 0 && isDie == false)
        {
            
            explosion.gameObject.SetActive(true);
            explosion.transform.position = Tr.position;

            StartCoroutine(Die());

        }
    }

    IEnumerator CheckState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(PlayerTr.position, Tr.position);

            if (dist <= attackDist)
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
                    //Debug.Log ("trace");
                    //direction = (PlayerTr.position - Tr.position).normalized;
                    //acceleration = 5f;
                    //velocity = (velocity + acceleration) * Time.deltaTime;

                    Quaternion rot = Quaternion.LookRotation(PlayerTr.position - Tr.position);
                    //tr.Rotate(new Vector3(Player_tr.position.x, 0, 0));
                    Tr.rotation = Quaternion.Slerp(this.Tr.rotation, rot, Time.deltaTime * 2f);
                    if (Slow)
                    {
                        Tr.Translate(new Vector3(0, 0, 1) * velocity *0.5f);
                    }
                    else
                    {
                        Tr.Translate(new Vector3(0, 0, 1) * velocity);
                    }

                    break;

                case State.attak:
                    //explosion.GetComponent<AudioSource>().Play();
                    explosion.gameObject.SetActive(true);
                    explosion.transform.position = Tr.position;
                    StartCoroutine(Attacking());

                    break;
            }
            yield return null;
        }
    }

    private void OnDisable()
    {
        isDie = false;
        HP = MAX_HP;
    }
    void Kills()
    {
        TimerShip.Instance.kills++;
    }

    IEnumerator Die()
    {

        yield return new WaitForSeconds(0.1f);
        Kills();
        isDie = true;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.transform.parent.gameObject.SetActive(false); //비활

    }

    IEnumerator Attacking() {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<AudioSource>().Play();
        PlayerDB.DB.cur_Health -= damage;
        HP_Bar.MyHealthBarSetIsTrue = true;
        gameObject.transform.parent.gameObject.SetActive(false); //비활
    }
}
