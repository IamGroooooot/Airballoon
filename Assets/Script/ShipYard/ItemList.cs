using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{

    //Select Button
    //Choose Button
    public GameObject Sail_button;
    public GameObject Body_button;
    public GameObject Head_button;
    public GameObject Item_button;

    //Choose Button
    public GameObject sail_button;
    public GameObject body_button;
    public GameObject head_button;
    public GameObject item_button;

    //Ship icon
    public GameObject image;
    public Sprite sail;
    public Sprite body;
    public Sprite head;
    public Sprite item;


    //ItemList(대입)

    //Top
    public GameObject Balloon;
    public GameObject Sail1;
    public GameObject Sail2;

    //Body
    public GameObject Normal;
    public GameObject Speed;
    public GameObject Iron;

    //Head
    public GameObject Turtle;
    public GameObject Bird;
    public GameObject Horse;

    //Item
    public GameObject Gun;
    public GameObject Organ;
    public GameObject Deck;

    //Index(변수)
    public GameObject[] index = new GameObject[3];
    public int page = 0;
    public bool Tap;

    public Text HP;
    public Text SPEED;

    /*public bool sail;
	public bool body;
	public bool head;
	public bool item;*/

    void Start()
    {
        PlayerDB.DB.max_Health = 100f;
        PlayerDB.DB.max_Speed = 300f;
        PlayerDB.DB.Top = -1;
        PlayerDB.DB.Body = -1;
        PlayerDB.DB.Head = -1;
        PlayerDB.DB.Item = -1;
    }

    void Update()
    {
        HP.text = "체력 " + PlayerDB.DB.max_Health.ToString();
        SPEED.text = "항해속도 " + PlayerDB.DB.max_Speed.ToString();
    }

    //버튼 누르면 대입
    public void Sail()
    {
        //Button
        sail_button.gameObject.SetActive(true);
        body_button.gameObject.SetActive(false);
        head_button.gameObject.SetActive(false);
        item_button.gameObject.SetActive(false);

        image.gameObject.GetComponent<Image>().sprite = sail;
        Clear();
        Tap = true;
        index[0] = Balloon;
        index[1] = Sail1;
        index[2] = Sail2;
        //대입 후 초기화(index[0]부터)
        Initialize();
    }

    public void Body()
    {
        //Button
        sail_button.gameObject.SetActive(false);
        body_button.gameObject.SetActive(true);
        head_button.gameObject.SetActive(false);
        item_button.gameObject.SetActive(false);

        image.gameObject.GetComponent<Image>().sprite = body;
        Clear();
        Tap = true;
        index[0] = Speed;
        index[1] = Normal;
        index[2] = Iron;
        //대입 후 초기화(index[0]부터)
        Initialize();
    }

    public void Head()
    {
        //Button
        sail_button.gameObject.SetActive(false);
        body_button.gameObject.SetActive(false);
        head_button.gameObject.SetActive(true);
        item_button.gameObject.SetActive(false);

        image.gameObject.GetComponent<Image>().sprite = head;
        Clear();
        Tap = true;
        index[0] = Turtle;
        index[1] = Bird;
        index[2] = Horse;
        //대입 후 초기화(index[0]부터)
        Initialize();
    }

    public void Item()
    {
        //Button
        sail_button.gameObject.SetActive(false);
        body_button.gameObject.SetActive(false);
        head_button.gameObject.SetActive(false);
        item_button.gameObject.SetActive(true);

        image.gameObject.GetComponent<Image>().sprite = item;
        Clear();
        Tap = true;
        index[0] = Deck;
        index[1] = Gun;
        index[2] = Organ;
        //대입 후 초기화(index[0]부터)
        Initialize();
    }

    void Initialize()
    {
        // x-1, x, x+1
        page = 0;
        index[0].gameObject.SetActive(true);

        index[1].gameObject.SetActive(false);
        index[2].gameObject.SetActive(false);
    }

    void Clear()
    {
        index[0].gameObject.SetActive(false);
        index[1].gameObject.SetActive(false);
        index[2].gameObject.SetActive(false);
    }

    //다음 Index[i].gameObject.SetActive 상호작용
    public void Next()
    {
        if (Tap)
        {
            int LimitPage = page++;

            if (LimitPage == 2)
            {
                page = 0;
            }
            Debug.Log(page + "," + LimitPage);

            switch (page)
            {

                case 0:
                    index[0].gameObject.SetActive(true);
                    index[1].gameObject.SetActive(false);
                    index[2].gameObject.SetActive(false);
                    break;

                case 1:
                    index[1].gameObject.SetActive(true);
                    index[0].gameObject.SetActive(false);
                    index[2].gameObject.SetActive(false);
                    break;

                case 2:
                    index[2].gameObject.SetActive(true);
                    index[0].gameObject.SetActive(false);
                    index[1].gameObject.SetActive(false);
                    break;
            }
        }
    }

    //결정
    public void BodyChoose()
    {
        if (Tap)
        {
            PlayerDB.DB.Body = page;
            //능력치 부여
            switch (page)
            {
                case 0:
                    PlayerDB.DB.max_Health -= 20;
                    PlayerDB.DB.max_Speed += 50;
                    break;
                case 1:
                    break;
                case 2:
                    PlayerDB.DB.max_Health += 20;
                    PlayerDB.DB.max_Speed -= 50;
                    break;
            }
            body_button.gameObject.SetActive(false);
            Body_button.gameObject.SetActive(false);
        }
    }
    public void SailChoose()
    {
        if (Tap)
        {
            PlayerDB.DB.Top = page;
            switch (page)
            {
                case 0:
                    PlayerDB.DB.max_Health += 20;
                    PlayerDB.DB.max_Speed -= 50;
                    break;
                case 1:
                    break;
                case 2:
                    PlayerDB.DB.max_Health -= 20;
                    PlayerDB.DB.max_Speed += 50;
                    break;
            }
            sail_button.gameObject.SetActive(false);
            Sail_button.gameObject.SetActive(false);
        }
    }
    public void HeadChoose()
    {
        if (Tap)
        {
            PlayerDB.DB.Head = page;
            switch (page)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    PlayerDB.DB.max_Speed += 50;
                    break;
            }
            head_button.gameObject.SetActive(false);
            Head_button.gameObject.SetActive(false);
        }
    }
    public void ItemChoose()
    {
        if (Tap)
        {
            PlayerDB.DB.Item = page;
            switch (page)
            {
                case 0:
                    PlayerDB.DB.max_Health += 50;
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
        item_button.gameObject.SetActive(false);
        Item_button.gameObject.SetActive(false);
    }
}
