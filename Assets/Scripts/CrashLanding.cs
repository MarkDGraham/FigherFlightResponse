using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashLanding : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Terrain")
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverCrashed");
		}
	}
}
