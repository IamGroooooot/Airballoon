using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCtrl : MonoBehaviour
{
    Vector3 RandomPos;

    public float damage;
    public static bool makeThemDamaged; //Snow = Meteor 같은 효과 (데미지) but 인스펙터에서 조정가능하도록 데미지 public
    // Use this for initialization
    void Awake()
    {
        StartCoroutine(MoveRandom());
    }

    void Update()
    {
        transform.Translate(RandomPos);


    }

    void OnTriggerEnter(Collider Enter)
    {
        OnTriggerStay(Enter);
    }
    void OnTriggerStay(Collider Stay)
    {
        makeThemDamaged = true;
        //Thunder Particle효과 ㅡ 온

    }

    // Update is called once per frame
    IEnumerator MoveRandom()
    {
        while (true)
        {
            RandomPos = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));

            yield return new WaitForSeconds(5.1f);
        }
    }
}
