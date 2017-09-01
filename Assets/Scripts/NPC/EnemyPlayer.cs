using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PathFinder))]
//[RequireComponent(typeof(Scanner))]
public class EnemyPlayer : MonoBehaviour {
	PathFinder pathFinder;
	//Scanner scanner;


	void Start()
	{
		pathFinder = GetComponent<PathFinder> ();
		//scanner = GetComponent<Scanner> ();
		//scanner.OntargetSelected += Scanner_OntargetSelected;
	}

	private void Scanner_OntargetSelected (Vector3 position)
	{
		pathFinder.SetTarget (position);
	}


}
