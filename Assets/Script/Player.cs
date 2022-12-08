using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rigidBody2D;
	private Vector3 startPosition;
	private Vector3 mousePos;
	private float movementV;
	private float movementH;
	public int distanceshoot;
	public float rapidfire;
	public float addfire;
	
	public LineRenderer lineRenderer;
	public Camera camera;
    void Start()
    {
		lineRenderer = GetComponent<LineRenderer>();
        startPosition = transform.position;
		lineRenderer.SetWidth(0f,0.8f);
		rapidfire=0f;
		camera =Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		rapidfire+=addfire;
		movementV = Input.GetAxis("Vertical");
		movementH = Input.GetAxis("Horizontal");
		mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

		rigidBody2D.velocity = new Vector2(movementH, movementV) * speed;
		Debug.DrawRay(new Vector2(transform.position.x+0.20f,transform.position.y+0.5f),mousePos,Color.red,2f,false);
		lineRenderer.SetPosition(0,new Vector2(transform.position.x+0.20f,transform.position.y+0.25f));
		lineRenderer.SetPosition(1,mousePos);

		if(Input.GetAxis("Fire1") == 1 &&  rapidfire > 1)
		{
			RaycastHit2D hit = Physics2D.Raycast( new Vector2(transform.position.x+1,transform.position.y+1),mousePos,distanceshoot);
			if(hit.collider != null)
			{
				Debug.Log(hit.collider.name);
			}
			rapidfire=0f;
		}
		
    }
}
