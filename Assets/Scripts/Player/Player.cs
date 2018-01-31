using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(PlayerState))]

public class Player: MonoBehaviour
{

	[System.Serializable]
	public class MouseInput
	{
		public Vector2 Damping;
		public Vector2 Sensitivity;
		public bool LockMouse;
	}

	[SerializeField]float runSpeed;
	[SerializeField]float walkSpeed;
	[SerializeField]float crouchSpeed;
	[SerializeField]float sprintSpeed;
	[SerializeField]float DashSpeed;
	[SerializeField]MouseInput MouseControl;
	[SerializeField]AudioController footSteps;
	[SerializeField]float  minimumMoveTreshold;
	[SerializeField]
	private Image ThirstBar;
	public float Thirsty;
	Animator anime;

	public PlayerAim playerAim;

	public int points = 0;

	Vector3 previousPosition;

	private CharacterController m_moveController;

	public CharacterController MoveController {
		get {
			if (m_moveController == null)
				m_moveController = GetComponent<CharacterController> ();
			return m_moveController;
		}

	}

	private PlayerShoot m_PlayerShoot;
	public PlayerShoot PlayerShoot {
		get {
			if (m_PlayerShoot == null)
				m_PlayerShoot = GetComponent<PlayerShoot>();
			return m_PlayerShoot;
		}
	}


	private PlayerState m_PlayerState;
	public PlayerState PlayerState 
	{
		get {
			if (m_PlayerState == null)
				m_PlayerState = GetComponent<PlayerState> ();
			return m_PlayerState;
		}
	}
	InputController playerInput;
	Vector2 mouseInput;

	public enum State
	{
		Idle,
		Walk,
		Reload
	}

	State currentState;

	void Awake()
	{
		anime = GetComponentInChildren<Animator> ();

	}



	void Start ()
	{
		playerInput = GameManager.Instance.InputController;
		GameManager.Instance.LocalPlayer = this;

		if (MouseControl.LockMouse) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	void Update ()
	{


		Move ();
		LookAround ();		
		HandleBar ();
		Thirst ();

		switch (this.currentState) {
		case State.Idle:
			this.Idle ();
			break;
		case State.Walk:
			this.Walk ();
			break;
		case State.Reload:
			this.Reload ();
			break;
		}

	}

	void Move ()
	{
		float moveSpeed = runSpeed;
		if (playerInput.IsWalking)
			moveSpeed = walkSpeed;
		if (playerInput.IsSprinting && Thirsty>0f)
			moveSpeed = sprintSpeed;
		if (playerInput.IsCrouched)
			moveSpeed = crouchSpeed;
		if (playerInput.IsDashing)
			moveSpeed = DashSpeed;
		


		Vector2 direction = new Vector2 (playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
		MoveController.Move (transform.forward * direction.x * .02f + transform.right * direction.y * .02f);

		if (Vector3.Distance(transform.position,previousPosition) > minimumMoveTreshold)
			footSteps.Play();

		previousPosition = transform.position;

	}

	void LookAround ()
	{
		mouseInput.x = Mathf.Lerp (mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
		mouseInput.y = Mathf.Lerp (mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);
		transform.Rotate (Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

		playerAim.SetRotation(mouseInput.y * MouseControl.Sensitivity.y);
	}

	void Idle ()
	{
		if (playerInput.Vertical != 0.0f) {
			this.currentState = State.Walk;
			//Debug.Log ("Im Walking!");
			return;
		}
		if (playerInput.Horizontal != 0.0f) {
			this.currentState = State.Walk;
			//Debug.Log ("Im Walking!");
			return;
		}
		if (Input.GetKey (KeyCode.R)) {
			this.currentState = State.Reload;
			//Debug.Log ("Im Reloading!");
			return;
		}
	}

	void Walk ()
	{
		if (playerInput.Vertical == 0.0f && playerInput.Horizontal == 0.0f) {
			this.currentState = State.Idle;
			//Debug.Log ("Im Idling!");
			return;
		}
		if (Input.GetKey (KeyCode.R)) {
			this.currentState = State.Reload;
			//Debug.Log ("Im Reloading!");
			return;
		}

	}

	void Reload()
	{
		if (playerInput.Vertical == 0.0f && playerInput.Horizontal == 0.0f) {
			this.currentState = State.Idle;
			//Debug.Log ("Im Idling!");
			return;
		}
		if (playerInput.Vertical != 0.0f) {
			this.currentState = State.Walk;
			//Debug.Log ("Im Walking!");
			return;
		}
		if (playerInput.Horizontal != 0.0f) {
			this.currentState = State.Walk;
			//Debug.Log ("Im Walking!");
			return;
		}
	}
	private void HandleBar()
	{
		ThirstBar.fillAmount = Thirsty;
	}

	void Thirst ()
	{
		if (playerInput.IsSprinting) {

			Thirsty -= 0.003f;

			if (Thirsty <= 0f) {
				Thirsty = -.05f;
				playerInput.IsSprinting = false;
				anime.SetBool ("IsSprinting", false);
			}
		}
		if (!playerInput.IsSprinting) 
		{
			Thirsty += 0.001f;
			if (Thirsty >= 1f) {
				Thirsty = 1f;
			}
		}
			
		if (playerInput.IsWalking) {
			Thirsty += 0.002f;
			if (Thirsty >= 1f) {
				Thirsty = 1f;
			}
		}
			if (playerInput.IsCrouched) {
				Thirsty += 0.004f;
				if (Thirsty >= 1f) {
					Thirsty = 1f;
				}
			}
			//Debug.Log (Thirsty);
		}
	private void OnGUI()
	{
		GUI.Label (new Rect (110, 0, 200, 40), "Coins : " + points);
	}
	}