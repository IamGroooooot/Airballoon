using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIctrl : MonoBehaviour {
	public GameObject Scroll;
	//icon
	public GameObject Figure_image;
	public Sprite Aztec;
	public Sprite Ghost;
	public Sprite Pirate;
	public Sprite Mask;
	public Sprite Scholar;

	public GameObject Weather;
	public Sprite rain;
	public Sprite thunder;
	public Sprite snowy; //방사능 눈
	public Sprite sunny;

	public Text explain;

	public Text gold;
	public Text log;
	public Text steel;

	// Update is called once per frame
	void Update () {
		gold.text = PlayerDB.gold.ToString ();
		log.text = PlayerDB.log.ToString ();
		steel.text = PlayerDB.steel.ToString ();
	}

	public void AztecButton(){
		Scroll.gameObject.SetActive (true);
		Figure_image.gameObject.GetComponent<Image>().sprite = Aztec;
		Weather.gameObject.GetComponent<Image> ().sprite = rain;
		explain.text = "";
	}
	public void GhostButton(){
		Scroll.gameObject.SetActive (true);
		Figure_image.gameObject.GetComponent<Image>().sprite = Ghost;
		Weather.gameObject.GetComponent<Image> ().sprite = thunder;
		explain.text = "";
	}
	public void PirateButton(){
		Scroll.gameObject.SetActive (true);
		Figure_image.gameObject.GetComponent<Image>().sprite = Pirate;
		Weather.gameObject.GetComponent<Image> ().sprite = thunder;
		explain.text = "";
	}
	public void MaskButton(){
		Scroll.gameObject.SetActive (true);
		Figure_image.gameObject.GetComponent<Image>().sprite = Mask;
		Weather.gameObject.GetComponent<Image> ().sprite = snowy;
		explain.text = "";
	}
	public void ScholarButton(){
		Scroll.gameObject.SetActive (true);
		Figure_image.gameObject.GetComponent<Image>().sprite = Scholar;
		Weather.gameObject.GetComponent<Image> ().sprite = snowy;
		explain.text = "";
	}

	public void ScrollExit(){
		Scroll.gameObject.SetActive (false);
	}
}
