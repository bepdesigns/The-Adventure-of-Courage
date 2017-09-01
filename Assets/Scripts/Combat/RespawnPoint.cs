using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {
	
	public Transform Lucas;
	public int playerLives = 2;
	public GameObject player;

	void Start ()
	{
		//Instantiate (Lucas, gameObject.transform.position, Quaternion.identity);
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update ()
	{

		if (player == null && playerLives >= 1) {
			playerLives--;
			Instantiate (Lucas, gameObject.transform.position, Quaternion.identity);
			player = GameObject.FindGameObjectWithTag ("Player");

		}
	}
}