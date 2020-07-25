using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tapMenu : MonoBehaviour {

	public float count;
	public DeathMenu theDeathScreen;
	public GameObject thePauseScreen;
	public AudioSource strokeSound;
	public int audioCheck;

	public Image red1;
	public GameObject theRed1;
	public Image red2;
	public GameObject theRed2;
	public Image red3;
	public GameObject theRed3;
	public Image red4;
	public GameObject theRed4;
	public Image red5;
	public GameObject theRed5;

	public float timeLeft;
//	public List<Image> redList;

	// Use this for initialization
	void Start () {
//		redList = new List<Image> ();
		timeLeft=5f;
	}
	
	// Update is called once per frame
	void Update () {
		
			timeLeft -= Time.deltaTime;



		if(count>0)
			count-=0.05f;
		if(audioCheck==1)
			strokeSound.Play ();
		++audioCheck;


		red1.enabled = false;
		red2.enabled = false;
		red3.enabled = false;
		red4.enabled = false;
		red5.enabled = false;


		if (count > 2) {
			red1.enabled = true;
			theRed1.SetActive (true);
			if (count > 4) {
				red2.enabled = true;
				theRed2.SetActive (true);
				if (count > 6) {
					red3.enabled = true;
					theRed3.SetActive (true);
					if (count > 8) {
						red4.enabled = true;
						theRed4.SetActive (true);
						if (count > 10) {
							red5.enabled = true;
							theRed5.SetActive (true);

						}
					}
				}
			}

		}
		if(timeLeft<=0) {
			gameObject.SetActive (false);
			strokeSound.Stop ();
			theDeathScreen.gameObject.SetActive (true);	
		}

		if(count>11)
		{
			Debug.Log (count);
			gameObject.SetActive (false);
			strokeSound.Stop ();
			//thePauseScreen.SetActive (true);	
			SceneManager.LoadScene(3) ;

		//	StartCoroutine (delay (5f));
			//SceneManager.LoadScene("main");
		}



		
	}

	IEnumerator delay(float delay) {
		yield  return  new WaitForSeconds(delay);

	}

	public void tap()

	{	Debug.Log ("tap not work");
		if (count < 11) {
		count += 3;
			//	if (count > 5)
		}
	
	}
}
