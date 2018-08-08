using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    GameObject skillPanel;
   
    void Start()
    {
        skillPanel = GameObject.Find("Skill_Panel");
        
    }


    public void Skill1()//9번
    {
        
        if(skillPanel.transform.GetChild(0).childCount == 1)//스킬있다는 말임
        {
            GameObject skill = skillPanel.transform.GetChild(0).GetChild(0).gameObject;
            Debug.Log(skill.name+"발동!");
           
        }
    }

    public void Skill2()//10번
    {
        if (skillPanel.transform.GetChild(1).childCount == 1)//스킬있다는 말임
        {
            GameObject skill = skillPanel.transform.GetChild(1).GetChild(0).gameObject;
            Debug.Log(skill.name + "발동!");
        }
    }

    public void Skill3()//11번
    {
        if (skillPanel.transform.GetChild(2).childCount == 1)//스킬있다는 말임
        {
            GameObject skill = skillPanel.transform.GetChild(2).GetChild(0).gameObject;
            Debug.Log(skill.name + "발동!");
        }
    }
}
