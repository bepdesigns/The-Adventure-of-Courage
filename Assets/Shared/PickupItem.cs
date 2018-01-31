using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider collider) {

		if (collider.tag != "Player")
			return;

		PickUp(collider.transform);
	}

	public virtual void OnPickup(Transform item){
	
		//nothing for now
	}


	void PickUp (Transform item) {

		OnPickup (item);
		AudioSource source = GetComponent<AudioSource> ();
		source.Play ();

	}
}
