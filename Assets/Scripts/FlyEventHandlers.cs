/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;

public class FlyEventHandlers : MonoBehaviour {

	#region Delegates/Events
	public delegate void OnFlyCaughtHandler(Collider fly);
	public event OnFlyCaughtHandler OnFlyCaught;

	#endregion

	#region Properties
	#endregion

	#region MonoBehaviour
	#endregion

	#region Class Methods
	public void ProcessCaughtFly(Collider fly) {
		if (OnFlyCaught != null) {
			OnFlyCaught(fly);
		}
	}
    #endregion

}
