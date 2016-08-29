/* Description: 
 * Brogrammer: wtfox
 */
 
using UnityEngine;
using System.Collections.Generic;

public class FlyPool : MonoBehaviour {
	private const int DEFAULT_BUFFER_SIZE = 12;

	public GameObject poolObject;
	public int bufferSize;
	public Transform container;

	private List<GameObject> pool;
	[SerializeField] private int poolSize;

    #region Delegates/Events

    #endregion

    #region Properties

    #endregion

    #region MonoBehaviour
	void Awake() {
		pool = new List<GameObject>();
		IncreasePoolBuffer(bufferSize);
	}

    #endregion

    #region Class Methods
	public GameObject GetPoolObject() {
		GameObject firstInactivePoolObject = null;
		foreach(GameObject go in pool) {
			if(!go.activeSelf) {
				firstInactivePoolObject = go;
			}
		}

		if(firstInactivePoolObject == null) {
			firstInactivePoolObject = AddToPool();
			IncreasePoolBuffer(bufferSize);
		}

		firstInactivePoolObject.SetActive(true);
		return firstInactivePoolObject;
	}

	private GameObject AddToPool() {
		GameObject newGameObject = (GameObject)Instantiate(poolObject);
		newGameObject.transform.SetParent(container);
		newGameObject.SetActive(false);
		pool.Add(newGameObject);
		return newGameObject;
	}

	private void IncreasePoolBuffer(int mBufferAmt) {
		for(int i=0; i<mBufferAmt; i++) {
			AddToPool();
		}
	}

	public int GetPoolSize() {
		return pool.Count;
	}

    #endregion
}
