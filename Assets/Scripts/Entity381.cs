using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity381 : MonoBehaviour
{
	public float health;
	public GameObject thisObject;

	public void Kill() {
		// maybe put an explosion here?
		thisObject.SetActive(false);
	}
}
