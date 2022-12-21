using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float vie=0f;
	public int degat=5;
	public GameObject Scoremanager;
	public bool collision=false;
    public bool explosion=false;
    public float explosiontime=2f;
	
    
    void OnTriggerStay2D(Collider2D col)
    {
		if (col.tag == "Zombie")
		{
            collision = true ;
		}
        if (explosion == true)
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
            }else if(col.tag == "Player")
            {
                Player player=col.gameObject.GetComponent<Player>();
                player.vie -=degat;
            }
            else if(col.tag == "Mine")
            {
                Debug.Log("TEST");
                col.gameObject.GetComponent<Mine>().explosion = true;
                Destroy(col.gameObject,1f);
            }
		}
        
    }


    // Update is called once per frame
    void Update()
    {
        if (collision == true)
        {
            if(explosiontime >0f)     
            {         
                explosiontime -= Time.deltaTime;     
            }else
            {
                explosion = true;
                Destroy(gameObject,1f);
            }   
        }
    }
}
