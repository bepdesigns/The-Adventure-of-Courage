using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_TEST : Destructable {

	[SerializeField]SpawnPoint[] spawnPoints;
	public Animator animator;
	private Rigidbody[] bodyParts;
	private MoveController moveController;


	// Use this for initialization
	void Start () {
		bodyParts = transform.GetComponentsInChildren<Rigidbody>();
		EnableRagdoll (false);
		moveController = GetComponent<MoveController> ();
	}

	void SpawnAtNewSpawnPoint() {
		int spawnIndex= Random.Range(0,spawnPoints.Length);
		transform.position = spawnPoints [spawnIndex].transform.position;
		transform.rotation = spawnPoints [spawnIndex].transform.rotation;
	}
	public override void Die()
	{
		base.Die ();
		EnableRagdoll(true);
		animator.enabled = false;

		GameManager.Instance.Timer.Add (() => {
			EnableRagdoll(false);
			SpawnAtNewSpawnPoint ();
			animator.enabled = true;
			Reset();
		}, 2);
			

	}

	// Update is called once per frame
	void Update () {
		if (!IsAlive)
			return;
		
		animator.SetFloat ("Vertical", 1);
		moveController.Move (new Vector2 (4, 0));
	}

	void EnableRagdoll(bool value){
		for (int i = 0; i < bodyParts.Length; i++) {
			bodyParts [i].isKinematic = !value;
		}
	}
}
