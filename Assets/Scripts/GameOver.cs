using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public GameObject MenuObj;

	public void MenuButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
	}
}
