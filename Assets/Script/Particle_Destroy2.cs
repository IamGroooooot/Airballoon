using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Destroy2 : MonoBehaviour
{
    //다중사용 가능하도록
    public float DestroyTime = 1.0f;

    void OnEnable()
    {
        // ps = GetComponent<ParticleSystem>();       
        StartCoroutine((Disable(DestroyTime)));
    }

    // Update is called once per frame
    /*void Update () {
        if (ps)
        {
            if (!ps.IsAlive())
            {
				
            }
        }
    }*/

    IEnumerator Disable(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.gameObject.SetActive(false);
    }
}
