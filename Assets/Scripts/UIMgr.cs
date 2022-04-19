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

	public PlayerMgr player;

	public Text hullText;
	public Image cockpit;
	public Image crosshair;

	// Start is called before the first frame update
	void Start()
    {
		player.position = transform.localPosition;
		player = GetComponentInParent<PlayerMgr>();
	}

    // Update is called once per frame
    void Update()
    {
		hullText.text = player.hull.ToString("F1");
    }
}
