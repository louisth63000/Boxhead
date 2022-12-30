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
	public float range=2.4f;
    public int scalesize=14;
    
    void OnTriggerStay2D(Collider2D col)
    {
		if (col.tag == "Zombie" || col.tag == "Demon")
		{
            collision = true ;
            
		}
        if (explosion == true)
		{
            if (col.tag == "Zombie")
            {
                Zombie zombie=col.gameObject.GetComponent<Zombie>();
               if (zombie.isdead == false)
                {
                    zombie.vie -=degat;
                    zombie.animator.Play("Hit");
                    if(zombie.vie < 0)
                    {
                        zombie.animator.SetBool("Dead",true);
                        zombie.isdead =true;		
                        Destroy(col.gameObject,2f);
                        Scoremanager.GetComponent<ScoreManager>().KillZombie(1);
                        
                    }
                }
            }else if(col.tag == "Player")
            {
                Player player=col.gameObject.GetComponent<Player>();
                player.vie -=degat;
                player.animator.Play("HitPlayer");
            }
            else if(col.tag == "Mine")
            {
               
                col.gameObject.GetComponent<Mine>().explosion = true;
                
            }else if (col.tag == "Demon")
            {
                
                Demon demon=col.gameObject.transform.parent.GetComponent<Demon>();
               if(demon.isdead == false)
                {
                    demon.vie -=degat;
                    demon.animator.Play("Hit");
                    if(demon.vie < 0)
                    {
                        demon.animator.SetBool("Dead",true);
                        demon.isdead =true;
                        Destroy(col.gameObject.transform.parent.gameObject,2f);
                        Scoremanager.GetComponent<ScoreManager>().KillZombie(15);
                        
                    }
                }
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
                gameObject.transform.localScale = new Vector3(scalesize,scalesize,1);
                gameObject.GetComponent<CircleCollider2D>().radius=range/scalesize;
                Destroy(gameObject,1f);
            }   
        }
    }
}
