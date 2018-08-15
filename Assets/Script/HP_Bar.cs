using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    public float max_Health;
    public float cur_Health;
    public Image myHealthBar;
    public static float Damage = 20f;
    public static float HealValue = 2f;
    public static bool IsDamaged = false;
    public static bool IsHeal = false;

    //Effects
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Smoke;


    // Use this for initialization
    void Start()
    {
		max_Health = PlayerDB.DB.max_Health;
		cur_Health = PlayerDB.DB.cur_Health;

        cur_Health = max_Health;
    }

    // Update is called once per frame
    void Update()
    {
        //화염 이펙트
        if (cur_Health/100 <= 0.6)
        {
            Fire1.gameObject.SetActive(true);

            if (cur_Health / 100 <= 0.4)
            {
                Fire2.gameObject.SetActive(true);

                if (cur_Health / 100 <= 0.2)
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
        }

        if (cur_Health <= 0)
        {
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            Debug.Log("체력 0  -  게임오버");  //게임 종료
            cur_Health = 0f;
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
            if (cur_Health > max_Health)
            {
                cur_Health = max_Health;
            }
        }
    }

    void HealthDecrease()
    {
        cur_Health -= Damage;

        float calc_Health = cur_Health / max_Health;
        MyHealthBarSet(calc_Health);

		PlayerDB.DB.cur_Health = cur_Health;
    }

    void HealthIncrease()
    {
		cur_Health += max_Health*0.1f;

        float calc_Health = cur_Health / max_Health;
        MyHealthBarSet(calc_Health);

		PlayerDB.DB.cur_Health = cur_Health;
    }

    public void MyHealthBarSet(float myHealth)
    {
        myHealthBar.fillAmount = Mathf.Clamp(myHealth, 0f, 1f);

    }
}
