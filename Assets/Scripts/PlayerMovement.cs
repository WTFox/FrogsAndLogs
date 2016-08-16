using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] private RandomSoundPlayer playerFootsteps;
	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20.0f;
	private Rigidbody playerRigidbody;
	

	// Use this for initialization
	void Start() {

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
}






