using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour {

	public float rangeMin;
	public float rangeMax;
	private float switchingTime;
	private float counter; 
	public GameObject platformer;
	public GameObject smoke;
	 
	private static int flag = -1;

	// Use this for initialization
	void Start () {
		counter = 0f;
		seed ();
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > switchingTime)
		{
			if(flag==-1)
			{
				smoke.SetActive (true);
				platformer.SetActive (false);
				seed ();
				flag = 1;
			}	
			else if(flag==1)
			{
				smoke.SetActive (false);
				platformer.SetActive (true);
				seed ();
				flag = -1;
			}
		}
		
	}

	public void seed()
	{
		counter = 0f;
		switchingTime=Random.Range(rangeMin,rangeMax);
	}

	IEnumerator delay() {
		Debug.Log ("delay working");
		yield return new WaitForSeconds (5);
	}
}
