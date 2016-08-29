/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStateMachine : MonoBehaviour {
	// public GameObject pauseMenuOverlay;
	[HideInInspector] public GameStateBase currentState;
	[HideInInspector] public GameStateBase fromState;
	[HideInInspector] public GameStateStart startState;
	[HideInInspector] public GameStatePlay playState;
	[HideInInspector] public GameStatePause pauseState;
	public GameManager gm;


	#region Delegates/Events

	#endregion

	#region Properties

	#endregion

	#region MonoBehaviour
	public void Awake() {
		startState = new GameStateStart(gm, this);
		playState = new GameStatePlay(gm, this);
		pauseState = new GameStatePause(gm, this);
	}

	public void Start() {
		currentState = startState;
	}

	public void Update() {
		currentState.UpdateState();
	}

	#endregion

	#region Class Methods

	#endregion
}
