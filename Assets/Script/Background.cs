using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public Transform playerTrans;
    public GameObject[] Backgroound_UL; //크기 영이면 오류나게 설정

    public float BgUlSpeed=0.1f;
    public float BgUlDir_X = 0;
    public float BgUlDir_Y = 0;
    WindArea mWindArea;

    // Use this for initialization
    void Start () {
        mWindArea = GameObject.FindGameObjectWithTag("WindArea").GetComponent<WindArea>();

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTrans.position;
        BgUlDir_X += mWindArea.direction.x*BgUlSpeed*Time.deltaTime;
        BgUlDir_Y += mWindArea.direction.z*BgUlSpeed*Time.deltaTime; //*주의*//WindArea의 Z성분을 Y로 설정함
        foreach(GameObject go in Backgroound_UL)
        {
            go.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(BgUlDir_X, BgUlDir_Y);
        }
    }
}
