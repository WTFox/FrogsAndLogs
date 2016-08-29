/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;

public class InputManager : MonoBehaviour {
	public GameManager gameManager;

	public KeyCode pauseMenu = KeyCode.Escape;
	public KeyCode startGame = KeyCode.Space;

	#region Delegates/Events

	#endregion

	#region Properties

	#endregion

	#region MonoBehaviour
	public void Update() {
		GetInput();
	}

	#endregion

	#region Class Methods
	public void GetInput() {
		if (Input.GetKeyDown(pauseMenu)) {
			gameManager.gsm.currentState.HandleInput(pauseMenu);

		} else if (Input.GetKeyDown(startGame)) {
			gameManager.gsm.currentState.HandleInput(startGame);
		}
	}
	#endregion

}
