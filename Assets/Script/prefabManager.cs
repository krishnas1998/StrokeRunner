using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabManager : MonoBehaviour {

	public GameObject theBurger;

	//public burgerController theBurger;


	// Use this for initialization
	void Start () {
		
	//theBurger=new burgerController();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		theBurger = GameObject.FindGameObjectWithTag("burger");

		//theBurger = GameObject.FindGameObjectWithTag ("burger");
		if (other.gameObject.tag == "Player") {
			burgerController controller = theBurger.GetComponent<burgerController> ();
			controller.teleport ();
			
		} 
	

	}
}
