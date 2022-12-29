using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDemon : MonoBehaviour
{
    public float vie=2f;
	public int degat=5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,vie);
    }

    // Update is called once per frame
    void Update()
    {
        
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
				
			}
			Destroy(gameObject,0f);
		}
        if (col.tag == "Player")
		{
			Player player=col.gameObject.GetComponent<Player>();
			player.vie -=degat;
			Destroy(gameObject,0f);
		}
    }
}
