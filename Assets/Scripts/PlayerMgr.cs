using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
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

	// Weapon variables
	public int gunDamage;
	public float fireRate;
	public float weaponRange;
	public bool gunFlare;
	public bool endGame = false;
	
	private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
	private AudioSource gunAudio;
	private float nextFire;

	// transitional variables
	float deltaSpeed;
	float deltaPitch;
	float deltaYaw;
	float deltaRoll;
	Vector3 currentRotation = Vector3.zero;

	// Start is called before the first frame update
	void Start()
    {
		gunAudio = GetComponent<AudioSource>();
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

			//Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * weaponRange
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponRange)) {
				Debug.Log(hit.collider.name);	// what did we hit?

				//Damage target
				Shootable targetHealth = hit.collider.GetComponent<Shootable>();
				if (targetHealth != null) {
					targetHealth.Damage(gunDamage);
				}

				// Extra idea: add a splash effect when the water's shot?
			}
			
		}

		// exit application
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	private IEnumerator ShotEffect() {
		gunAudio.Play();

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
}
