using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject sure;
    public GameObject scar;

    //ShipYard
    public void Scene_main()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ShipMain");
    }

    public void Scene_shipyardstore()
    {
        sure.gameObject.SetActive(true);
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

    public void ShipStoreYes()
    {
        if (PlayerDB.DB.gold >= 3000)
        {
            PlayerDB.DB.gold -= 3000;
            UnityEngine.SceneManagement.SceneManager.LoadScene("ShipStore");
        }
        else { scar.gameObject.SetActive(true); }
    }

    public void ShipStoreNo()
    {
        sure.gameObject.SetActive(false);
    }

    public void Pub()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pub");
    }

    //항해
    public void AztecGo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
