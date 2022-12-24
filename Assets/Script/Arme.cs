using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Arme : MonoBehaviour
{
    public int currentAmmount;
    public int Ammountmax;
    public TMP_Text ammoText;
    public float rapidfire;
	public float addfire;
    public float speedbullet;
    public string Aname;
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
        if(Input.GetAxis("Fire1") == 1 &&  rapidfire > 1 && currentAmmount > 0)
		{
            currentAmmount -=1;
            UpdateAmmo();
			rapidfire=0;
			fire();

		}
        else if(currentAmmount==0)
        {
            currentAmmount=Ammountmax;
        }

    }
    public void UpdateAmmo()
	{
		ammoText.text=currentAmmount.ToString()+" / "+Ammountmax.ToString();
	}
}
