using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : Destructable {

	public float health ;
	public GameObject player;

	[SerializeField] SpawnPoint[]spawnPoints;

	void SpawnAtnewSpawnpoint(){
		int spawnIndex = Random.Range (0, spawnPoints.Length - 1);
		transform.position = spawnPoints [spawnIndex].transform.position;
		transform.rotation = spawnPoints [spawnIndex].transform.rotation;
	}
	public override void Die()
	{
		base.Die();
		SpawnAtnewSpawnpoint ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (health < 0f)
		{

			//EnemyAi.isPlayerAlive = false;
			//player= null;

			//Die ();
			//FindObjectOfType<SceneMan> ().EndGame ();
		}
		//Debug.Log (health);
	}
}