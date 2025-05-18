using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour //bap
{
    [SerializeField] protected int dmg;
    [SerializeField] protected int overalAmmo;
    [SerializeField] protected int magCapacity;
    [SerializeField] protected int magAmmo;
    [SerializeField] protected float range;
    [SerializeField] protected float rateOfFire;

    [SerializeField] BulletController bullet;
    [SerializeField] GameObject gunPoint;

    void Shoot()
    {
        if(magAmmo > 0)
        {
            //logic of bullet trajectory + possibly spread
            bullet.dmg = dmg;
            bullet.range = range;
        }
    }

    void Reload()
    {
        if (overalAmmo >= magCapacity - magAmmo)
        {
            overalAmmo -= magCapacity - magAmmo;
            magAmmo = magCapacity;
        }
        else if (overalAmmo < magCapacity - magAmmo && overalAmmo != 0)
        {
            magAmmo += overalAmmo;
            overalAmmo = 0;
        }
        else
        {
            Debug.Log("Not enough ammo");
        }
    }
}
