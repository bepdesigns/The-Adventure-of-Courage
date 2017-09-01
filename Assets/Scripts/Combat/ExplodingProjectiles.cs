using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision collision){

		GameObject prefab = Resources.Load ("Explosion")as GameObject;
		GameObject Explosion = Instantiate (prefab) as GameObject;
		Explosion.transform.position = transform.position;

		Destroy (Explosion, 5);
		Destroy (gameObject);
	}
}
