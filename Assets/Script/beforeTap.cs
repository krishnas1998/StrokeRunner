using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beforeTap : MonoBehaviour {

	public tapMenu theTapScreen;


	public GameObject fast1;
	public GameObject fast2;
	public GameObject fast3;
	public GameObject fast4;


	public float checkTime;
	// Use this for initialization
	void Start () {
		checkTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		checkTime += Time.deltaTime;
		if (checkTime > 5)
		{
			gameObject.SetActive (false);

			fast1.SetActive (false);
			fast2.SetActive (false);
			fast3.SetActive (false);
			fast4.SetActive (false);
			theTapScreen.timeLeft = 5f;
			 
			theTapScreen.gameObject.SetActive (true);			

		}
				
	}
}
