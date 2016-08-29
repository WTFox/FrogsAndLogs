/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatePlay : GameStateBase {
	public KeyCode pauseMenuKey = KeyCode.Escape;

	private float restartDelay = 3.0f;
	private float restartTimer;
	private bool gameStarted = false;

	public GameStatePlay(GameManager mGm, GameStateMachine mGsm) : base(mGm, mGsm) {

	}

	#region Delegates/Events

	#endregion

	#region Properties

	#endregion

	#region MonoBehaviour

	#endregion

	#region Class Methods
	public override void UpdateState() {
		if(!gameStarted && Input.GetKeyUp(KeyCode.Space)) {
			gm.StartGame();
		}

		if(!gm.playerHealth.alive) {
			gm.EndGame();
			restartTimer = restartTimer + Time.deltaTime;
			if(restartTimer >= restartDelay) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public override void HandleInput(KeyCode mKey) {
		if (mKey == pauseMenuKey) {
			ToPauseState();
		}
	}

	public override void ToPauseState() {
		Time.timeScale = 0.0f;
		gsm.currentState = gsm.pauseState;
		gm.GameStateText.enabled = true;
	}

	#endregion

}
