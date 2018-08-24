using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public AudioSource enter;

    //public GameObject _Enter;

    void OnTriggerEnter(Collider ColEnter)
    {
        if (ColEnter.gameObject.tag == "Player")
        {
            enter.Play();
            PlayerDB.DB.gold += 10;
            StartCoroutine(Entering());
        }
    }
    IEnumerator Entering()
    {
        yield return new WaitForSeconds(0.8f);
        Tuto.Tutorial.EnterCircle = true;
    }
}
