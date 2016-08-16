using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {
	[SerializeField] private Transform target;
	[SerializeField] private RandomSoundPlayer birdFootsteps;
	private NavMeshAgent birdAgent;
	private Animator birdAnimator;
	
	// Use this for initialization
	void Start () {
		birdAgent = GetComponent<NavMeshAgent>();
		birdAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Set the birds destination
		birdAgent.SetDestination(target.position);

		// Measure the magnitude of the NavMeshAgents velocity
		float speed = birdAgent.velocity.magnitude;

		// pass the velocity to birdAnimator
		birdAnimator.SetFloat("Speed", speed);

		if (speed > 0 ) {
			birdFootsteps.enabled = true;
		} else {
			birdFootsteps.enabled = false;
		}
	}
}
