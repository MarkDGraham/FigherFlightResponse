using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerHit : MonoBehaviour
{
    public float spawnTimer = 5.0f;
    public Shootable shooter;
    public int gunDamage = 20;
	public Vector3 shellVelocity;

    void Update()
    {
		transform.position += shellVelocity * Time.deltaTime;

		spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
		Debug.Log(other.gameObject.tag);
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
