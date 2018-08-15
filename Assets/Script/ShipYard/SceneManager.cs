using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	//ShipYard
	public void Scene_main()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("ShipMain");
	}

	public void Scene_store()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("ShipStore");
	}

	public void Scene_remodeling()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Remodeling");
	}

	//MainGame
	public void Scene_MainGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
	}
}
