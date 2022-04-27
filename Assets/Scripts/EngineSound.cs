using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
	public PlayerMgr player;
	private AudioSource engineAudio;
	// Start is called before the first frame update
	void Start()
    {
		player = GetComponentInParent<PlayerMgr>();
		engineAudio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		engineAudio.pitch = player.speed / player.maxSpeed;
    }
}
