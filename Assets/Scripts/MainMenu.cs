using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject MenuObj;

	public void PlayButton() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Alpha");
	}

	public void QuitButton() {
		Application.Quit();
	}
}
