using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu1 : MonoBehaviour {
	public Text highscoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString ();
	}
	public void ToGame()
	{
		SceneManager.LoadScene ("MainMenu");
	}
	public void ToQuit()
	{
		Application.Quit();
	}
}
