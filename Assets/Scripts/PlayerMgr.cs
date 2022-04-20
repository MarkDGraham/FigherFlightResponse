using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
	// Changing variables
	public Vector3 position;
	public Vector3 velocity = Vector3.zero;

	public float speed;
	public float desiredSpeed;
	public float heading;
	public int hull;

	// Constant variables
	public float acceleration;
	public float turnRate;
	public float maxSpeed;
	public float minSpeed;
	
	public GameObject pitchNode;

	// transitional variables
	float deltaSpeed;
	float deltaHeading;
	float deltaPitch;
	Vector3 currentEuler = Vector3.zero;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Adjust acceleration
		deltaSpeed = Input.GetAxis("Vertical"); // {-1, 0, 1}
		desiredSpeed += deltaSpeed;
		desiredSpeed = Utils.Clamp(desiredSpeed, minSpeed, maxSpeed);

		// Adjust yaw
		deltaHeading = 20 * Input.GetAxis("Horizontal");	// {-10, 0, 10}
		heading += deltaHeading * Time.deltaTime;
		heading = Utils.DegreeClamp(heading);

		// Adjust pitch
		currentEuler = pitchNode.transform.localEulerAngles;
		deltaPitch = 0.5f *Input.GetAxis("Pitch");
		currentEuler.x += deltaPitch;
		pitchNode.transform.localEulerAngles = currentEuler;

		// fire weapon
    }
}
