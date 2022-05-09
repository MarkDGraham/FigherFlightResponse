using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
	public GameObject MenuObj;

	public void WaterStage()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("WaterStage");
	}

	public void LandStage()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("LandStage");
	}

	public void MainMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
