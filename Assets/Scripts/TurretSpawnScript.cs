using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnScript : MonoBehaviour
{
    public static TurretSpawnScript inst;
    void Awake()
    {
        inst = this;
    }

    // Variables
    private GameObject player;
    public GameObject projectile;
    public PlayerMgr playerScript;
    public TurretBaseRotate turretRotation;

    private float distance, relativeSpeed, interceptTime, range;
    private float targetRange = Mathf.Infinity;
    private Vector3 predPosition = Vector3.zero;
    private float shellSpeed = 20.0f;
    public float rateOfFire = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerMgr>();
        turretRotation = transform.parent.gameObject.GetComponent<TurretBaseRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        range = (player.transform.position - transform.position).magnitude;

        if (turretRotation.isInPosition && (range <= targetRange))
        {
            rateOfFire -= Time.deltaTime;
            if (rateOfFire <= 0.0f)
            {
                GameObject shell = Instantiate(projectile, transform.position, transform.rotation);
                shell.GetComponent<Rigidbody>().velocity = (GetPredictionPosition() - shell.transform.position).normalized * shellSpeed;
                rateOfFire = 1.5f;
            }
        }

    }


    public Vector3 GetPredictionPosition()
    { 
        distance = (player.transform.position - transform.position).magnitude;
        relativeSpeed = Mathf.Abs((playerScript.velocity).magnitude - shellSpeed);
        interceptTime = distance / relativeSpeed;

        predPosition = player.transform.position + (playerScript.velocity * interceptTime);
        return predPosition;
    }
}
