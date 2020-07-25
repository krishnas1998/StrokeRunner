using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerController : MonoBehaviour {

	//for testing 
	//public LayerMask whatIsCatcher;

	public float moveSpeed;
	//for varying speed
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;

	//for avoiding sticking of character from below the platform or from side of the platform
	public Transform groundCheck;
	public float groundCheckRadius;

	public float jumpForce;
	public LayerMask whatIsGround;
	public bool grounded;

	//private Collider2D myCollider;

	private Rigidbody2D myRigidbody;
	private Animator myAnimator; 

	//for the varying jump
	public float jumpTime;
	private float jumpTimeCounter;

	//for restart and death
	public GameManager theGameManager;

	//for resetting to default values after restart
	private float moveSpeedStore;
	private float speedIncreaseMilestoneStore;
	public float speedMilestoneCountStore;

	//for the jump bug fix
	private bool stoppedJumping;

	//for the double jump
	private bool canDoubleJump;

	//for the sound effects
	public AudioSource jumpSound;
	public AudioSource deathSound;

	//public BoxCollider2D collide;
	// Use this for initialization

	public static PlayerController thePlayer;
	public GameObject burger;
	public Transform playerPos;
	private Vector3 enemyStartingPoint;

	void Start () {

		myRigidbody = GetComponent<Rigidbody2D>();
		//myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;

		enemyStartingPoint = thePlayer.transform.position;
		//theBurger=new burgerController();
		//thePlayer = new PlayerController ();
	}

	// Update is called once per frame
	void Update() {
		
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		/*if(Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsCatcher))
			{
					check1 = true;
					theGameManager.restartGame ();
			}*/

		//to vary speed with distance
		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;

			//to move the milestone farther with speed
			speedIncreaseMilestone *= speedMultiplier;

			moveSpeed *= speedMultiplier;
		}


		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		/*if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) { 
			if (grounded)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSound.Play ();
				 
			}
			if(!grounded && canDoubleJump==true)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				//for restting the height of jump
				jumpTimeCounter = jumpTime;
				canDoubleJump = false;
				stoppedJumping = false;
				jumpSound.Play ();

			}
		}

		//for holding space thereby increasing the jump
		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && !stoppedJumping) {
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}	
		if (grounded) {
			jumpTimeCounter = jumpTime;		
			canDoubleJump = true;
		}
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "killBox")
		{
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			theGameManager.restartGame ();
			deathSound.Play ();
		}
	}*/
		
	}
	public void teleport()
	{
		
		burger.SetActive (false);
		burger.transform.position= new Vector3 (playerPos.position.x - 4, playerPos.position.y, playerPos.position.z);
			
		burger.SetActive (true);
	
	}
}
