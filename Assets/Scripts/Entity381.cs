using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity381 : MonoBehaviour
{
	public float health;
	public GameObject thisObject;

	public void Kill()	{
		// maybe put an explosion here?
		
		if (thisObject.tag == "Finish") {
			GameObject playerObject = GameObject.Find("Player");
			PlayerMgr player = playerObject.GetComponent<PlayerMgr>();
			player.EndLevel();
		}

		if (thisObject.tag == "Player")
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverDestroyed");
		}
		thisObject.SetActive(false);
	}
}
