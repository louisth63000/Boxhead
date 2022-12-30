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
	public float currenttimerBonusText;

	public float timerCombot;
	public TMP_Text scoreText;
	public TMP_Text combotText;
	public TMP_Text bonusText;
	public  int AccessAmount=0;
	private Player player;
	private ZombieManager zombieManager;

	public AudioSource audioSource;
	public AudioClip nouveauBonus;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		player.listArme[3].bulletprefab.GetComponent<bulletRocket>().scalesize=12;
		player.listArme[1].bulletprefab.GetComponent<bullet>().degat =20;
		player.listArme[2].bulletprefab.GetComponent<bullet>().degat =20;
		player.listArme[4].bulletprefab.GetComponent<Mine>().scalesize=14;

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
			UpdateBonus("Nouvelle Munition "+ player.listArme[indexArme].name);
			player.listArme[indexArme].currentAmmount = (int) (player.listArme[indexArme].Ammountmax/4);
		}
	}
	public void KillZombie(int score_z)
	{
		score+=score_z*combot;
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
		if(currenttimerBonusText >0f)
		{
			currenttimerBonusText -= Time.deltaTime;
		}else
		{
			bonusText.text="";
		}
		if(currenttimerCombot >0f)     
        {         
            currenttimerCombot -= Time.deltaTime;     
        }else
		{
			combot=(combot <= 0)?1:combot-1;
			timerCombot*=1.05f;
			currenttimerCombot=timerCombot;

		}     
		combotImage.fillAmount=(1f-(float)currenttimerCombot)/ 1f;
	}
	public void UpdateScore()
	{
		scoreText.text="Score: "+score.ToString();
	}
	public void UpdateCombot()
	{
		combotText.text="Combot: "+combot.ToString();
	}
	public void UpdateBonus(string textb)
	{
		bonusText.text = textb;
		currenttimerBonusText = 2f;
	}
	private void comboUp()
	{
		Arme currentGun;
		switch (comboMax)
		{
			case 2:
				currentGun= player.listArme[0];
				UpdateBonus("Augmentation du stock de balle pour le  "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 4:
				currentGun= player.listArme[0];
				UpdateBonus("Augmentation de la vistesse de tire pour "+currentGun.Aname);
				Debug.Log("L'arme s'appelle df: "+currentGun.Aname);
				currentGun.addfire = 0.3f;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 6:
				currentGun= player.listArme[0];
				UpdateBonus("Augmentation de la vistesse des balles pour "+currentGun.Aname);
				Debug.Log("L'arme s'appelle df: "+currentGun.Aname);
				currentGun.speedbullet = 10;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 8:
				UpdateBonus("Nouvelle Arme Uzi");
				currentGun= player.listArme[1];
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 10:
				UpdateBonus("Augmentation de la vitesse des balles pour Uzi");
				currentGun= player.listArme[1];
				currentGun.speedbullet+=6;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 12:
				currentGun= player.listArme[0];
				UpdateBonus("Augmentation du stock de balle pour le  "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 14:
				currentGun= player.listArme[1];
				UpdateBonus("Augmentation du stock de balle pour le  "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 16:
				currentGun= player.listArme[1];
				UpdateBonus("Augmentation des dégats de balle pour le  "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bullet>().degat *=2;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 20:
				currentGun= player.listArme[2];
				UpdateBonus("Nouvelle Arme "+currentGun.Aname);
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 24:
				currentGun= player.listArme[2];
				UpdateBonus("Augmentation du stock de balle pour le  "+currentGun.Aname);
				currentGun.Ammountmax *= 2;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 32:
				currentGun= player.listArme[2];
				UpdateBonus("Augmentation des dégats de balle pour le  "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bullet>().degat *=2;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 35:
				currentGun= player.listArme[3];
				UpdateBonus("Nouvelle Arme "+currentGun.Aname);
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 40:
				currentGun= player.listArme[3];
				UpdateBonus("Augmentation de la zone de dégats de balle  "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bulletRocket>().scalesize+=5;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 45:
				currentGun= player.listArme[3];
				UpdateBonus("Augmentation de la zone de dégats de balle  "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bulletRocket>().scalesize+=5;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 50:
				currentGun= player.listArme[4];
				UpdateBonus("Nouvelle Arme "+currentGun.Aname);
				currentGun.currentAmmount=currentGun.Ammountmax;
				AccessAmount+=1;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 55:
				currentGun= player.listArme[3];
				UpdateBonus("Augmentation de la zone de dégats de balle  "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bulletRocket>().scalesize+=5;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 60:
				currentGun= player.listArme[3];
				UpdateBonus("Augmentation de la zone de dégats de balle  "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<bulletRocket>().scalesize+=5;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 65:
				player.regvie=4;
				UpdateBonus("Regeneration de vie plus rapide");
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 70:
				currentGun= player.listArme[4];
				UpdateBonus("Augmentation de la zone de dégats de la "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<Mine>().scalesize+=5;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			case 75:
				currentGun= player.listArme[4];
				UpdateBonus("Augmentation de la zone de dégats de la "+currentGun.Aname);
				currentGun.bulletprefab.GetComponent<Mine>().scalesize+=5;
				audioSource.clip =nouveauBonus;
				audioSource.Play();
				break;
			default:
				Debug.Log("Rien");
				break;
		}
	}
}
