using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour {
    GameObject skillPanel;
	GameObject skill;
	SkillList mySkillList;
	public GameObject Btn1;
	public GameObject Btn2;
	public GameObject Btn3;
	GameObject coolTimeText1;
	GameObject coolTimeText2;
	GameObject coolTimeText3;

	float coolTime1;
	float coolTime2;
	float coolTime3; 
	bool timer1On;
	bool timer2On;
	bool timer3On;




    void Start()
    {
        skillPanel = GameObject.Find("Skill_Panel");
		skill = GameObject.Find ("Skill");
		mySkillList = skill.transform.GetChild(0).GetComponent<SkillList>();
		timer1On = false;
		timer2On = false;
		timer3On = false;
		coolTimeText1 = Btn1.transform.GetChild(0).gameObject;
		coolTimeText2 = Btn2.transform.GetChild(0).gameObject;
		coolTimeText3 = Btn3.transform.GetChild(0).gameObject;

		coolTimeText1.SetActive (false);
		coolTimeText2.SetActive (false);
		coolTimeText3.SetActive (false);
    }
	void Update()
	{
		if (timer1On == true) 
		{
			//Cool time Show
			coolTimeText1.SetActive (true);
			coolTimeText1.GetComponent<Text> ().text = ((int)coolTime1+1).ToString();
			coolTime1 -= Time.deltaTime;
			if (coolTime1 <=0) 
			{//쿨임 다됨
				coolTimeText1.SetActive (false);
				Btn1.GetComponent<Button> ().interactable = true;
				timer1On = false;
			}
		} 
		if (timer2On == true) 
		{
			coolTimeText2.SetActive (true);
			coolTimeText2.GetComponent<Text> ().text = ((int)coolTime2+1).ToString();
			coolTime2 -= Time.deltaTime;
			if (coolTime2 <=0) 
			{//쿨임 다됨
				coolTimeText2.SetActive (false);
				Btn2.GetComponent<Button> ().interactable = true;
				timer2On = false;
			}
		} 
		if (timer3On == true) 
		{
			coolTimeText3.SetActive (true);
			coolTimeText3.GetComponent<Text> ().text = ((int)coolTime3+1).ToString();
			coolTime3 -= Time.deltaTime;
			if (coolTime3 <=0) 
			{//쿨임 다됨
				coolTimeText3.SetActive (false);
				Btn3.GetComponent<Button> ().interactable = true;
				timer3On = false;
			}
		} 


	}

    public void Skill1()//slot 9번 스킬눌렀을때 
    {
        
        if(skillPanel.transform.GetChild(0).childCount == 1)//스킬있다는 말임
        {
            GameObject skill1 = skillPanel.transform.GetChild(0).GetChild(0).gameObject;
			Item mySkill1 = skill1.GetComponent<ItemData> ().item;
			ExecuteSkill (mySkill1.ID,1);

			Debug.Log(skill1.name+"발동!");
			Btn1.GetComponent<Button> ().interactable = false;
			//버튼 비활성화
        }
    }

	public void Skill2()//slot 10번 스킬눌렀을때
    {
        if (skillPanel.transform.GetChild(1).childCount == 1)//스킬있다는 말임
        {
            GameObject skill2 = skillPanel.transform.GetChild(1).GetChild(0).gameObject;
			Item mySkill2 = skill2.GetComponent<ItemData> ().item;
			ExecuteSkill (mySkill2.ID,2);

            Debug.Log(skill2.name + "발동!");
			Btn2.GetComponent<Button> ().interactable = false;
			//버튼 비활성화
        }
    }

	public void Skill3()//slot 11번 스킬눌렀을때
    {
        if (skillPanel.transform.GetChild(2).childCount == 1)//스킬있다는 말임
        {
            GameObject skill3 = skillPanel.transform.GetChild(2).GetChild(0).gameObject;
			Item mySkill3 = skill3.GetComponent<ItemData> ().item;
			ExecuteSkill (mySkill3.ID,3);

            Debug.Log(skill3.name + "발동!");
			Btn3.GetComponent<Button> ().interactable = false;
			//버튼 비활성화
        }
    }


	void ExecuteSkill(int skillId,int WhichBtn)
	{
		float cool;

		switch (skillId)
		{
		case 0:
			mySkillList.Repair ();
			cool = mySkillList.cool0;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}

			break;
		case 1:
			mySkillList.Booster ();
			cool = mySkillList.cool1;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;

		case 2:
			mySkillList.Drone ();
			cool = mySkillList.cool2;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;

		case 3:
			mySkillList.Shield ();
			cool = mySkillList.cool3;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;

		case 4:
			mySkillList.Balloon ();
			cool = mySkillList.cool4;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;
		case 5:
			mySkillList.Rain ();
			cool = mySkillList.cool5;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;
		case 6:
			mySkillList.SpeedCloud ();
			cool = mySkillList.cool6;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;
		case 7:
			mySkillList.Thunder ();
			cool = mySkillList.cool7;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;
		case 8:
			mySkillList.Anchor ();
			cool = mySkillList.cool8;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;
		case 9:
			mySkillList.WaterBomb ();
			cool = mySkillList.cool9;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;
		case 10:
			mySkillList.Chain ();
			cool = mySkillList.cool10;
			if (WhichBtn == 1) {
				coolTime1 = cool;
				timer1On = true;
			} else if (WhichBtn == 2) {
				coolTime2 = cool;
				timer2On = true;
			} else {
				coolTime3 = cool;
				timer3On = true;
			}
			break;

		default:
			Debug.Log ("해당하는 스킬 없음");
			break;
		}

	}

}
