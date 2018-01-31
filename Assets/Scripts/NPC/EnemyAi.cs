using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : Destructable {


	public Transform player;
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;
	public static bool isPlayerAlive=true;
	private ParticleSystem muzzleFireParticleSystem;
	public Transform muzzle;
	public bool dead= false;
	public float damagerate;

	[SerializeField]SpawnPoint[] spawnPoints;
	public Animator animator;
	private Rigidbody[] bodyParts;
	private MoveController moveController;

	// Use this for initialization
	void Awake(){
		
		
		chase();
		muzzleFireParticleSystem = muzzle.GetComponentInChildren<ParticleSystem> ();
		muzzleFireParticleSystem.Stop ();
	}
	void Start () {
		bodyParts = transform.GetComponentsInChildren<Rigidbody>();
		EnableRagdoll (false);
		moveController = GetComponent<MoveController> ();

	}

	void Update()
	{


	
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
		dead = true;



		GameManager.Instance.Timer.Add (() => {
			EnableRagdoll(false);
			SpawnAtNewSpawnPoint ();
			animator.enabled = true;
			Reset();
			dead=false;
		}, 30);


	}


	
	// Update is called once per frame
	void LateUpdate () {

		playeralive ();
		if (!IsAlive)
			return;


			
	}

	void playeralive()
	{
		if(isPlayerAlive && dead==false)
		{

			playerDistance = Vector3.Distance (player.position, transform.position);

			if (playerDistance < 15f)
			{
				lookAtPlayer ();			}

			if (playerDistance < 12f) {
				if (playerDistance > 6f) 
				{
					chase ();
				} 
				else if (playerDistance < 6f) {
					Debug.Log("attacking");
					attack (); 
				}
			}		
		}
	}

	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*rotationDamping);
	}

	void chase()
	{
		StopFire ();
		transform.Translate (Vector3.forward * moveSpeed* Time.deltaTime);
	}

	void attack ()
	{
		FireEffect ();
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Vector3 rayposition = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);

		if (Physics.Raycast (rayposition, fwd, out hit))
		{
			Debug.DrawLine (rayposition, hit.point);
			if (hit.collider.gameObject.tag == "Player") 
			{
				Debug.Log ("hit the player");
				hit.collider.gameObject.GetComponent<HealthScript>().health -= damagerate*Time.deltaTime;
			}
		}

	}
	void EnableRagdoll(bool value){
		for (int i = 0; i < bodyParts.Length; i++) {
			bodyParts [i].isKinematic = !value;
		}
	}
	void FireEffect()
	{
		if (muzzleFireParticleSystem == null)
			return;
		muzzleFireParticleSystem.Play ();
	}

	void StopFire()
	{
		if (muzzleFireParticleSystem == null)
			return;
		muzzleFireParticleSystem.Stop ();
	}
}
