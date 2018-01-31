using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	public int CoinValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0,Time.deltaTime * 90,0));
	}
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {			
			AudioSource source = GetComponent<AudioSource> ();
			source.Play ();
			col.GetComponent<Player> ().points+=CoinValue;
			Destroy (gameObject,0.3f);
		}
	}
}
