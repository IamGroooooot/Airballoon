using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCtrl : MonoBehaviour {

	public GameObject Tuto;
    public GameObject Tuto_complete;

    private void Start()
        //게임 시작하고 조립 후 월드맵 들어오면 ShipYard 완료
    {
        PlayerDB.DB.ShipYard = 1;
    }

    // Update is called once per frame
    void Update () {
		switch (PlayerDB.DB.Tuto) {
            case 0: //튜토리얼 미완료시
			Tuto.gameObject.SetActive (true);
                break;
            case 1: //튜토리얼 완료시,보상
			Tuto.gameObject.SetActive (false);
            Tuto_complete.gameObject.SetActive(true);                
                break;
            case 2:
                Tuto.gameObject.SetActive(false);
                Tuto_complete.gameObject.SetActive(false);
                break;
        }
	}

    public void Skip() {
        PlayerDB.DB.Tuto = 2;
        //Tuto_complete.gameObject.SetActive(false);
    }
}
