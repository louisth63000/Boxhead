using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

	public AudioSource audioSource;
	public AudioClip nouvellemanche;

	public TMP_Text Manchetxt;

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
		Manchetxt.text="Manche : "+manche;
	}
	public void Restart()
	{
		zombieprefab.GetComponent<Zombie>().speed=2f;
		zombieprefab.GetComponent<Zombie>().degat=5;
		demonprefab.GetComponent<Demon>().speed=1.2f;
		demonprefab.GetComponent<CircleCollider2D>().radius=2.4f;
		spawnTime = 0.4f;
		GameObject[] zombies=GameObject.FindGameObjectsWithTag("Zombie");
		GameObject[] demons=GameObject.FindGameObjectsWithTag("Demon");

		GameObject[] mines=GameObject.FindGameObjectsWithTag("Mine");
		GameObject[] rockets=GameObject.FindGameObjectsWithTag("Rocket");

		for (int i = 0; i < zombies.Length; i++)
		{
			Destroy(zombies[i],0f);
		}
		for (int i = 0; i < mines.Length; i++)
		{
			Destroy(mines[i],0f);
		}
		for (int i = 0; i < rockets.Length; i++)
		{
			Destroy(rockets[i],0f);
		}
		for (int i = 0; i < demons.Length; i++)
		{
			Destroy(demons[i].transform.parent.gameObject,0f);
		}
		compteur=0;
		compteurMax=10;
		manche=1;
		Manchetxt.text="Manche : "+manche;
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
				int spawndemon=Random.Range(0,35);
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
						audioSource.clip =nouvellemanche;
						audioSource.Play();
						manche++;
						Manchetxt.text="Manche : "+manche;
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
