using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour {
	private Text scoreCounterText;

	public static int score;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreCounterText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreCounterText.text = score + " Flies";
	}
}
