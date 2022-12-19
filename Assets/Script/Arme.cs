using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arme : MonoBehaviour
{
    public int currentAmmount;
    public int Ammountmax;
    public float rapidfire;
	public float addfire;
    public float speedbullet;
    public string name;
    public Transform spawnbullet;
    public GameObject bulletprefab;
	public GameObject scoreManager;

    public void Active()
    {
        gameObject.SetActive(true);
    }
    public void Desactive()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        scoreManager= GameObject.FindGameObjectWithTag("Score");
    }

    public virtual void fire()
    {

    }
    // Update is called once per frame
    void Update()
    {
        rapidfire+=addfire;
        if(Input.GetAxis("Fire1") == 1 &&  rapidfire > 1)
		{
			rapidfire=0;
			fire();
		}
    }
}
