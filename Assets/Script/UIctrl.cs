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

    public GameObject Gamble_Scroll;
    public GameObject Button;
    public GameObject Before_Gamble;
    public GameObject Dice_on;
    public Text Gamble_Dialog;
    public GameObject Result;
    public GameObject Result_Button;

	// Update is called once per frame
	void Update () {
		gold.text = PlayerDB.DB.gold.ToString ();
		log.text = PlayerDB.DB.log.ToString ();
		steel.text = PlayerDB.DB.steel.ToString ();
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

    public void UpgradeButton()
    {
        Scroll.gameObject.SetActive(true);
        Figure_image.gameObject.GetComponent<Image>().sprite = Aztec;
        Weather.gameObject.SetActive(false);
        explain.text = "";
    }

    public void Upgrade_ScrollExit(){
		Scroll.gameObject.SetActive (false);
        Figure_image.gameObject.GetComponent<Image>().sprite = Pirate;
        Button.gameObject.SetActive(true);
	}

    public void CannonUpgrade()
    {
        if (PlayerDB.DB.steel >= 5)
        {
            PlayerDB.DB.steel -= 5;
            PlayerDB.DB.CannonDamage += 1;
        }
        else { 
            //삐빅 효과음 
        }
    }

    public void SailUpgrade()
    {
        if (PlayerDB.DB.log >= 5)
        {
            PlayerDB.DB.log -= 5;
            PlayerDB.DB.rotationSpeed += 10;
            //선회최대속도 제한 = Max Speed로 놔야할듯
        }
        else
        {
            //삐빅 효과음 
        }
    }

    public void GambleButton()
    {
        Gamble_Scroll.gameObject.SetActive(true);
        Before_Gamble.gameObject.SetActive(true);

        //초기화
        Dice_on.gameObject.SetActive(false);
        Result_Button.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);
        //주사위 초기화
        DiceCtrl.dice.Dice = Random.Range(1, 7);
        //Debug.Log("초기화 이후 " + DiceCtrl.dice.Dice);

        Figure_image.gameObject.GetComponent<Image>().sprite = Ghost;
        Gamble_Dialog.text = "한판당 금 500이다. \n주사위 숫자 3이 나오면 5배!\n인생은 한방이다";
        Weather.gameObject.SetActive(false); //버튼 OFF
    }

    public void Gamble_ScrollExit()
    {
        Gamble_Scroll.gameObject.SetActive(false);
        Figure_image.gameObject.GetComponent<Image>().sprite = Pirate;
        Button.gameObject.SetActive(true);
    }

    public void FiveGold()
    {
        if (PlayerDB.DB.gold >= 500)
        {
            PlayerDB.DB.gold -= 500;
            Before_Gamble.gameObject.SetActive(false);
            Dice_on.gameObject.SetActive(true);
            StartCoroutine(DiceON());
            Gamble_Dialog.text = "(초긴장 상태)";
        }
        else { Gamble_Dialog.text = "금이 부족하잖아!"; }
    }

    IEnumerator DiceON()
    {
        yield return new WaitForSeconds(1.2f); //1.2초동안 기다리고 (다른 함수에게 양보)
        //결과창
        Result.gameObject.SetActive(true);

        if (DiceCtrl.dice.Dice == 1 || DiceCtrl.dice.Dice == 2 || DiceCtrl.dice.Dice == 4 || DiceCtrl.dice.Dice == 5 || DiceCtrl.dice.Dice == 6)
        {
            Gamble_Dialog.text = "인생은 실전이다";
        }
        if (DiceCtrl.dice.Dice == 3)
        {
            Gamble_Dialog.text = "으악 내돈!";
            PlayerDB.DB.gold += 3000;
        }

        Result_Button.gameObject.SetActive(true);

    }
}
