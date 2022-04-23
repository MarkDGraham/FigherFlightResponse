using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
	public int currentHealth;
	
	public void Damage(int damageTaken) {
		Debug.Log("Damage taken");
		currentHealth -= damageTaken;
		if (currentHealth <= 0) {
			gameObject.SetActive(false);
		}
	}
}
