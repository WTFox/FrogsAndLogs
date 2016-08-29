/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;

public interface IGameState {

	#region Delegates/Events

	#endregion

	#region Properties

	#endregion

	#region MonoBehaviour

	#endregion

	#region Class Methods
	void UpdateState();
	void ToPlayState();
	void ToPauseState();
	void ToStartState();
	void ToStateMenuState();
	void ToEndCreditsState();
	void HandleInput(KeyCode key);
	#endregion
}
