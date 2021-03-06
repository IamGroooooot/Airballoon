﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    //public float max_Health;
    //public float cur_Health;
    public Image myHealthBar;
    public static float Damage = 20f;

    public static float HealValue = 2f;
    public static bool IsDamaged = false;
    public static bool IsHeal = false;
	public static bool MyHealthBarSetIsTrue= false;

    public GameObject FireSound;
    //Effects
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Smoke;

    public bool DamPer3sec = false;
    float damTimer;
    public float thunderOrSnowDamage = 10f;
    // Use this for initialization
    void Start()
    {
		StartCoroutine (SetHealthbar ());
        //max_Health = PlayerDB.DB.max_Health;
        //cur_Health = PlayerDB.DB.cur_Health;

        //cur_Health = max_Health;

        
        DamPer3sec = false;
        damTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (DamPer3sec)
        {
            damTimer += Time.deltaTime;
            if (damTimer >= 3f)
            {
                PlayerDB.DB.cur_Health -= thunderOrSnowDamage;
                damTimer = 0f;
            }
        }

        //화염 이펙트
        if (PlayerDB.DB.cur_Health/100 <= 0.6)
        {
            FireSound.SetActive(true);
            Fire1.gameObject.SetActive(true);

			if (PlayerDB.DB.cur_Health / 100 <= 0.4)
            {
                Fire2.gameObject.SetActive(true);

				if (PlayerDB.DB.cur_Health / 100 <= 0.2)
                {
                    Fire3.gameObject.SetActive(true);
                    Smoke.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            Fire1.gameObject.SetActive(false);
            Fire2.gameObject.SetActive(false);
            Fire3.gameObject.SetActive(false);
            Smoke.gameObject.SetActive(false);
            FireSound.SetActive(false);
        }

		if (PlayerDB.DB.cur_Health < 0)
        {
			//UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            //Debug.Log("체력 0  -  게임오버");  //게임 종료
			PlayerDB.DB.cur_Health = 0f;
        }
        else
        {
            if (IsDamaged)
            {
                HealthDecrease();
                IsDamaged = false;
            }
            if (IsHeal)
            {
                HealthIncrease();
                IsHeal = false;
            }
			if (PlayerDB.DB.cur_Health > PlayerDB.DB.max_Health)
            {
				PlayerDB.DB.cur_Health = PlayerDB.DB.max_Health;
            }
        }

		if (MyHealthBarSetIsTrue) {
			float calc_Health = PlayerDB.DB.cur_Health / PlayerDB.DB.max_Health;
			MyHealthBarSet (calc_Health);
			MyHealthBarSetIsTrue = false;
		}


    }
    void OnTriggerEnter(Collider Enter)
    {
        OnTriggerStay(Enter);

    }
    void OnTriggerStay(Collider C)
    {
        if (C.gameObject.CompareTag("Cloud"))
        {

            if ((C.GetComponent<ThunderCtrl>() != null && C.GetComponent<ThunderCtrl>().makeThemThundered == true) || (C.GetComponent<SnowCtrl>() != null && C.GetComponent<SnowCtrl>().makeThemSlow == true))
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

        }
    }

	IEnumerator SetHealthbar(){
		while (true) {
			float calc_Health = PlayerDB.DB.cur_Health / PlayerDB.DB.max_Health;
			MyHealthBarSet (calc_Health);
			yield return new WaitForSeconds (0.5f);
		}
	}

    void HealthDecrease()
    {
		//PlayerDB.DB.cur_Health -= Damage;

		float calc_Health = PlayerDB.DB.cur_Health / PlayerDB.DB.max_Health;
        MyHealthBarSet(calc_Health);

		//PlayerDB.DB.cur_Health = cur_Health;
    }

    void HealthIncrease()
    {
		PlayerDB.DB.cur_Health += PlayerDB.DB.max_Health*0.15f;

		float calc_Health = PlayerDB.DB.cur_Health / PlayerDB.DB.max_Health;
        MyHealthBarSet(calc_Health);

    }

    public void MyHealthBarSet(float myHealth)
    {
        myHealthBar.fillAmount = Mathf.Clamp(myHealth, 0f, 1f);

    }
}
