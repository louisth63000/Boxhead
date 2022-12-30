using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float vie=100f;
	public float speed;
	public float maxVie=100f;
	private float movementV;
	private float movementH;
	public int regvie=1;
	public float regvietime=1f;
	private bool isdead=false;

	private int indexArme=0;

	public Rigidbody2D rigidBody2D;
	public Image HealthBarImage;
	private Vector3 startPosition;
	public Animator animator;

	public GameObject scoreManager;
	public AudioSource audioSource;
	public AudioClip mort;

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
		if (vie< 0)
		{
			animator.SetBool("Dead",true);
			listArme[indexArme].Desactive();
			HealthBarImage.fillAmount= vie/maxVie;
			if(isdead == false)
			{
				audioSource.clip =mort;
				audioSource.Play();
				isdead= true;
			}
			
		}else
		{
			movementV = Input.GetAxis("Vertical");
			movementH = Input.GetAxis("Horizontal");
			bool isstamp=(movementV == 0 && movementH == 0)?true : false;
			animator.SetBool("Stand",isstamp);
			HealthBarImage.fillAmount= vie/maxVie;
			Vector3 mouseposition = Input.mousePosition;
			mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

			Vector2 direction = new Vector2(mouseposition.x - transform.position.x , mouseposition.y - transform.position.y);
			
			transform.up = direction;
			transform.position = new Vector2(transform.position.x+ (movementH* speed),transform.position.y+ (movementV * speed));
			if (regvietime <0f)
			{	
				regvietime=2f;
				vie= (vie >= 100f)?100f:vie+regvie;
			}else
			{
				regvietime -= Time.deltaTime;
			}

			float scrollInput = Input.GetAxis("Mouse ScrollWheel");
			switchArme(scrollInput);
		}
    }

	void  OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "Zombie")
		{
			if(vie > 0)
			{
				animator.Play("HitPlayer");
			}
			var zombie=col.gameObject.GetComponent<Zombie>();
			vie-=zombie.degat;
		}else if(col.tag == "Demon")
		{
			if(vie>0)
			{
				animator.Play("HitPlayer");
			}
			var demon=col.transform.parent.gameObject.GetComponent<Demon>();
			vie-=demon.degat;
		}
	}
}
