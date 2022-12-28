using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int vie=100;
    public float speed;
    public int degat=5;
	public GameObject player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {   
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed* Time.deltaTime);
    }
}
