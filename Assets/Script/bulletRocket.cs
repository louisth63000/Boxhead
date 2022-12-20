using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRocket : MonoBehaviour
{
    public float vie=0f;
	public int degat=5;
	public GameObject Scoremanager;
	void Awake () 
	{
		Destroy(gameObject,vie);	
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Untagged" && col.tag != "Player")
        {
            gameObject.transform.localScale = new Vector3(10,10,1);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            Debug.Log(col.tag);
        }
		if (gameObject.transform.localScale.x == 10)
		{
            if (col.tag == "Zombie")
            {
                Zombie zombie=col.gameObject.GetComponent<Zombie>();
                zombie.vie -=degat;
                if(zombie.vie < 0)
                {
                    Destroy(col.gameObject,0.2f);
                    Scoremanager.GetComponent<ScoreManager>().KillZombie();
                }
                Destroy(gameObject,0.2f);
            }else if(col.tag == "Player")
            {
                Player player=col.gameObject.GetComponent<Player>();
                player.vie -=degat;
                Destroy(gameObject,0.2f);
            }
		}
    }
}
