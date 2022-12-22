using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	public float vie=0f;
	public int degat=5;
	public GameObject Scoremanager;
	void Awake () 
	{
		Destroy(gameObject,vie);	
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "Zombie")
		{
			Zombie zombie=col.gameObject.GetComponent<Zombie>();
			zombie.vie -=degat;
			if(zombie.vie < 0)
			{
				Destroy(col.gameObject,0f);
				Scoremanager.GetComponent<ScoreManager>().KillZombie();
				
			}
			Destroy(gameObject,0f);
		}
    }
	// Update is called once per frame
}
