using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour {

    public static Tuto Tutorial;

    public bool EnterBuoy;
    public bool EnterCircle;
    public GameObject Officer;
    public GameObject BattleUI;

    public GameObject Explain1;
    public GameObject Explain2;
    public GameObject Explain3;
    public GameObject BlueCircle;
    public GameObject RedCircle;
    public GameObject Circle3;

    public GameObject Blueball;
    public GameObject Buoy;
    public GameObject Balloon;

    public int click;

    private void Awake()
    {
        Explain2.gameObject.SetActive(false);
        Explain3.gameObject.SetActive(false);
        Tutorial = this;
    }

    // Use this for initialization
    void Start () {
        BattleUI.gameObject.SetActive(false);
        Officer.gameObject.SetActive(true);
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

        if (EnemyCtrl.Instance.is_dead)
        {
            Level3();
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnterBuoy = true;
        }
    }

    void ReGame() {

        EnterBuoy = false;
        Officer.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        BattleUI.gameObject.SetActive(true);
        Officer.gameObject.SetActive(false);
        Explain1.gameObject.SetActive(false);
    }

    public void Enter()
    {
        Buoy.gameObject.SetActive(false);
        BlueCircle.gameObject.SetActive(false);
        EnterCircle = false;
        BattleUI.gameObject.SetActive(false);
        Officer.gameObject.SetActive(true);
        Explain2.gameObject.SetActive(true);

        RedCircle.gameObject.SetActive(true);
        Blueball.gameObject.SetActive(true);
    }

    public void Level3() {

        RedCircle.gameObject.SetActive(false);
        Blueball.gameObject.SetActive(false);

        EnemyCtrl.Instance.is_dead = false;
        BattleUI.gameObject.SetActive(false);
        Officer.gameObject.SetActive(true);
        Explain3.gameObject.SetActive(true);

        Circle3.gameObject.SetActive(true);
        Balloon.gameObject.SetActive(true);
    }
}
