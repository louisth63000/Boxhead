using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public int score;
	public int combot;
	public float currenttimerCombot;
	public float timerCombot;
	// Use this for initialization
	void Start () {
		score=0;
		combot=1;
	}
	public void KillZombie()
	{
		score+=1*combot;
		combot++;
		timerCombot/=1.025f;

		currenttimerCombot=timerCombot;

	}
	// Update is called once per frame
	void Update () {
		if(currenttimerCombot >0f)     
        {         
            currenttimerCombot -= Time.deltaTime;     
        }else
		{
			combot=(combot <= 0)?1:combot-1;
			timerCombot*=1.025f;
			currenttimerCombot=timerCombot;

		}     
       
	}
}
