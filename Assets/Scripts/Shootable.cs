using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
	public Entity381 rootObj;
	public float defense;		// between 0-1
	
	public void Damage(int damageTaken) {
		Debug.Log("Damage taken");
		rootObj.health -= damageTaken - (damageTaken * defense);
		if (rootObj.health <= 0) {
			rootObj.Kill();
		}
	}
}
