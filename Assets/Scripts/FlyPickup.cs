using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {
	[SerializeField] private GameObject pickupPrefab;
	public FlyEventHandlers flyHandlers;

	void Start() {
		flyHandlers = GameObject.FindObjectOfType<FlyEventHandlers>();
		flyHandlers.OnFlyCaught += HandleCaughtFly;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			flyHandlers.ProcessCaughtFly(other);
		}
	}


	private void HandleCaughtFly(Collider other) {
		Debug.Log("HandleCaughtFly..");
		/* the next line runs once per each fly in the scene (12 times)
		 * which deactivates every fly on the scene 
		 * then activates every fly again in a different position.
		 */

		Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		FlySpawner.totalFlies--;

		this.gameObject.SetActive(false);
	}
}
