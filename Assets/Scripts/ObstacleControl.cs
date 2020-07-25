using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {
	public GameObject smokeBomb;
	public GameObject player;
	public float appliedForceX = 500f;
	public float appliedForceY = 200f;

	// Use this for initialization
	void Start () {
		work ();
	}

	// Update is called once per frame
	void Update () {
	}

	private void work() {
		StartCoroutine (createObstacle (3f));
	}


	private IEnumerator createObstacle(float time) {
		yield return new WaitForSeconds(time);

		CircleCollider2D collider = smokeBomb.GetComponent<CircleCollider2D> ();
		collider.sharedMaterial.bounciness = Random.Range(0.5f, 1f);

		Vector3 position = new Vector3(player.transform.position.x-5, player.transform.position.y+5, 0f);
		GameObject smokeBombClone = Instantiate (smokeBomb, position, transform.rotation);
		smokeBombClone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (appliedForceX, appliedForceY));	
		work ();
	}

}
