using UnityEngine;

public class Player : MonoBehaviour
{
	public int vie=100;
	public float speed;
	public Rigidbody2D rigidBody2D;
	private Vector3 startPosition;
	private float movementV;
	private float movementH;
	public float rapidfire;
	public float addfire;
	
	public Transform spawnbullet;

	public GameObject bulletprefab;

	public float speedbullet;

    void Start()
    {
        startPosition = transform.position;
		rapidfire=0f;
    }

    // Update is called once per frame
    void Update()
    {
		rapidfire+=addfire;
		movementV = Input.GetAxis("Vertical");
		movementH = Input.GetAxis("Horizontal");
		
		Vector3 mouseposition = Input.mousePosition;
		mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

		Vector2 direction = new Vector2(mouseposition.x - transform.position.x , mouseposition.y - transform.position.y);
		
		transform.up = direction;
		transform.position = new Vector2(transform.position.x+ (movementH* speed),transform.position.y+ (movementV * speed));
		
		if(Input.GetAxis("Fire1") == 1 &&  rapidfire > 1)
		{
			rapidfire=0;
			var bullet = Instantiate(bulletprefab,spawnbullet.position,spawnbullet.rotation);
			bullet.GetComponent<Rigidbody2D>().velocity = spawnbullet.up * speedbullet;
		}
		
    }
	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "Zombie")
		{
			var zombie=col.gameObject.GetComponent<Zombie>();
			zombie.testcollision();
			
			if(zombie.timeattact >10)
			{
				zombie.timeattact=0;
				vie-=15;
				Debug.Log("La vie du joueur est  " + vie);
			}
		}
	}
}
