using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {

    public Transform[] points;

    //GameObject Island;
    int RadomNum = 0;
    public float createTime = 7f;
    public static EnemySpawner2 instance = null;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        points = GameObject.Find("Enemy_SpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            StartCoroutine(CreateGull());
        }
    }

    IEnumerator CreateGull()
    {
        while (true)
        {
            yield return new WaitForSeconds(createTime);

            RadomNum = Random.Range(1, 8);
            GameObject Island = null;
            if (RadomNum == 1)
            {
                Island = ObjectPooling.pool.GetPoolObject_Skull();

            }
            else if (RadomNum == 2)
            {
                Island = ObjectPooling.pool.GetPoolObject_Skull();

            }
            else if (RadomNum == 3)
            {
                Island = ObjectPooling.pool.GetPoolObject_Skull();

            }
            else if (RadomNum == 4)
            {
                Island = ObjectPooling.pool.GetPoolObject_Kanu();

            }
            else if (RadomNum == 5)
            {
                Island = ObjectPooling.pool.GetPoolObject_Kanu();

            }
            else if (RadomNum == 6)
            {
                Island = ObjectPooling.pool.GetPoolObject_Destructer();

            }
            else if (RadomNum == 7)
            {
                Island = ObjectPooling.pool.GetPoolObject_Destructer();

            }
            else
            {
                Island = ObjectPooling.pool.GetPoolObject_Destructer();

            }

            if (Island != null && !Island.activeSelf)
            {
                int Place_idx = Random.Range(1, points.Length);
                Island.transform.position = points[Place_idx].position;


                Island.SetActive(true);
            }
            else
            {

            }

        }


    }



}
