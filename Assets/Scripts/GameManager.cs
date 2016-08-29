/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;
using UnityEngine.UI;

/*
 * create a reference to gamestatemanage
 */
public class GameManager : MonoBehaviour {
	[SerializeField] private Text gameStateText;
	[SerializeField] private GameObject player;
	[SerializeField] private BirdMovement birdMovement;
	[SerializeField] private FollowCamera followCamera;
	private float restartDelay = 3.0f;
	private float restartTimer;

	[HideInInspector] public bool gameStarted = false;
	[HideInInspector] public PlayerMovement playerMovement;
	[HideInInspector] public PlayerHealth playerHealth;
	public GameStateMachine gsm;

	#region Delegates/Events
	#endregion

	#region Properties
	public Text GameStateText { get { return gameStateText; } set { gameStateText = value; } }
	#endregion

	#region MonoBehaviour
	public void Start() {
		Cursor.visible = false;
		playerMovement = player.GetComponent<PlayerMovement>();
		playerHealth = player.GetComponent<PlayerHealth>();
		playerMovement.enabled = false;
		birdMovement.enabled = false;
		followCamera.enabled = false;
	}
	#endregion

	#region Class Methods
	public void StartGame() {
		gameStarted = true;
		GameStateText.enabled = false;
		playerMovement.enabled = true;
		birdMovement.enabled = true;
		followCamera.enabled = true;
	}

	public void EndGame() {
		gameStarted = true;
		gameStateText.color = Color.white;
		gameStateText.text = "Game Over!";
		player.SetActive(false);
	}

	#endregion
}
