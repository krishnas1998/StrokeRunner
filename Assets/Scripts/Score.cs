using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private float score = 0.0f;
	public static int min = 0;
	public  static float sec = 30;
	public static float totalTime = 0.0f;
	public Text scoreText;
	public static int difficultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int scoreToNextLevel = 10;
	private bool isDead = false;
	public DeathMenu1 menu;
	// Use this for initialization
	void Start () {
		score = 0.0f;
		min = 0;
		sec = 30;
		totalTime = 0.0f;
		difficultyLevel = 1;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		if (score > scoreToNextLevel) {
			LevelUp ();
		}
		if (sec > 0)
			sec -= Time.deltaTime;
		else {
			if (min == 0) {
				
			} else {
				sec = 60;
				min -= 1;
					
			}
			}
		score += Time.deltaTime * difficultyLevel;
		scoreText.text ="Time : "+ ((int)min).ToString () + " : " +((int)sec).ToString();
	}
	void LevelUp(){
		if (difficultyLevel == maxDifficultyLevel)
			return;
		scoreToNextLevel *= 2;
		difficultyLevel++;
		GetComponent<PlayerController1> ().SetSpeed (difficultyLevel);
	}
	public void OnDeath(){
		isDead = true;
		if(PlayerPrefs.GetFloat("Highscore") < score)
			PlayerPrefs.SetFloat ("Highscore", score);
		menu.ToggleEndMenu (score);
	}

	public int getMin(){
		return min;
	}

	public float getSec(){
		return sec;
	}

	public int getDifficultyLevel()
	{
		return difficultyLevel;
	}
}
