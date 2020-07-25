using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public  Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond;

	//for scoring according to a jump
	public PlayerController thePlayer;


	//to reset the score after death
	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		//to restore the high score
		if(PlayerPrefs.HasKey("highScore"))
			highScoreCount = PlayerPrefs.GetFloat ("highScore");
		scoreCount = 0;
		scoreIncreasing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if((scoreIncreasing)&&(Input.GetKey(KeyCode.Space)))
		scoreCount += pointsPerSecond * Time.deltaTime;

		if (scoreCount > highScoreCount)
		{
			highScoreCount = scoreCount;
			//to store the high score
			PlayerPrefs.SetFloat ("highScore", highScoreCount);			
		}
		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
	}
	public void addScore(int pointsToAdd)
	{
		scoreCount += pointsToAdd;
	}
}
