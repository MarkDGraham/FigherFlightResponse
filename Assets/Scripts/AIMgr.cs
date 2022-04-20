using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    private static AIMgr inst;

    public void Awake()
    {
        inst = this;
    }

    // Variables:
    private GameObject player;
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
        
    }

    void TargetPlayerPosition()
    {
        /*
        distance = (transform.position - player.transform.position).magnitude;
        relativeSpeed = player.velocity.magnitude;
        interceptTime = distance / relativeSpeed;

        predPosition = player.transform.position + (velocity * interceptTime);
        */
    }
}
