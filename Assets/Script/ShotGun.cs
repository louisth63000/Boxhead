using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Arme
{
    public int cptbullet;
     public override void fire()
    {
        for (int i = 0; i < cptbullet; i++)
        {
            var bullet = Instantiate(bulletprefab,spawnbullet.position,spawnbullet.rotation);
            float test=(spawnbullet.up.x < 0 )? Random.Range(-1.3f,0f) : Random.Range(0f,1.3f);
            float test2=(spawnbullet.up.y < 0 )? Random.Range(-1.3f,0f) : Random.Range(0f,1.3f);
            bullet.GetComponent<Rigidbody2D>().velocity = (new Vector3(spawnbullet.up.x+test,spawnbullet.up.y+ test2,1)) * speedbullet;
            bullet.GetComponent<bullet>().Scoremanager=scoreManager;
        }
    }
}
