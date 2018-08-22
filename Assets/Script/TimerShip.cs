using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerShip : MonoBehaviour {
    //GameManager 게임 시스템을 전체 관리하는 스크립트

    public static TimerShip Instance = null;

    //전체 시간, 웨이브 관리, 이벤트
    bool WaveStart, StartTimer, TimerEnd = false;
	public float PerStageTime = 180f;
    public enum EventState {Playing,Ending};
    public EventState eventState = EventState.Playing;
   
    //배 아이콘 이동변수
	float X;
	float Distance;
	float Velocity;

    //보상변수
    public int kills; //킬수
    //PlayerDB에서 현재 체력
    public int bounus; //섬 퀘스트 수행 수 (비구름)
    public int Compensation = 100; //기본급 100원

    //UI
    public GameObject End;
    public Text compen;
    public Text amount;
    private int plus;
    private int Amount;


    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		X = GetComponent<RectTransform> ().anchoredPosition.x;
		Distance = X;
		Velocity = Mathf.Abs(Distance / PerStageTime);
		StartTimer = true; WaveStart = true;//TEst용
        //Distance = X , 속력 = Distance/perStageTime

        StartCoroutine(CheckTime());
        StartCoroutine(EventAction());

        //plus = (int)(Compensation * kills * 0.03) + (int)(Compensation * bounus * 0.05);
        //Compensation = Compensation + plus;
        //Amount = 100 + Compensation; //총 얻은 돈
                                     //보상

        
    }

    private void FixedUpdate()
    {
        PerStageTime -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
		if (StartTimer) {
			StartCoroutine (ShipTimerStart());
			StartTimer = false;
		}


        compen.text = " + " + plus.ToString();
        amount.text = Amount.ToString();
       

    }

	IEnumerator ShipTimerStart(){
		while (WaveStart) {
			if (GetComponent<RectTransform> ().anchoredPosition.x < 0) {
				X += Velocity * Time.deltaTime;
				GetComponent<RectTransform> ().anchoredPosition = new Vector2 (X, 0);
				yield return new WaitForEndOfFrame ();
			} else {
				WaveStart = false;
			}         
		}
	}
    IEnumerator CheckTime()
    {      
        while (!TimerEnd) {
            yield return new WaitForSeconds(0.5f); //0.5초마다 끝났는지 체크
            if (PerStageTime <= 0)
            {
                eventState = EventState.Ending;
            }
        }
    }

    IEnumerator EventAction()
    {
        while (!TimerEnd)
        {
            switch (eventState)
            {
                case EventState.Playing: //아무일도 없음 계속 진행

                    break;

                case EventState.Ending: //보상창 나옴
                    //보상창 ON
                    plus = (int)(Compensation * kills * 0.03) + (int)(Compensation * bounus * 0.05);
                    Compensation = Compensation + plus;
                    Amount = Compensation;
                    End.gameObject.SetActive(true);
                    PlayerDB.DB.gold += Amount;
                    TimerEnd = true;
                    break;
            }
            yield return null;
        }
    }    
}
