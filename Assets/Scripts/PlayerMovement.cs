using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] private RandomSoundPlayer playerFootsteps;

	[SerializeField] private GameObject pickupPrefab;

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20.0f;
	private Rigidbody playerRigidbody;

	public FlyEventHandlers flyHandlers;


	// Use this for initialization
	void Start() {
		flyHandlers.OnFlyCaught += HandleCaughtFly;

		// Gather components from the Player GameObject
		playerAnimator = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {

		// Gather Input from the keyboard
		moveHorizontal = Input.GetAxisRaw("Horizontal");
		moveVertical = Input.GetAxisRaw("Vertical");

		movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
	}

	void FixedUpdate() {

		// If the players movement vector does not equal 0...
		if (movement != Vector3.zero) {
			// ... then create a target rotation based on the movement vector
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

			// ... and create another rotation that moves from the current rotation to the target rotation
			Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);

			// ... and change the players rotation to the new incremental rotation
			playerRigidbody.MoveRotation(newRotation);

			// ...then play the jump animation..
			playerAnimator.SetFloat("Speed", 3.0f);

			// .. play footstep sounds.
			playerFootsteps.enabled = true;

		} else {
			// .. otherwise don't. 
			playerAnimator.SetFloat("Speed", 0.0f);
			// .. dont play footstep sounds.
			playerFootsteps.enabled = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Fly") {
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

		other.gameObject.SetActive(false);
	}

}






