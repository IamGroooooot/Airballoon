using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCtrl : MonoBehaviour {
    Vector3 RandomPos;

    public bool makeThemThundered;
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
        makeThemThundered = true;

    }
    void OnTriggerExit(Collider Exit)
    {
        makeThemThundered = false;


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
