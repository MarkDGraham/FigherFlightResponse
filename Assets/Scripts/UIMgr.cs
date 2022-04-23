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
	PlayerMgr player;

	public Text hullText;
	public Image cockpit;
	public Image crosshair;
	public Image muzzleFlare;

	// Start is called before the first frame update
	void Start()
    {
		playerObject = GameObject.Find("PlayerController");
		player = playerObject.GetComponent<PlayerMgr>();
	}

    // Update is called once per frame
    void Update()
    {
		hullText.text = player.health.ToString("F1");
		muzzleFlare.enabled = player.gunFlare;
    }
}
