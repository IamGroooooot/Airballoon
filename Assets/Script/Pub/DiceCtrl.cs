using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceCtrl : MonoBehaviour {

    public static DiceCtrl dice = null;

    public GameObject Result;
    public Sprite[] Dice_num = new Sprite[6];
    public int Dice = 1;

    private void Awake()
    {
        dice = this;
    }

    // Use this for initialization
    void Start () {
        Dice = Random.Range(1, 7);
        //Debug.Log(Dice);        
    }

    void Update()
    {
        switch (Dice)
        {
            case 1:
                Result.gameObject.GetComponent<Image>().sprite = Dice_num[0];
                break;
            case 2:
                Result.gameObject.GetComponent<Image>().sprite = Dice_num[1];
                break;
            case 3:
                Result.gameObject.GetComponent<Image>().sprite = Dice_num[2];
                break;
            case 4:
                Result.gameObject.GetComponent<Image>().sprite = Dice_num[3];
                break;
            case 5:
                Result.gameObject.GetComponent<Image>().sprite = Dice_num[4];
                break;
            case 6:
                Result.gameObject.GetComponent<Image>().sprite = Dice_num[5];
                break;
        }
    }
}
