using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableComponent : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player.GetComponent<Player> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
