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

    public float distance, relativeSpeed, interceptTime, range;
    private float targetRange = 250.0f;
    public Vector3 predPosition = Vector3.zero;
	public Vector3 shellVelocity;
    private float shellSpeed = 60.0f;
    public float rateOfFire = 0.5f;
    
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

		if (rateOfFire > 0.0f)
			rateOfFire -= Time.deltaTime;

        if (turretRotation.isInPosition && (range <= targetRange))
        {
            if (rateOfFire <= 0.0f)
            {
                GameObject shell = Instantiate(projectile, transform.position, transform.rotation);
				shellVelocity = (GetPredictionPosition() - transform.position).normalized * shellSpeed;
				shell.GetComponent<DestroyOnPlayerHit>().shellVelocity = shellVelocity;
				Debug.DrawRay(transform.position, shellVelocity, Color.red, 1.0f);
				rateOfFire = 0.5f;
            }
        }

    }

    public Vector3 GetPredictionPosition()
    { 
        distance = (player.transform.position - transform.position).magnitude;
        relativeSpeed = Mathf.Abs(playerScript.speed - shellSpeed);
        interceptTime = distance / relativeSpeed;

        predPosition = player.transform.position + (playerScript.velocity * interceptTime);
        return predPosition;
    }
}
