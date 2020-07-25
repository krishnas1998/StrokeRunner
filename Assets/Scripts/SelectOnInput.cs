using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject gameObject;
	private bool buttonSelected;

	// Use this for initialization
	void Start () {
		onDisable ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) {
			eventSystem.SetSelectedGameObject (gameObject);
			buttonSelected = true;
		}
		
	}
	private void onDisable()
	{
		buttonSelected = false;
	}
}
