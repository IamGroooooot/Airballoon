using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIctrl : MonoBehaviour
{
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

    public GameObject[] Sail_Buttons = new GameObject[5];

    public GameObject Resource;

    // Update is called once per frame
    void Update()
    {
        gold.text = PlayerDB.DB.gold.ToString();
        log.text = PlayerDB.DB.log.ToString();
        steel.text = PlayerDB.DB.steel.ToString();
    }

    public void AztecButton()
    {
        Scroll.gameObject.SetActive(true);
        Figure_image.gameObject.GetComponent<Image>().sprite = Aztec;
        Weather.gameObject.GetComponent<Image>().sprite = rain;
        explain.text = "대언이가 쓸겁니다.\n 이 악당을 퇴치하기 위해선 큰 각오를 해야합니다.\n끔찍하고 어두운 기운이 섬을 감싸고 있어 천둥 번개가 내립니다.\n\n벼락에 맞으면 배가 파손되니 주의하세요!";
        Sail_Buttons[0].gameObject.SetActive(true);
        Sail_Buttons[1].gameObject.SetActive(false);
        Sail_Buttons[2].gameObject.SetActive(false);
        Sail_Buttons[3].gameObject.SetActive(false);
        Sail_Buttons[4].gameObject.SetActive(false);
    }
    public void GhostButton()
    {
        Scroll.gameObject.SetActive(true);
        Figure_image.gameObject.GetComponent<Image>().sprite = Ghost;
        Weather.gameObject.GetComponent<Image>().sprite = thunder;
        explain.text = "이 악랄한 망령 해적은 죽이거나 죽는 것이 소원입니다.\n 이 악당을 퇴치하기 위해선 큰 각오를 해야합니다.\n끔찍하고 어두운 기운이 섬을 감싸고 있어 천둥 번개가 내립니다.\n\n벼락에 맞으면 배가 파손되니 주의하세요!";
        Sail_Buttons[1].gameObject.SetActive(true);
        Sail_Buttons[0].gameObject.SetActive(false);
        Sail_Buttons[2].gameObject.SetActive(false);
        Sail_Buttons[3].gameObject.SetActive(false);
        Sail_Buttons[4].gameObject.SetActive(false);
    }
    public void PirateButton()
    {
        Scroll.gameObject.SetActive(true);
        Figure_image.gameObject.GetComponent<Image>().sprite = Pirate;
        Weather.gameObject.GetComponent<Image>().sprite = thunder;
        explain.text = "인신 매매를 주업으로 삼아온 범죄자 해적단입니다.\n혹시나 좋은 녀석일까 하는 생각은 해선 안됩니다.\n\n비겁한 해적은 끔찍한 기후 속으로 숨었습니다. 천둥 번개가 내립니다.\n벼락에 맞으면 배가 파손되니 주의하세요!";
        Sail_Buttons[2].gameObject.SetActive(true);
        Sail_Buttons[1].gameObject.SetActive(false);
        Sail_Buttons[0].gameObject.SetActive(false);
        Sail_Buttons[3].gameObject.SetActive(false);
        Sail_Buttons[4].gameObject.SetActive(false);
    }
    public void MaskButton()
    {
        Scroll.gameObject.SetActive(true);
        Figure_image.gameObject.GetComponent<Image>().sprite = Mask;
        Weather.gameObject.GetComponent<Image>().sprite = snowy;
        explain.text = "알 수 없는 실험으로 베일에 싸인 집단입니다.\n포로를 실험에 사용하지만 살아서 나온이는 없습니다.\n\n주변 환경은 실험의 후폭풍으로 오염되었습니다.방사능 안개가 내립니다.\n방사능에 피폭되면 플레이어가 아픕니다.";
        Sail_Buttons[3].gameObject.SetActive(true);
        Sail_Buttons[1].gameObject.SetActive(false);
        Sail_Buttons[2].gameObject.SetActive(false);
        Sail_Buttons[0].gameObject.SetActive(false);
        Sail_Buttons[4].gameObject.SetActive(false);
    }
    public void ScholarButton()
    {
        Scroll.gameObject.SetActive(true);
        Figure_image.gameObject.GetComponent<Image>().sprite = Scholar;
        Weather.gameObject.GetComponent<Image>().sprite = snowy;
        explain.text = "열권의 건조한 사막섬은 오로라로 둘러싸여있습니다.\n사막섬의 주민들은 아름다운 하늘을 지키기 위해 필사적입니다.\n\n열권의 아름다운 환경은 날카로운 이빨을 숨기고 있습니다.유성이 떨어집니다.\n유성에 피격되면 큰 충격을 받습니다.";
        Sail_Buttons[4].gameObject.SetActive(true);
        Sail_Buttons[1].gameObject.SetActive(false);
        Sail_Buttons[2].gameObject.SetActive(false);
        Sail_Buttons[3].gameObject.SetActive(false);
        Sail_Buttons[0].gameObject.SetActive(false);
    }

    public void Sail_Exit()
    {
        Scroll.gameObject.SetActive(false);
        explain.text = "";
    }

    public void UpgradeButton()
    {
        Scroll.gameObject.SetActive(true);
        Figure_image.gameObject.GetComponent<Image>().sprite = Aztec;
        Weather.gameObject.SetActive(false);
        explain.text = "";
    }

    public void Upgrade_ScrollExit()
    {
        Scroll.gameObject.SetActive(false);
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
        else
        {
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

    public void Resource_Purchasing()
    {
        Resource.gameObject.SetActive(true);
    }

    public void Resource_Exit()
    {
        Resource.gameObject.SetActive(false);
    }

    public void Log_buying()
    {
        if (PlayerDB.DB.gold >= 100)
        {
            PlayerDB.DB.gold -= 100;
            PlayerDB.DB.log++;
        }
    }

    public void Steel_buying()
    {
        if (PlayerDB.DB.gold >= 150)
        {
            PlayerDB.DB.gold -= 150;
            PlayerDB.DB.steel++;
        }
    }
}
