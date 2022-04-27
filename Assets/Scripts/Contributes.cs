using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contributes : MonoBehaviour
{
	public GameObject MenuObj;

	public void PlayButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
	}
}
