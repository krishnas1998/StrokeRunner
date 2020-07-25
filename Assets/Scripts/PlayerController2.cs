using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float upForce = 300f;

	public GameObject fast1;
	public GameObject fast2;
	public GameObject fast3;
	public GameObject fast4;
	public GameObject smoke;
	public beforeTap beforeTapScreen;
	public DeathMenu theDeathScreen;

	public GameObject camera1;

	public GameObject levelSwitcher;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();		
	}


	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce (new Vector2 (0, upForce));
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		BrainStroke ();
	}

	public void BrainStroke() {
		//When the player dies
	}


	public void OnTriggerEnter2D(Collider2D other)
	{
		smoke.SetActive (false);
		camera1.SetActive (true);
		//calling the death menu screen
			beforeTapScreen.gameObject.SetActive (true);

			fast1.SetActive (true);
			fast2.SetActive (true);
			fast3.SetActive (true);
			fast4.SetActive (true);

		levelSwitcher.SetActive (false);
	}

}
