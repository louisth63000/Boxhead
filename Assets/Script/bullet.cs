using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	public float vie=0f;
	public int degat=5;
	void Awake () 
	{
		Destroy(gameObject,vie);	
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision avec  " + col.tag);
		if (col.tag == "Zombie")
		{
			Zombie zombie=col.gameObject.GetComponent<Zombie>();
			zombie.vie -=5;
			Debug.Log("Vie Zombie:"+zombie.vie);
			if(zombie.vie < 0)
			{
				Destroy(col.gameObject,0.2f);
			}
		}
    }
	// Update is called once per frame
}
