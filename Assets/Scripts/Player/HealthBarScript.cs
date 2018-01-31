using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
	[SerializeField]
	private Image HealthBar;
	private float hithealth;
	private Vector3 spawn;
	public Collider gameobj;

	// Use this for initialization
	void Start () {
		spawn = new Vector3 (0, 1, 0);
			
		}

	// Update is called once per frame
	void Update () {
		HandleBar ();

		hithealth = gameObject.GetComponent<HealthScript> ().health;


		if (hithealth < 0f)
		{
			Vector3 spawn = gameObject.transform.position;
			//spawn.y += 1;
			//spawn.z += 1;
			gameobj.gameObject.transform.position = spawn;
			EnemyAi.isPlayerAlive = false;
			Destroy (gameObject);
		}
		//Debug.Log (hithealth);
	}
	private void HandleBar()
	{
		HealthBar.fillAmount = hithealth;
	}
}
