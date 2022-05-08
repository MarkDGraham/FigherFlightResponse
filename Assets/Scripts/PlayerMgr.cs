using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
	public PlayerSfx playerSound;

	// Changing movement variables
	public Vector3 position;
	public Vector3 velocity = Vector3.zero;

	public float speed;
	public float desiredSpeed;

	// Constant movement variables
	public float acceleration;
	public float turnRate;
	public float maxSpeed;
	public float minSpeed;
	public float yawSpeed;
	public float pitchSpeed;
	public float rollSpeed;

	public GameObject rotateNode;

	// UI Info variables
	public bool gunFlare;
	public float pitchAngle;
	public float rollAngle;
	public float headingAngle;
	public float targetAngle;
	public float altitude;
	public BoxCollider playerBox;
	public BoxCollider AWOLBox;

	private GameObject targetObject;
	private Vector3 targetDist;

	// Weapon variables
	public int gunDamage;
	public float fireRate;
	public float weaponRange;
	
	private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
	private float nextFire;

	// Collision variables
	public bool endGame = false;

	// transitional variables
	float deltaSpeed;
	float deltaPitch;
	float deltaYaw;
	float deltaRoll;
	Vector3 currentRotation = Vector3.zero;

	// Start is called before the first frame update
	void Start()
    {
		playerSound = GetComponent<PlayerSfx>();
		targetObject = GameObject.FindGameObjectWithTag("Finish");	//boss enemies have this tag
    }

    // Update is called once per frame
    void Update()
    {
		// Adjust acceleration
		deltaSpeed = Input.GetAxis("Vertical"); // {-1, 0, 1}
		desiredSpeed += deltaSpeed;
		desiredSpeed = Utils.Clamp(desiredSpeed, minSpeed, maxSpeed);

		// Adjust pitch, yaw, roll
		currentRotation = Vector3.zero;
		deltaPitch = pitchSpeed * Input.GetAxis("Pitch") * Time.deltaTime;
		currentRotation.x -= deltaPitch;
		deltaYaw = yawSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		currentRotation.y += deltaYaw;
		deltaRoll = rollSpeed * Input.GetAxis("Roll") * Time.deltaTime;
		currentRotation.z += deltaRoll;

		rotateNode.transform.Rotate(currentRotation);

		//weapon fire	[credit: https://www.youtube.com/watch?v=AGd16aspnPA]
		if (Input.GetAxis("Fire1") > 0 && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			StartCoroutine(ShotEffect());
			
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponRange)) {
				//Debug.Log(hit.collider.name);	// what did we hit?

				//Damage target
				Shootable targetHealth = hit.collider.GetComponent<Shootable>();
				if (targetHealth != null) {
					targetHealth.Damage(gunDamage);
				}

				// Extra idea: add a splash effect when the water's shot?
			}
			
		}

		//Game Over state: leaving playable area
		if (!playerBox.bounds.Intersects(AWOLBox.bounds))
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverAWOL");		

		// exit application
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		getUIInfo();
	}

	private IEnumerator ShotEffect() {
		playerSound.m_GunSource.Play();

		gunFlare = true;
		yield return shotDuration;
		gunFlare = false;
	}

	public void EndLevel() {
		Debug.Log("End level reached");
		endGame = true;
		StartCoroutine(EndCountdown());
	}

	private IEnumerator EndCountdown() {
		yield return new WaitForSeconds(1.5f);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
	}

	private void getUIInfo() {
		var flatForward = transform.forward;
		flatForward.y = 0;
		if(flatForward.sqrMagnitude > 0) {
			// Grab/convert the pitch angle
			flatForward.Normalize();
			var localFlatForward = transform.InverseTransformDirection(flatForward);
			pitchAngle = Mathf.Atan2(localFlatForward.y, localFlatForward.z);
			// Atan2's result has different negation depending on which quadrant we're facing in
			pitchAngle = Mathf.Abs(pitchAngle * Mathf.Rad2Deg);
			// To correct this, we make pitch angle positive, and only negate it if we're facing down
			if (transform.forward.y < 0)
				pitchAngle *= -1;
			// Grab the heading
			headingAngle = Mathf.Atan2(transform.forward.x, transform.forward.z) * Mathf.Rad2Deg;
			// Grab the roll angle
			var flatRight = Vector3.Cross(Vector3.up, flatForward);
			var localFlatRight = transform.InverseTransformDirection(flatRight);
			rollAngle = Mathf.Atan2(localFlatRight.y, localFlatRight.x) * Mathf.Rad2Deg;
		}
		// Get the angle to the target
		targetDist = (targetObject.transform.position - position).normalized;
		targetAngle = Vector3.SignedAngle(targetDist, transform.forward, Vector3.up);

		altitude = transform.position.y * 5;
	}
}
