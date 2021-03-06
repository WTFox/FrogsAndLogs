﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] private GameObject pickupPrefab;

	public bool alive;

	// Use this for initialization
	void Start () {
		alive = true;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Enemy") && alive) {
			alive = false;

			// Create the pickup particles
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		}
	}
}
