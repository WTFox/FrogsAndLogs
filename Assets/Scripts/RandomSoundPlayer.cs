using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour {
	[SerializeField] private List<AudioClip> soundClips = new List<AudioClip>();
	[SerializeField] private float soundTimerDelay = 3.0f;
	private float soundTimer;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// increment a timer to count up to restarting.
		soundTimer = soundTimer + Time.deltaTime;

		// if the timer reaches the delay...
		if (soundTimer >= soundTimerDelay) {

			// ...reset the timer
			soundTimer = 0.0f;

			// ...choose a random sound...
			AudioClip randomSound = soundClips[Random.Range(0, soundClips.Count - 1)];

			// ..then play the sound.
			audioSource.PlayOneShot(randomSound);

		}
	}
}
