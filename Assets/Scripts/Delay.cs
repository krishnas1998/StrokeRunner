using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delay : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (delay (15f));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator delay(float delay) {
		yield  return  new WaitForSeconds(delay);
		SceneManager.LoadScene (2);

	}
}
