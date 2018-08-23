using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {

    public GameObject warning2;

	void OnTriggerEnter(Collider ColEnter)
	{
		if (ColEnter.gameObject.tag == "Player") 
		{
            warning2.gameObject.SetActive(true);
		}
	}
    private void OnTriggerStay(Collider ColStay)
    {
        //플레이어 속도 느려지도록, 범위에서 벗어나면 속도 원상복귀
    }
}
