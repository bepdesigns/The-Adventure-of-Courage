using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

	public float health ;
	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (health < 0f)
		{

			EnemyAi.isPlayerAlive = false;
			player= null;
		}
		//Debug.Log (health);
	}
}