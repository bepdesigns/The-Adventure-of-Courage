using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAI :Destructable {
	
	public Transform player;
	public float playerDistance;
	public float moveSpeed;
	public float rotationDamping;
	public static bool isPlayerAlive=true;
	public bool dead= false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (Vector3.Distance (player.position, this.transform.position) < 1000) {
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			if (direction.magnitude > 1.8f) {
			
				this.transform.Translate (0, 0, 0.2f);
			}
		}
	}
		
//void LateUpdate () {

	//playeralive ();
	//if (!IsAlive)
		//return;
		



//}
//void playeralive()
	//{
		//if (isPlayerAlive && dead == false) 
		//{

			//playerDistance = Vector3.Distance (player.position, transform.position);
			//if (playerDistance < 3f)
			//{
				//lookAtPlayer ();
				//if (playerDistance < 5f) 
				//{
					//if (playerDistance > 2f)
					//{
					//	chase ();
					//}

				//}
	
			//}
		//}
	//}

	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*rotationDamping);
	}
	void chase()
	{
		transform.Translate (Vector3.forward * moveSpeed* Time.deltaTime);

	}
	
}


