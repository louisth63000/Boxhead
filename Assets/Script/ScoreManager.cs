using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public int score;
	public int combot;
	public float timerCombot;
	// Use this for initialization
	void Start () {
		score=0;
		combot=1;
	}
	public void KillZombie()
	{
		score+=1*combot;
		

		Debug.Log("Score : "+score);
	}
	// Update is called once per frame
	void Update () {
		if(timerCombot >0f)     
        {         
            timerCombot -= Time.deltaTime;     
        }else
		{
			combot-=1;


		}     
       
	}
}
