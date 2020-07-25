using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	//public PlayerController theEnemy;

	private Vector3 playerStartPoint;
	//private Vector3 enemyStartPoint;
	//array to store the list of the platforms to be destroyed after death
	private platformDestroyer [] platformList;

	//to reset the score after death
	private ScoreManager theScoreManager;

	//for the death menu screen
	public DeathMenu theDeathScreen;

	public tapMenu theTapScreen;

	public beforeTap beforeTapScreen;

	public GameObject fast1;
	public GameObject fast2;
	public GameObject fast3;
	public GameObject fast4;
	public GameObject camera1; 
	public GameObject levelSwitcher;
	// Use this for initialization
	void Start () {
		playerStartPoint = thePlayer.transform.position;
		//enemyStartPoint = theEnemy.transform.position;
		platformStartPoint = platformGenerator.position;
		theScoreManager = FindObjectOfType<ScoreManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void restartGame()
	{
		//StartCoroutine ("restartGameCo");
		theScoreManager.scoreIncreasing = false;
		//to make the character dissapear 
		thePlayer.gameObject.SetActive (false);
		//theEnemy.gameObject.SetActive (false);


		beforeTapScreen.gameObject.SetActive (true);
		//theTapScreen.gameObject.SetActive(true);
		//theDeathScreen.gameObject.SetActive (true);

		///yield return new WaitForSeconds(5);
		 
		 
		levelSwitcher.SetActive (false);

		camera1.SetActive (true);
		fast1.SetActive (true);
		fast2.SetActive (true);
		fast3.SetActive (true);
		fast4.SetActive (true);
	}

	public void reset()
	{
		Debug.Log ("inside reset");
		camera1.SetActive (false);
		theTapScreen.audioCheck = 1;
		theTapScreen.timeLeft=5f;

		theDeathScreen.gameObject.SetActive (false);
		platformList = FindObjectsOfType<platformDestroyer> ();

		for (int i = 0; i < platformList.Length; ++i)
			platformList [i].gameObject.SetActive (false);

		thePlayer.transform.position = playerStartPoint;
		////theEnemy.transform.position = enemyStartPoint;
		platformGenerator.position = platformStartPoint;

		///theEnemy.gameObject.SetActive (true);
		thePlayer.gameObject.SetActive (true);

		//resetting score to zero
		theScoreManager.scoreCount=0;
		theScoreManager.scoreIncreasing = true;

		
	}


}
