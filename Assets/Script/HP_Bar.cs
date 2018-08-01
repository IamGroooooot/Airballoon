using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    public float max_Health = 100f;
    public float cur_Health = 0;
    public Image myHealthBar;
    public static float Damage = 20f;
    public static float HealValue = 2f;
    public static bool IsDamaged = false;
    public static bool IsHeal = false;


    // Use this for initialization
    void Start()
    {
        cur_Health = max_Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_Health <= 0)
        {
            SceneManager.LoadScene(1);
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

    }
    void HealthIncrease()
    {
        cur_Health += HealValue;

        float calc_Health = cur_Health / max_Health;
        MyHealthBarSet(calc_Health);
    }

    public void MyHealthBarSet(float myHealth)
    {
        myHealthBar.fillAmount = Mathf.Clamp(myHealth, 0f, 1f);

    }
}
