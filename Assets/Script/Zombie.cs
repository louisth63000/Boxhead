using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int vie=100;
    public float speed;
    public int degat=5;
	public GameObject player;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isdead=false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {   
        if(!isdead)
        {
            if((player.transform.position.x - transform.position.x) > 0)
            {
                transform.eulerAngles =new Vector3(0,0,transform.eulerAngles.z);
            }else
            {
                transform.eulerAngles =new Vector3(0,180,transform.eulerAngles.z);
            }
              transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed* Time.deltaTime);
        }
       
    }
}
