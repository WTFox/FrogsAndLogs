/* Description:
 * Brogrammer: wtfox
 */

using System;
using System.Collections;
using UnityEngine;

public class GameStateBase : IGameState {

	public GameManager gm;
	public GameStateMachine gsm;

	public GameStateBase(GameManager mGm, GameStateMachine mGsm) {
		this.gm = mGm;
		this.gsm = mGsm;
	}

	public virtual void HandleInput(KeyCode key) {

	}

	public virtual void ToEndCreditsState() {

	}
	
	public virtual void ToPauseState() {
		ChangeState(gsm.pauseState);
	}

	public virtual void ToPlayState() {
		ChangeState(gsm.playState);
	}

	public virtual void ToStartState() {
		ChangeState(gsm.startState);
	}

	public virtual void ToStateMenuState() {

	}

	public virtual void UpdateState() {

	}

	public void ChangeState(GameStateBase toState) {
		// handles transistion to next state and reference previous state
		gsm.fromState = gsm.currentState;
		gsm.currentState = toState;
	}
}