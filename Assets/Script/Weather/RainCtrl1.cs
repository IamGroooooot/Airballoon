using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCtrl1 : MonoBehaviour {

    public GameObject warning2;

    void OnTriggerEnter(Collider ColEnter)
    {
        if (ColEnter.gameObject.tag == "Player")
        {
            warning2.gameObject.SetActive(true);
            //경고문구 표시 후 범위안에 있으면 속도 감소
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //벗어나면 속도 정상화
    }
}
