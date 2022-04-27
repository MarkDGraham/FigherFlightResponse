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

	public Text hullText;
	public Image muzzleFlash;
	public Image victory;

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
		hullText.text = playerEntity.health.ToString("F1");
		muzzleFlash.enabled = player.gunFlare;
		victory.enabled = player.endGame;
    }
}
