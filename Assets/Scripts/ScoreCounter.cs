using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreCounter : MonoBehaviour {
	private Text scoreCounterText;

	public FlyEventHandlers flyHandlers;
	public static int score;

	// Use this for initialization
	void Start() {
		score = 0;
		scoreCounterText = GetComponent<Text>();

		// flyHandlers = GameObject.FindObjectOfType<FlyEventHandlers>();
		flyHandlers.OnFlyCaught += UpdateScoreText;
	}
	
	// Update is called once per frame
	void Update () {
		// scoreCounterText.text = score + " Flies";
	}

	void UpdateScoreText(Collider other) {
		Debug.Log("UpdateScoreText called too");
		score++;
		scoreCounterText.text = score + " Flies";
	}
}
