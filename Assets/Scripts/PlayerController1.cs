using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class Boundary : System.Object
{
	public float xmin, xmax;
}

public class PlayerController1 : MonoBehaviour {
	private CharacterController controller;
    private BoxCollider boxcollider;
	public float speed;
	private float verticalSpeed = 0.0f ;
	private Vector3 moveVector;
	private float gravity = 12.0f;
	private float animationDuration = 3.0f;
	private bool isDead = false;
	private float startTime;
	public tapMenu TapMenu;
	private float transition;
	public Text HospitalText;
	// Use this for initialization
	void Start () {
		HospitalText.enabled = true;
		controller = GetComponent<CharacterController> ();
        boxcollider = GetComponent<BoxCollider>();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Boundary b = new Boundary ();
		b.xmin = -8.0f;
		b.xmax = 8.0f;
		if (isDead)
			return;
		if (Time.time - startTime < animationDuration) {
			HospitalText.text = "AMBULANCE ARRIVED... LETS'S GET TO THE HOSPITAL";
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}
		HospitalText.enabled = false;
		moveVector = Vector3.zero;
        /*if (controller.isGrounded) {
			verticalSpeed = -0.5f;
		} else {
			verticalSpeed -= gravity;
		}*/

		moveVector.x = Input.GetAxisRaw("Horizontal")*5;
		if (Input.GetMouseButton (0)) {
			if (Input.mousePosition.x > Screen.width / 2)
				moveVector.x = 5;
			else
				moveVector.x = -5;
		}
		moveVector.y = verticalSpeed;


		if (TileManager1.tmpsec >= 45) {
			HospitalText.text = "YOU SURVIVE!!!";
			HospitalText.enabled = true;
			Score.sec = 0;
			return;
		} else if (((int)Score.sec)==0) {
			HospitalText.text = "YOU DIE..!!";
			HospitalText.enabled = true;

			Death ();
			return;
		}
		moveVector.z = speed;
		//transform.Translate(moveVector*Time.deltaTime);
		Vector3 newPosition = transform.position + moveVector;
		//Debug.Log (newPosition.x);

		if (newPosition.x >= b.xmin && newPosition.x <= b.xmax) {
			//controller.Move (moveVector*Time.deltaTime);
			transform.Translate(moveVector*Time.deltaTime);
		} else
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
	
		//mo = Mathf.Clamp (moveVector.x + transform.position.x, b.xmin, b.xmax);

       /*
		//transform.position = new Vector3 (Mathf.Clamp (moveVector.x, -3.0f, +3.0f), 0, 0);
         


		//Vector3 currentPosition = transform.position;
		Debug.Log(transform.position.x);
		moveVector.x = Mathf.Clamp( transform.position.x + moveVector.x, b.xmin , b.xmax);
		//if( Mathf.Approximately(clampedX,b.xmin)||Mathf.Approximately(clampedX,b.xmax))
		//moveVector.x = 0; 
		//transform.position = moveVector; 

	
		controller.Move (moveVector * Time.deltaTime);
		
		*/
	}
	public void SetSpeed(float modifier){
		speed = 5 + modifier;
	}
   /* void OnControllerColliderHit(ControllerColliderHit Hit){
		if (Hit.point.z > transform.position.z + controller.radius)
			Death ();
	}*/
   void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("abc");
		if (collider.gameObject.tag == "PowerUp") {
			Destroy (collider.gameObject);
			Score.sec += 5.0f;
		} else {
			HospitalText.text = "YOU DIE..!!";
			HospitalText.enabled = true;
			Death ();
		}
    }

	/*void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "PowerUp") {
			Destroy (col.gameObject);
			Score.sec += 5.0f;
		}
		else
			Death();
	}*/


    void Death()
	{
		isDead = true;
		GetComponent<Score> ().OnDeath ();
	}
}
