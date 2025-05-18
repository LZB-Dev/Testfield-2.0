using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProperty : MonoBehaviour //bap
{
    //Stats; HP - Health Points, SP - Shield Points, EP - Energy Points
    [SerializeField] private float MaxHP = 100;
    [SerializeField] private float MaxSP = 50;
    //[SerializeField] private float MaxEP = 100;
    [SerializeField] float HP;
    [SerializeField] float SP;
    [SerializeField] private float EP;

    /*[SerializeField] private float armor = 5;
    [SerializeField] private float speed = 5;
    [SerializeField] private float dmgModifire = 5;*/

    void Start()
    {
        HP = MaxHP;
        SP = MaxSP;
    }

    void Update()
    {
        if (HP <= 0)
        {
            Debug.Log($"Unit Destroyed");
        }
    }

    void GetDmg(double dmg)
    {
        
    }
}
