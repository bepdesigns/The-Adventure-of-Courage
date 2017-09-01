using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	Player player;
	Animator animator;
	private PlayerAim m_PlayerAim;
	private PlayerAim PlayerAim
	{
		get
		{
			if (m_PlayerAim == null)
				m_PlayerAim = GameManager.Instance.LocalPlayer.playerAim;
			return m_PlayerAim;
		}

	}


	// Use this for initialization
	void Awake () {
		animator = GetComponentInChildren<Animator> ();
		player = GetComponent<Player> ();

	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("Vertical", GameManager.Instance.InputController.Vertical);
		animator.SetFloat ("Horizontal", GameManager.Instance.InputController.Horizontal);

		animator.SetBool ("IsWalking", GameManager.Instance.InputController.IsWalking);
		if (player.Thirsty > 0f) {
			animator.SetBool ("IsSprinting", GameManager.Instance.InputController.IsSprinting);
		}
		animator.SetBool ("IsCrouched", GameManager.Instance.InputController.IsCrouched);

		animator.SetFloat ("AimAngle", PlayerAim.GetAngle());
		animator.SetBool ("IsAiming",
		GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EweaponState.AIMING ||
		GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EweaponState.AIMEDFIRING);

	}
}
