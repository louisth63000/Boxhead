using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieManager : MonoBehaviour {

	// Use this for initialization
	public GameObject zombieprefab;
	public GameObject demonprefab;

	private GameObject player;
	private ScoreManager scoreManager; 
	public float spawnTime;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;

	List<Transform> listSpawn = new List<Transform>();
	public int compteur;
	public int compteurMax;
	GameObject[] listZombie;

	public float sumTime;
	public int manche=1;

	void Start () {
		zombieprefab.GetComponent<Zombie>().speed=2f;
		zombieprefab.GetComponent<Zombie>().degat=5;
		demonprefab.GetComponent<Demon>().speed=1.2f;
		demonprefab.GetComponent<CircleCollider2D>().radius=2.4f;

		player = GameObject.FindGameObjectWithTag("Player");
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		listSpawn.Add(spawn1);
		listSpawn.Add(spawn2);
		listSpawn.Add(spawn3);
		listSpawn.Add(spawn4);
		compteur=0;
		compteurMax=10;

	}
	
	// Update is called once per frame
	void Update () {
		if (sumTime <0f)
		{	
			int spawnRandom=Random.Range(0,4);
			sumTime=spawnTime;
			
			if (compteur<compteurMax)
			{
				var zombie = Instantiate(zombieprefab,listSpawn[spawnRandom].position,listSpawn[spawnRandom].rotation);
				zombie.GetComponent<Zombie>().player = player;
				compteur+=1;
				int spawndemon=Random.Range(0,25);
				if(spawndemon == 0)
				{
					var demon = Instantiate(demonprefab,listSpawn[spawnRandom].position,listSpawn[spawnRandom].rotation);
					demon.GetComponent<Demon>().player = player;
				}
			}else{
					listZombie = GameObject.FindGameObjectsWithTag("Zombie");
					if (listZombie.Length==0)
					{
						scoreManager.UpdateBonus("Nouvelle manche");
						manche++;
						zombieUp();
						compteur=0;
						compteurMax= (int) (compteurMax* 1.4f);
					}
			}
		}else
		{
			sumTime -= Time.deltaTime;
		}

	}
	void zombieUp()
	{
		switch(manche)
		{
			case 5:
				scoreManager.UpdateBonus("Les zombies apparaisses plus vite");
				spawnTime=0.3f;
				break;
			case 10:
				scoreManager.UpdateBonus("Les zombies vont plus vite");
				zombieprefab.GetComponent<Zombie>().speed*=1.2f;
				break;
			case 12:
				scoreManager.UpdateBonus("Les zombies font deux fois plus mal");
				zombieprefab.GetComponent<Zombie>().degat+=5;
				break;
			case 14:
				scoreManager.UpdateBonus("Les Demons ont plus de portés");
				demonprefab.GetComponent<CircleCollider2D>().radius=3f;
				break;
			case 15:
				scoreManager.UpdateBonus("Les zombies vont plus vite");
				zombieprefab.GetComponent<Zombie>().speed*=1.2f;
				break;
			case 18:
				scoreManager.UpdateBonus("Les Demons sont plus rapide");
				demonprefab.GetComponent<Demon>().speed=1.6f;
				break;
			case 20:
				scoreManager.UpdateBonus("Les zombies apparaisses plus vite");
				spawnTime=0.2f;
				break;
		}
	}
}
