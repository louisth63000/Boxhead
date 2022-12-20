using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Arme
{
     public override void fire()
    {
        var bullet = Instantiate(bulletprefab,spawnbullet.position,spawnbullet.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = spawnbullet.up * speedbullet;
        bullet.GetComponent<bulletRocket>().Scoremanager=scoreManager;	
    }
}
