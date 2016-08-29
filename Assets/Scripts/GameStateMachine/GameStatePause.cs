/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;

public class GameStatePause : GameStateBase {
	public KeyCode pauseMenuKey = KeyCode.Escape;
	public KeyCode spaceKey = KeyCode.Space;

	public GameStatePause(GameManager mGm, GameStateMachine mGsm) : base(mGm, mGsm) {

	}

	#region Delegates/Events

	#endregion

	#region Properties

	#endregion

	#region MonoBehaviour

	#endregion

	#region Class Methods
	public override void UpdateState() {
		Debug.Log("From Pause state");
	}
	
	public override void HandleInput(KeyCode mKey) {
		if (mKey == pauseMenuKey || mKey == spaceKey) {
			ToPlayState();
		}
	}

	public override void ToPlayState() {
		Time.timeScale = 1.0f;
		gsm.currentState = gsm.playState;
		gm.GameStateText.enabled = false;
	}
	#endregion

}
