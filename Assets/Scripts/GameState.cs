using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameState : MonoBehaviour {

	[SerializeField] private Text gameStateText;
	[SerializeField] private GameObject player;
	[SerializeField] private BirdMovement birdMovement;
	[SerializeField] private FollowCamera followCamera;
	private float restartDelay = 3.0f;
	private float restartTimer;
	private bool gameStarted = false;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;


	// Use this for initialization
	void Start () {
		Cursor.visible = false;

		playerMovement = player.GetComponent<PlayerMovement>();
		playerHealth = player.GetComponent<PlayerHealth>();

		// Prevent player from moving 
		playerMovement.enabled = false;

		// Prevent the bird from moving.
		birdMovement.enabled = false;

		// Prevent the follow camera from moving to it's game position
		followCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		// If the game is not started and the player pressed the space bar...
		if(!gameStarted && Input.GetKeyUp(KeyCode.Space)) {

			// ... then start the game.
			StartGame();
		}

		// If the player is no longer alive then ...
		if(!playerHealth.alive) {
			// .. end the game...
			EndGame();

			// .. increment timer to count up to starting. 
			restartTimer = restartTimer + Time.deltaTime;
			
			// .. and if it reaches the restartDelay
			if(restartTimer >= restartDelay) {

				// ... reload the currently loaded level
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	private void StartGame() {
		// set game state
		gameStarted = true;

		// removing start text
		gameStateText.color = Color.clear;

		playerMovement.enabled = true;
		birdMovement.enabled = true;
		followCamera.enabled = true;
	}

	private void EndGame() {
		// set game state
		gameStarted = true;

		// Set Game state
		gameStateText.color = Color.white;
		gameStateText.text = "Game Over!";

		// Remove player
		player.SetActive(false);
	}
}
