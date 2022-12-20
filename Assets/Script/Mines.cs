using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : Arme
{
    public override void fire()
    {
        var mine = Instantiate(bulletprefab,spawnbullet.position,spawnbullet.rotation);
        mine.GetComponent<Mine>().Scoremanager=scoreManager;	
    }
}
