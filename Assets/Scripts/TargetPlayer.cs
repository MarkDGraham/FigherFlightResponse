using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    // Variables:
    private GameObject player;
    public GameObject ProjectilePrefab;
    private Vector3 offset = new Vector3(50.0f, 50.0f, 50.0f);
    private float shootDelay = 1.5f;
    private float distance, realtiveSpeed, interceptTime;
    public Vector3 predPosition;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        shootDelay -= Time.deltaTime;
        if(true && shootDelay <= 0)
        {
            predPosition = player.transform.position;
            Instantiate(ProjectilePrefab, transform);
            shootDelay = 1.5f;
        }
    }
}