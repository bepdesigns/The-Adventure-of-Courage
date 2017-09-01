using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float timeToLive;
	[SerializeField] float damage;


	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeToLive);

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 5f))
		{
			CheckDestructable (hit.transform);
			//Destroy (gameObject);


		}


	}


	void CheckDestructable (Transform other)
	{
		var desctructable = other.GetComponent<Destructable> ();
		if (desctructable == null)
			return;

		desctructable.TakeDamage (damage);

		GameObject prefab = Resources.Load ("PlasmaExplosionEffect")as GameObject;
		GameObject PlasmaExplosionEffect = Instantiate (prefab) as GameObject;
		PlasmaExplosionEffect.transform.position = transform.position;

		Destroy (PlasmaExplosionEffect, 2);
		Destroy (gameObject);
	}
}
