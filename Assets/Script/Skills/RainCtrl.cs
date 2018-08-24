using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCtrl : MonoBehaviour {

    float WhenToDestroy = 40f;
    Vector3 RandomPos;

    public bool makeThemSlow;
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
        if (Stay.GetComponent<Rigidbody>() != null) {
            Stay.GetComponent<Rigidbody>().drag = 2f;
        }
        //Slow Particle효과 ㅡ 온
    }
    void OnTriggerExit(Collider other)
    {
        makeThemSlow = false;
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().drag = 1f;
        }
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
