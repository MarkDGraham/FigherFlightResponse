using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject MenuObj;

	public void PlayButton() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("StageSelect");
	}

	public void ContributionsButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Contributions");
	}

	public void ControlsButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
	}

	public void QuitButton() {
		Application.Quit();
	}
}
