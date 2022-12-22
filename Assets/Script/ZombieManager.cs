using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieManager : MonoBehaviour {

	// Use this for initialization
	public GameObject zombieprefab;

	private GameObject player;
	public float spawnTime;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;
	List<Transform> listSpawn = new List<Transform>();
	public int compteur;
	public int compteurMax;
	GameObject[] listZombie;
	private float sumTime;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		listSpawn.Add(spawn1);
		listSpawn.Add(spawn2);
		listSpawn.Add(spawn3);
		listSpawn.Add(spawn4);
		compteur=0;
		compteurMax=10;

	}
	
	// Update is called once per frame
	void Update () {
		if (sumTime > 1)
		{	
			int spawnRandom=Random.Range(0,4);
			sumTime=0;
			
			if (compteur<compteurMax)
			{
				var zombie = Instantiate(zombieprefab,listSpawn[spawnRandom].position,listSpawn[spawnRandom].rotation);
				zombie.GetComponent<Zombie>().player = player;
				compteur+=1;
			}else{
					listZombie = GameObject.FindGameObjectsWithTag("Zombie");
					if (listZombie.Length==0)
					{
						Debug.Log("Nouvelle manche");
						compteur=0;
						compteurMax= (int) (compteurMax* 1.4f);
					}
			}
		}
		
		 sumTime+=spawnTime;
	}
}
