using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    // Variables
    private GameObject player;
    private Vector3 targetPos;
    private TargetPlayer targetPlayer;
    private Vector3 position = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        targetPlayer = gameObject.GetComponentInParent<TargetPlayer>();
        targetPos = targetPlayer.predPosition;
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = player.transform.position.x * speed;
        velocity.y = player.transform.position.y * speed;
        velocity.z = player.transform.position.z * speed;

        position += velocity * Time.deltaTime;
        transform.localPosition = position;
    }
}
