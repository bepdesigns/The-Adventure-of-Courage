using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour {


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {

			if (col.gameObject.GetComponent<HealthScript> ().health == .99f) {
				col.gameObject.GetComponent<HealthScript> ().health += 0f;
				Destroy (gameObject);

			}
			else if (col.gameObject.GetComponent<HealthScript> ().health < 1f) {
				col.gameObject.GetComponent<HealthScript> ().health = 1f;
				Destroy (gameObject);

			}

		}

	}
}
