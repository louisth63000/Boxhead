using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRocket : MonoBehaviour
{
    public float vie=0f;
	public int degat=5;
    public int scalesize=10;
	public GameObject Scoremanager;
    public Sprite explosion;

    public AudioSource audioSource;
	public AudioClip hitsound;

	void Awake () 
	{
		Destroy(gameObject,vie);	
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Untagged" && col.tag != "Player" && col.tag != "Rocket")
        {
            audioSource.clip =hitsound;
            if (gameObject.transform.localScale.x != scalesize)
            {
                audioSource.Play();
            }
            gameObject.transform.localScale = new Vector3(scalesize,scalesize,1);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            gameObject.GetComponent<SpriteRenderer>().sprite =explosion;
            gameObject.GetComponent<SpriteRenderer>().color =new Color(255,255,255,255);
            gameObject.GetComponent<CircleCollider2D>().radius=0.18f;
            
        }
		if (gameObject.transform.localScale.x == scalesize)
		{
            if (col.tag == "Zombie")
            {
                Zombie zombie=col.gameObject.GetComponent<Zombie>();
                if (zombie.isdead == false)
                {
                    zombie.vie -=degat;
                    zombie.animator.Play("Hit");
                    if(zombie.vie < 0 )
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
}
