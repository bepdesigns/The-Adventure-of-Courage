using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

	private Vector3 moveVector;
	private Vector3 lastMove;
	private float speed = 2;
	private float jumpforce = 10;
	private float gravity = 25;
	private float verticalVelocity;

	private CharacterController controller;
	private Animator anime;

	public bool isGrounded = false;
	public bool canDoubleJump = false;


	// Use this for initialization
	void Start () {

		controller = GetComponent<CharacterController> ();	
		anime = GetComponentInChildren<Animator> ();
		IsGrounded ();
		
	}
	void IsGrounded ()
	{
		isGrounded = (Physics.Raycast (transform.position, -transform.up, controller.height / 1f)); 
	}

	
	// Update is called once per frame
	void Update () {
		IsGrounded ();
		moveVector = Vector3.zero;
		moveVector = transform.TransformDirection (moveVector);


		if (Input.GetKeyDown (KeyCode.E) && !controller.isGrounded && canDoubleJump)
		{
			verticalVelocity = jumpforce;
			canDoubleJump = false;
			//anime.Play ("DoubleJump");
		}

		if (controller.isGrounded) {

			verticalVelocity = -1;

			if (Input.GetButton ("Jump") ) 
			{
				canDoubleJump = true;
				isGrounded = false;
				verticalVelocity = jumpforce;
				//anime.Play ("Frontflip");

			}
				
		}
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
			moveVector = lastMove;
		}


		moveVector.y = 0;
		moveVector.Normalize ();
		moveVector *= speed;
		moveVector.y = verticalVelocity;

		controller.Move (moveVector * Time.deltaTime);
		lastMove = moveVector;
	}

	private void OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (!controller.isGrounded && hit.normal.y < 0.1f) {

			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.DrawRay (hit.point, hit.normal, Color.cyan, 1.0f);
				anime.Play ("WallJump", -1);
				verticalVelocity = jumpforce;
				moveVector = hit.normal * speed;
			}
		}
	}


}
