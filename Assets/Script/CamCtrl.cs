using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour {

    public GameObject Player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeRight; //주형 수정: 오른쪽가로로 스크린 고정 

        offset = transform.position - Player.transform.position;

    }
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = Player.transform.position + offset;

    }
}
