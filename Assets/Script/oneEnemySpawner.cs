using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneEnemySpawner : MonoBehaviour
{

    public Transform[] points;

    public GameObject Gull_Prefab1;
    //public GameObject Gull_Prefab2;

    public List<GameObject> GullPool = new List<GameObject>();

    public float createTime = 7f;

    public int MaxGull = 2;

    public bool Gull_On = true;
    public static oneEnemySpawner instance = null;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        points = GameObject.Find("Enemy_SpawnPoint").GetComponentsInChildren<Transform>();

        for (int i = 0; i < MaxGull; i++)
        {
            GameObject gull = Instantiate(Gull_Prefab1);
            //GameObject gull2 = Instantiate (Gull_Prefab2);

            gull.SetActive(false);
            //gull2.SetActive (false);

            GullPool.Add(gull);
            //GullPool.Add (gull2);
        }

        if (points.Length > 0)
        {
            StartCoroutine(CreateGull());
        }
    }

    IEnumerator CreateGull()
    {
        while (Gull_On)
        {
            //int gullCount = (int)GameObject.FindGameObjectsWithTag ("Gull").Length;
            yield return new WaitForSeconds(createTime);

            foreach (GameObject gull in GullPool)
            {
                if (!gull.activeSelf)
                {
                    int Place_idx = Random.Range(1, points.Length);
                    gull.transform.position = points[Place_idx].position;
                    gull.SetActive(true);

                    break;
                }
            }

        }

    }
}
