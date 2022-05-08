using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
	public static PlayerSfx inst;
	private void Awake()
	{
		inst = this;
	}

	public class AdvancedSettings // A class for storing the advanced options.
	{
		public float engineMinDistance = 50f;                   // The min distance of the engine audio source.
		public float engineMaxDistance = 1000f;                 // The max distance of the engine audio source.
		public float engineDopplerLevel = 1f;                   // The doppler level of the engine audio source.
		[Range(0f, 1f)] public float engineMasterVolume = 0.5f; // An overall control of the engine sound volume.
		public float windMinDistance = 10f;                     // The min distance of the wind audio source.
		public float windMaxDistance = 100f;                    // The max distance of the wind audio source.
		public float windDopplerLevel = 1f;                     // The doppler level of the wind audio source.
		[Range(0f, 1f)] public float windMasterVolume = 0.5f;   // An overall control of the wind sound volume.
	}

	public AudioClip m_EngineSound;                     // Looped engine sound, whose pitch and volume are affected by the plane's throttle setting.
	public float m_EngineMinThrottlePitch = 0.4f;       // Pitch of the engine sound when at minimum throttle.
	public float m_EngineMaxThrottlePitch = 2f;         // Pitch of the engine sound when at maximum throttle.
	public float m_EngineFwdSpeedMultiplier = 0.002f;   // Additional multiplier for an increase in pitch of the engine from the plane's speed.
	public AudioClip m_WindSound;                       // Looped wind sound, whose pitch and volume are affected by the plane's velocity.
	public float m_WindBasePitch = 0.2f;                // starting pitch for wind (when plane is at zero speed)
	public float m_WindSpeedPitchFactor = 0.004f;       // Relative increase in pitch of the wind from the plane's speed.
	public float m_WindMaxSpeedVolume = 100;            // the speed the aircraft much reach before the wind sound reaches maximum volume.
	public AdvancedSettings m_AdvancedSetttings = new AdvancedSettings();// container to make advanced settings appear as rollout in inspector
	public AudioClip m_GunSound;
	public float m_GunVolume = 0.25f;

	private AudioSource m_EngineSource;
	private AudioSource m_WindSource;
	public AudioSource m_GunSource;
	private PlayerMgr m_Player;


	// Start is called before the first frame update
	void Start()
    {
		// get player manager reference
		m_Player = GetComponent<PlayerMgr>();

		// Add the audiosources and get the references.
		m_EngineSource = gameObject.AddComponent<AudioSource>();
		m_EngineSource.playOnAwake = false;
		m_WindSource = gameObject.AddComponent<AudioSource>();
		m_WindSource.playOnAwake = false;
		m_GunSource = gameObject.AddComponent<AudioSource>();
		m_GunSource.playOnAwake = false;

		// Assign audio clips
		m_EngineSource.clip = m_EngineSound;
		m_WindSource.clip = m_WindSound;
		m_GunSource.clip = m_GunSound;

		// Set audio source parameters
		m_EngineSource.minDistance = m_AdvancedSetttings.engineMinDistance;
		m_EngineSource.maxDistance = m_AdvancedSetttings.engineMaxDistance;
		m_EngineSource.loop = true;
		m_EngineSource.dopplerLevel = m_AdvancedSetttings.engineDopplerLevel;

		m_WindSource.minDistance = m_AdvancedSetttings.windMinDistance;
		m_WindSource.maxDistance = m_AdvancedSetttings.windMaxDistance;
		m_WindSource.loop = true;
		m_WindSource.dopplerLevel = m_AdvancedSetttings.windDopplerLevel;

		m_GunSource.volume = m_GunVolume;

		// Call once to set audio options
		Update();
		
		// start playing sounds
		m_EngineSource.Play();
		m_WindSource.Play();
	}

    // Update is called once per frame
    void Update()
    {
		// Get proportion of speed
		var enginePower = Mathf.InverseLerp(0, m_Player.maxSpeed, m_Player.speed);
		
		//scale engine pitch and volume with engine power
		m_EngineSource.pitch = Mathf.Lerp(m_EngineMinThrottlePitch, m_EngineMaxThrottlePitch, enginePower);
		m_EngineSource.pitch += m_Player.speed * m_EngineFwdSpeedMultiplier;
		m_EngineSource.volume = Mathf.InverseLerp(0, m_Player.maxSpeed * m_AdvancedSetttings.engineMasterVolume, m_Player.speed);

		// scale wind pitch and volume with plane's speed
		m_WindSource.pitch = m_WindBasePitch + m_Player.speed * m_WindSpeedPitchFactor;
		m_WindSource.volume = Mathf.InverseLerp(0, m_WindMaxSpeedVolume, m_WindMaxSpeedVolume) * m_AdvancedSetttings.windMasterVolume;
    }
}
