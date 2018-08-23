using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour {

    public GameObject Player;
    public Transform startTr;
    public static Tuto Tutorial;

    public bool EnterBuoy;
    public bool EnterCircle;
    public GameObject Officer;
    public GameObject BattleUI;

    public GameObject Explain1;
    public GameObject Explain2;
    public GameObject Explain3;
    public GameObject Explain4;
    public GameObject BlueCircle;
    public GameObject RedCircle;
    public GameObject Circle3;
    public GameObject Exit;

    public GameObject Blueball;
    public GameObject Buoy;
    public GameObject Balloon;

    public bool Obj_dead;
    public bool Skull_dead;

    public Text explain;

    private void Awake()
    {      
        Explain2.gameObject.SetActive(false);
        Explain3.gameObject.SetActive(false);
        Explain4.gameObject.SetActive(false);
        Tutorial = this;
    }

    // Use this for initialization
    void Start () {
        BattleUI.gameObject.SetActive(false);
        Officer.gameObject.SetActive(true);
        explain.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (EnterBuoy == true)
        {
            ReGame();
        }

        if (EnterCircle)
        {
            Enter();
        }

        if (Obj_dead) //2단계 검은 공 파괴하면 Level3로 넘어감
        {
            Level3();
        }

        if (Skull_dead)
        {
            Level4();
        }
	}

    void ReGame() {

        EnterBuoy = false;
        Officer.gameObject.SetActive(true);
        explain.text = "실격, 다시";
        Player.transform.position = startTr.position;
    }

    public void StartGame()
    {
        BattleUI.gameObject.SetActive(true);
        Officer.gameObject.SetActive(false);
        Explain1.gameObject.SetActive(false);
    }

    public void Enter()
    {
        explain.text = "";
        Buoy.gameObject.SetActive(false);
        BlueCircle.gameObject.SetActive(false);
        EnterCircle = false;
        BattleUI.gameObject.SetActive(false);
        Officer.gameObject.SetActive(true);
        Explain2.gameObject.SetActive(true);

        RedCircle.gameObject.SetActive(true);
        Blueball.gameObject.SetActive(true);
    }

   //검은공 파괴시
    public void Level3() {
        GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(0);
        RedCircle.gameObject.SetActive(false);
        Blueball.gameObject.SetActive(false);

        Explain2.gameObject.SetActive(false);
        //EnemyCtrl.Instance.is_dead = false;
        BattleUI.gameObject.SetActive(false);

        Officer.gameObject.SetActive(true);
        Explain3.gameObject.SetActive(true);

        Circle3.gameObject.SetActive(true);
        Balloon.gameObject.SetActive(true);
        Obj_dead = false;
    }

    //해골비행선 죽이면 튜토리얼 끝남 -> 보상창 나타남(UI)
    public void Level4() {

        Circle3.gameObject.SetActive(false);
        Explain3.gameObject.SetActive(false);

        //대화 UI창 ON, Battle UI창 OFF
        BattleUI.gameObject.SetActive(false);
       
        Officer.gameObject.SetActive(true);;
        Explain4.gameObject.SetActive(true);

        Exit.gameObject.SetActive(true);
        Skull_dead = false;
    }

    public void TUtoOK()
    {
        PlayerDB.DB.Tuto = 1;
    }
}
