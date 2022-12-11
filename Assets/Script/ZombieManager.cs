using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {

	// Use this for initialization
	public GameObject zombieprefab;

	private GameObject player;
	public float spawnTime;

	private float sumTime;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (sumTime > 1)
		{
			sumTime=0;
			var zombie = Instantiate(zombieprefab,transform.position,transform.rotation);
			zombie.GetComponent<Zombie>().player = player;
		}
		 sumTime+=spawnTime;
	}
}
