using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int vie=100;
    public float speed;
    public float range;

    public int timeattact=0;
	public GameObject player;
    // Start is called before the first frame update
    public float timerattactfail=0f;
    void Start()
    {
        
    }

    public void testcollision()
    {
        if(timerattactfail == 0)
        {
            timerattactfail =1f;
            timeattact= 0;
        }
        timeattact+=1;
    }
    // Update is called once per frame
    void Update()
    {
        if(timerattactfail >0f)     
        {         
            timerattactfail -= Time.deltaTime;     
        }     
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed* Time.deltaTime);
    }
}
