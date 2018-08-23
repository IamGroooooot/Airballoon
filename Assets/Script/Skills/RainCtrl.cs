﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCtrl : MonoBehaviour {

    public float WhenToDestroy;
    Vector3 RandomPos;

    public static bool makeThemSlow;
    // Use this for initialization
    void OnEnable () {
        StartCoroutine(MoveRandom());

        StartCoroutine((Disable(WhenToDestroy)));
        //Destroy(this.gameObject, WhenToDestroy);
    }

    private void Update()
    {
        transform.Translate(RandomPos);
    }

    void OnTriggerEnter(Collider Enter)
    {
        OnTriggerStay(Enter);
    }
    void OnTriggerStay(Collider Stay)
    {
        makeThemSlow = true;
        //Slow Particle효과 ㅡ 온

    }
        
        // Update is called once per frame
	IEnumerator MoveRandom()
    {
        while (true)
        {
            RandomPos = new Vector3( Random.Range(-1, 1), 0, Random.Range(-1, 1));
            yield return new WaitForSeconds(5.1f);
        }
    }


IEnumerator Disable(float waitTime)
{
    yield return new WaitForSeconds(waitTime);
    this.gameObject.SetActive(false);
}
}
