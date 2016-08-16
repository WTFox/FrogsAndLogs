using UnityEngine;
using System.Collections;

public class PickupParticlesDestruction : MonoBehaviour {
	void Start () {
		// Destroy the pickup particles after 5 seconds. 
		Destroy(gameObject, 5.0f);
	}
}
