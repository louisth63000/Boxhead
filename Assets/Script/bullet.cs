using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	public float vie=0f;
	public int degat=5;
	public GameObject Scoremanager;
	
	public AudioSource audioSource;
	public AudioClip hitsound;
	void Awake () 
	{
		Destroy(gameObject,vie);	
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "Zombie")
		{
			audioSource.clip =hitsound;
			audioSource.Play();
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
			Destroy(gameObject,0f);
		}else if (col.tag == "Demon")
		{
			audioSource.clip =hitsound;
			audioSource.Play();
			Demon demon=col.gameObject.transform.parent.GetComponent<Demon>();
			if(demon.isdead == false)
			{
				demon.vie -=degat;
				demon.animator.Play("Hit");
				if(demon.vie < 0 )
				{
					demon.animator.SetBool("Dead",true);
					demon.isdead =true;
					Destroy(col.gameObject.transform.parent.gameObject,2f);
					Scoremanager.GetComponent<ScoreManager>().KillZombie(15);
					
				}
			}
			Destroy(gameObject,0f);
		}
    }
	// Update is called once per frame
}
