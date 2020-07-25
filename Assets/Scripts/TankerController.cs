using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerController : MonoBehaviour {
	private Vector3 pos1;
	private Vector3 pos2;
	public float speed = 0.5f;
	void Start () {
		//tanker = GetComponent<Rigidbody> ();
		//startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//moveVector.position.x -= speedX;
		pos1 = new Vector3(-3.5f,transform.position.y,transform.position.z);
		pos2 = new Vector3(3.5f,transform.position.y,transform.position.z);
		transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time * 0.3f, 1.0f));

	}
}
