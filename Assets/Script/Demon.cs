using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public int vie=100;
    public float speed;
    public int degat=5;
    public float range=0.6f;

	public GameObject player;
    public GameObject bulletprefab;

    public float speedbullet;
    public Vector2 direction;

    public float rapidfire;
	public float addfire;

    public bool playerinrange=false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius=range;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerinrange)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed* Time.deltaTime);
        }else
        {   
            rapidfire -= Time.deltaTime;
            if(rapidfire <0f)
            {
                rapidfire=addfire;
                direction = (Vector2)player.transform.position - (Vector2)transform.position;
                var bullet = Instantiate(bulletprefab,gameObject.transform.position,gameObject.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * speedbullet;
            }
        }
    }
    void  OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "Player")
		{
			playerinrange=true;
		}
	}
     void  OnTriggerExit2D(Collider2D col)
    {
		if (col.tag == "Player")
		{
			playerinrange=false;
		}
	}
}
