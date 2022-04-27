using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerHit : MonoBehaviour
{
    public float spawnTimer = 5.0f;
    public Shootable shooter;
    public int gunDamage = 20;

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            shooter = other.gameObject.GetComponent<Shootable>();
            if(shooter != null)
            {
                shooter.Damage(gunDamage);
			}
			Destroy(gameObject);
		}
	}
}
