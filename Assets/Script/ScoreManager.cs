using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {
	public int score;
	public int combot=1;
	public int comboMax=50;
	public Image combotImage;
	public float currenttimerCombot;
	public float timerCombot;
	public TMP_Text scoreText;
	public TMP_Text combotText;
	public  int AccessAmount=0;
	private Player player;
	private ZombieManager zombieManager;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		zombieManager = GameObject.FindGameObjectWithTag("ZombieManager").GetComponent<ZombieManager>();
		score=0;
		combot=1;
		UpdateScore();
		UpdateCombot();
	}
	public void addAmmount()
	{
		int indexArme=Random.Range(0,AccessAmount+1);
		int luckspawn=Random.Range(0,20);
		if(luckspawn ==0)
		{
			Debug.Log("Nouvelle Munition "+ player.listArme[indexArme].name);
			player.listArme[indexArme].currentAmmount = (int) (player.listArme[indexArme].Ammountmax/4);
		}
	}
	public void KillZombie()
	{
		score+=1*combot;
		combot++;
		UpdateScore();
		UpdateCombot();
		timerCombot/=1.05f;
		currenttimerCombot=timerCombot;
		addAmmount();
		if(combot>comboMax)
		{
			comboMax=combot;
			comboUp();
		}

	}
	// Update is called once per frame
	void Update () {
		UpdateCombot();
		if(currenttimerCombot >0f)     
        {         
            currenttimerCombot -= Time.deltaTime;     
        }else
		{
			combot=(combot <= 0)?1:combot-1;
			timerCombot*=1.05f;
			currenttimerCombot=timerCombot;

		}     
		combotImage.fillAmount=(float)combot/ (float)comboMax;
	}
	public void UpdateScore()
	{
		scoreText.text="Score: "+score.ToString();
	}
	public void UpdateCombot()
	{
		combotText.text="Combot: "+combot.ToString();
	}
	private void comboUp()
	{
		Arme currentGun;
		switch (comboMax)
		{
			case 2:
				currentGun= player.listArme[0];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				break;
			case 4:
				currentGun= player.listArme[0];
				Debug.Log("L'arme s'appelle df: "+currentGun.Aname);
				currentGun.addfire = 0.007f;
				break;
			case 6:
				currentGun= player.listArme[0];
				Debug.Log("L'arme s'appelle df: "+currentGun.Aname);
				currentGun.speedbullet = 10;
				break;
			case 8:
				Debug.Log("Nouvelle Arme Uzi");
				currentGun= player.listArme[1];
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;

				break;
			case 10:
				Debug.Log("Augmentation de la vitesse  Uzi");
				currentGun= player.listArme[1];
				currentGun.speedbullet+=6;
				break;
			case 12:
				currentGun= player.listArme[0];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				break;
			case 14:
				currentGun= player.listArme[1];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				break;
			case 16:
				currentGun= player.listArme[1];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bullet>().degat *=2;
				break;
			case 20:
				currentGun= player.listArme[2];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;
				break;
			case 24:
				currentGun= player.listArme[2];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				break;
			case 32:
				currentGun= player.listArme[2];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bullet>().degat *=2;
				break;
			case 35:
				currentGun= player.listArme[3];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;
				break;
			case 50:
				currentGun= player.listArme[4];
				Debug.Log("L'arme s'appelle : "+currentGun.Aname);
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;
				break;
			default:
				Debug.Log("Rien");
				break;
		}
	}
}
