using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Island : MonoBehaviour {

	public GameObject MainCam;
	public GameObject SubCam;
	public GameObject InBattleUI;
	public GameObject Island_UI;
	public GameObject Store_UI;
	public GameObject Pub_UI;

	public void Exit()
	{
		SubCam.gameObject.SetActive (false);
		MainCam.gameObject.SetActive (true);
		InBattleUI.gameObject.SetActive (true);
		Island_UI.gameObject.SetActive (false);
		Store_UI.gameObject.SetActive (false);
		Pub_UI.gameObject.SetActive (false);
	}

	public void Store()
	{
		Store_UI.gameObject.SetActive (true);
	}

	public void Pub()
	{
		Pub_UI.gameObject.SetActive (true);
	}
}
