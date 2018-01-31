using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour {
	public Transform target;
	public Transform mytransform;
	public float movespeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
		transform.Translate (Vector3.forward * movespeed * Time.deltaTime);
	}
}
