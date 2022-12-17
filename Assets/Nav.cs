using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour {

	// Use this for initialization
	NavMeshAgent agent;
	public Transform goal;
	void Start () {
		agent= GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void Update () {
		// test
	}
}
