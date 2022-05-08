using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
	public static UIMgr inst;
	private void Awake()
	{
		inst = this;
	}

	GameObject playerObject;
	Entity381 playerEntity;
	PlayerMgr player;
	public BoxCollider RegionBox;

	public Text hullText;       //display hull amount
	public Text speedText;
	public Text pitchText;
	public Text altitudeText;
	public Image muzzleFlash;   //muzzle flash
	public Image compass;
	public Image target;
	public Image attitude;
	public Image victory;       // victory popup
	public Image warning;

	float playerSpeed;
	string pitchAngleText;

	// Start is called before the first frame update
	void Start()
    {
		playerObject = GameObject.Find("Player");
		player = playerObject.GetComponent<PlayerMgr>();
		playerEntity = playerObject.GetComponent<Entity381>();
	}

    // Update is called once per frame
    void Update()
    {
		// update text fields: Hull, Speed, Pitch, Altitude
		hullText.text = playerEntity.health.ToString("F0");
		playerSpeed = player.speed * 5 * 1.944f;				//conversion to 1/5th scale, and conversion from meters per second to knots
		speedText.text = playerSpeed.ToString("F0") + " kts";
		pitchText.text = player.pitchAngle.ToString("F0");
		altitudeText.text = player.altitude.ToString("F0");

		//Update images: Muzzle flash, Compass, Target, Attitude, Victory
		muzzleFlash.enabled = player.gunFlare;
		warning.enabled = !player.playerBox.bounds.Intersects(RegionBox.bounds);
		compass.transform.rotation = Quaternion.Euler(0, 0, player.headingAngle);
		target.transform.rotation = Quaternion.Euler(0, 0, player.targetAngle);
		attitude.transform.rotation = Quaternion.Euler(0, 0, player.rollAngle);
		victory.enabled = player.endGame;

    }
}
