using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockCtrl : MonoBehaviour
{

    private void OnTriggerEnter(Collider ColEnter)
    {
        if (ColEnter.gameObject.tag == "Player")
        {
            PlayerDB.DB.cur_Health -= 20;
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
