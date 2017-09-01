using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
	[SerializeField]
	private Image HealthBar;
	private float hithealth;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		HandleBar ();

		hithealth = gameObject.GetComponent<HealthScript> ().health;


		if (hithealth < 0f)
		{

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
