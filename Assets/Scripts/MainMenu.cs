using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject MenuObj;

	public void PlayButton() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Alpha");
		Debug.Log("Play Button Clicked");
	}

	public void QuitButton() {
		Application.Quit();
	}
}
