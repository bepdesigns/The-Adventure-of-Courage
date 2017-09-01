using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {
	public Transform brokentarget;
	public Transform effect;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Bullet") {
			BreakDeath ();
		}
	}

	void BreakDeath()
	{
		Debug.Log ("BreakDeath!");
		Instantiate(brokentarget,transform.position,brokentarget.transform.rotation);
		Destroy (gameObject);
	}

}
