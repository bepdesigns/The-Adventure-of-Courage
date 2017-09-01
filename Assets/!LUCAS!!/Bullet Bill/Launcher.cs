using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
	
	public GameObject rocketPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) {
			GameObject rocket = Instantiate(rocketPrefab, this.transform.position, this.transform.rotation); // rotation?
		}
	}
}
