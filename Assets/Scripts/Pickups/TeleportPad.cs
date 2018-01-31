using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {
	public int code;
	float disableTimer = 0;

	void Update(){
		if (disableTimer > 0)
			disableTimer -= Time.deltaTime;
	}
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Player"&& disableTimer <= 0) {
			AudioSource source = GetComponent<AudioSource> ();
			source.Play ();
			foreach (TeleportPad tp in FindObjectsOfType<TeleportPad>()) {

				if (tp.code == code && tp != this) {
					Vector3 position = tp.gameObject.transform.position;
					position.y += 1;
					position.z += 1;
					collider.gameObject.transform.position = position;
				}
			}
		}

		if (collider.gameObject.tag == "Dog" && disableTimer <= 0) 
			foreach (TeleportPad tp in FindObjectsOfType<TeleportPad>()) {

				if (tp.code == code && tp != this) {
					Vector3 position = tp.gameObject.transform.position;
					position.y += 1;
					position.z += 1;
					collider.gameObject.transform.position = position;
				}
			}
		}


	}

