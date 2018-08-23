using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusCtrl : MonoBehaviour {

    public static BonusCtrl Instance2 = null;
    public GameObject BonusBubble;
    public int Bonus;
    public Text BonusText;

    private void Awake()
    {
        Instance2 = this;
    }

    private void Start()
    {
        //Debug.Log(Bonus);
        //BonusText.text = "";
    }

    private void Update()
    {
        //BonusText.text = "+ " + Bonus.ToString();
    }

    private void OnTriggerEnter(Collider ColEnter)
    {
        if (ColEnter.gameObject.tag == "Player")
        {
            TimerShip.Instance.bounus += Bonus;
            BonusBubble.gameObject.SetActive(true);
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
