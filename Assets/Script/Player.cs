using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int vie=100;
	public float speed;

	private float movementV;
	private float movementH;

	private int indexArme=0;

	public Rigidbody2D rigidBody2D;

	private Vector3 startPosition;

	public GameObject scoreManager;

	public List<Arme> listArme=new List<Arme>();

    void Start()
    {
        startPosition = transform.position;
		scoreManager= GameObject.FindGameObjectWithTag("Score");
    }

	void switchArme(float scrollInput)
	{
		if (scrollInput != 0)
		{
			if (scrollInput < -0.04f)
			{
				if (indexArme <= 0)
				{
					indexArme = listArme.Count -1;
					listArme[indexArme].Active();
					listArme[0].Desactive();
				}else
				{
					indexArme -= 1;
					listArme[indexArme].Active();
					listArme[indexArme + 1].Desactive();
				}
			}else if (scrollInput >  0.04f)
			{
				if (indexArme == listArme.Count -1)
				{
					indexArme= 0 ;
					listArme[indexArme].Active();
					listArme[listArme.Count -1].Desactive();
				}else
				{
					indexArme+= 1;
					listArme[indexArme].Active();
					listArme[indexArme - 1].Desactive();
				}
			}
			
		}
	}

    // Update is called once per frame
    void Update()
    {
		movementV = Input.GetAxis("Vertical");
		movementH = Input.GetAxis("Horizontal");
		
		Vector3 mouseposition = Input.mousePosition;
		mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

		Vector2 direction = new Vector2(mouseposition.x - transform.position.x , mouseposition.y - transform.position.y);
		
		transform.up = direction;
		transform.position = new Vector2(transform.position.x+ (movementH* speed),transform.position.y+ (movementV * speed));
		
		float scrollInput = Input.GetAxis("Mouse ScrollWheel");
		switchArme(scrollInput);
    }

	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "Zombie")
		{
			var zombie=col.gameObject.GetComponent<Zombie>();
			zombie.testcollision();
			
			if(zombie.timeattact >5)
			{
				zombie.timeattact=0;
				vie-=15;
				Debug.Log("La vie du joueur est  " + vie);
			}
		}
	}
}
