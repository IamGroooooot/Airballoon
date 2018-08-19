using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    //ShipYard
    public void Scene_main()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ShipMain");
    }

    public void Scene_shipyardstore()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ShipStore");
    }

    public void Scene_remodeling()
    {
        if (PlayerDB.DB.Top == -1 || PlayerDB.DB.Body == -1 || PlayerDB.DB.Head == -1 || PlayerDB.DB.Item == -1)
        {
            Debug.Log("장착 미완료");
        }
        else { UnityEngine.SceneManagement.SceneManager.LoadScene("Remodeling"); }
    }

    //MainGame
    public void Scene_MainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void Scene_Store()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Store");
    }

    public void Scene_WorldMap()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
    }

    public void Tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }
}
