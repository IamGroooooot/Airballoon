using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour {

    public GameObject Player;
    private Vector3 offset;

	public GameObject MainCam;
	public GameObject SubCam;
	public GameObject ZoomInButton;
	public GameObject InBattleUI;
	public GameObject InIslandUI;

	// Use this for initialization
	void Start () {
        
		mainCamOn ();

		offset = transform.position - Player.transform.position;

    }

	// Update is called once per frame
	void LateUpdate () {

        transform.position = Player.transform.position + offset;

    }

	public void ZoomClick()
	{
		Debug.Log ("Zoom in");
		subCamOn ();
		ZoomInButton.gameObject.SetActive (false);
		InBattleUI.gameObject.SetActive (false);
		InIslandUI.gameObject.SetActive (true);
	}

	public void mainCamOn()
	{
		MainCam.gameObject.SetActive(true);
		SubCam.gameObject.SetActive(false);
	}

	public void subCamOn()
	{
		SubCam.gameObject.SetActive(true);
		MainCam.gameObject.SetActive(false);
	}
}
