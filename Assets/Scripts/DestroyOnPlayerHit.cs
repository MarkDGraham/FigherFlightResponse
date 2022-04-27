using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerHit : MonoBehaviour
{
    public float spawnTimer = 15.0f;

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
            Destroy(gameObject);
        }



    }
}
