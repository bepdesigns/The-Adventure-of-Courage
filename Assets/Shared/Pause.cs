using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject pausePanel;
	public Animator anime;
	public MoveController controller;
	public Player player;
	public PlayerShoot shoot;
	public EnemyAi enemy;
	public bool isPaused;

	public void Start()
	{
		isPaused = false;
	}

	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseGame (true);
		} 
		else {
			PauseGame (false);
		}
		if (Input.GetButtonDown ("Cancel")) {
			SwitchPause (); 
		}
	


	}

	void PauseGame (bool state){
		if (state) {
			pausePanel.SetActive (true);
			enemy.enabled = false;
			//anime.enabled = false;
			//controller.enabled = false;
			//player.enabled = false;
			//shoot.enabled = false;
			Time.timeScale = 0.0f; //Paused
		} else {
			Time.timeScale = 1.0f; //Unpaused
			pausePanel.SetActive (false);
			enemy.enabled = true;
			//anime.enabled = true;
			//controller.enabled = true;
			//player.enabled = true;
			//shoot.enabled = true;
		}
	}

	public void SwitchPause () { 
		if (isPaused){
			isPaused = false;
		}
		else {
			isPaused = true;
		}
	}
		
}
