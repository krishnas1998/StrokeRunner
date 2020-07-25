using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveTitle : MonoBehaviour {
	public Image titleImage;
	// Use this for initialization
	void Start () {
		//titleImage.enabled = false;
		
	}

	public void TitleCheck(bool check)
	{
		titleImage.enabled = check;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
