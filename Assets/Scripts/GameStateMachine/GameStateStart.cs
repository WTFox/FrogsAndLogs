/* Description: 
 * Brogrammer: wtfox
 */

using UnityEngine;

public class GameStateStart : GameStateBase {
	public KeyCode startKey = KeyCode.Space;

	public GameStateStart(GameManager mGm, GameStateMachine mGsm) : base(mGm, mGsm) {
		
	}

	#region Delegates/Events

	#endregion

	#region Properties

	#endregion

	#region MonoBehaviour

	#endregion

	#region Class Methods
	public override void UpdateState() {
		Debug.Log("From playState");
	}

	public override void HandleInput(KeyCode mKey) {
		if (mKey == startKey) {
			ToPlayState();
		}
	}

	public override void ToPlayState() {
		Debug.Log("Starting game...");
		base.ToPlayState();
		gm.StartGame();
	}

	public override void ToPauseState() {
		Debug.Log("Pause key pressed!");
		Time.timeScale = 0.0f;
		gsm.currentState = gsm.pauseState;
	}

	#endregion

}
