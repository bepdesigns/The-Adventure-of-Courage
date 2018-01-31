using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour {


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			
			if (col.gameObject.GetComponent<HealthScript> ().health == .99f) {
				col.gameObject.GetComponent<HealthScript> ().health += 0f;
				Destroy (gameObject,0.3f);

			}
			else if (col.gameObject.GetComponent<HealthScript> ().health < 1f) {
				AudioSource source = GetComponent<AudioSource> ();
				source.Play ();
				col.gameObject.GetComponent<HealthScript> ().health = 1f;
				Destroy (gameObject,0.3f);

			}

		}

	}
}
