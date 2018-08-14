using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OnBecameInvisible 적이 사라지게 한다.

public class BalloonShipCtrl : MonoBehaviour {

    private void OnBecameInvisible()
    {
		this.gameObject.SetActive (false);
    }
}
