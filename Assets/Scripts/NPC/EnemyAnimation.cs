using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFinder))]
public class EnemyAnimation : MonoBehaviour {

	[SerializeField]
	Animator animator;
	Vector3 lastPostion;
	PathFinder pathFinder;

	void Awake()
	{
		pathFinder = GetComponent<PathFinder> ();

	}

	void Update()
	{
		float velocity = ((transform.position - lastPostion).magnitude) / Time.deltaTime;
		lastPostion = transform.position;
		animator.SetFloat ("Vertical", velocity);
	}


}
