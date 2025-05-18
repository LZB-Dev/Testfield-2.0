using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour //bap
{
    protected int HP = 0;

    public Unit()
    {
        
    }
    public Unit(int HP)
    {
        this.HP = HP;
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        if(HP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{name} was destroyed");
    }

    private void Start()
    {
    }
}
