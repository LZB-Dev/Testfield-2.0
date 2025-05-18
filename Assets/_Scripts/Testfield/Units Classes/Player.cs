using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mech //bap
{
    //State Variables
    [SerializeField] protected bool isBoosting = false;

    //Speed Variables
    //[SerializeField] protected float speed; //800f
    //[SerializeField] [Range(5f, 50f)] protected float speedLimit; //7f
    [SerializeField] [Range(0.1f, 3f)] protected float limitX; //2f
    //[SerializeField] protected float rotationSpeed; //7f

    //Properties
    //[SerializeField] HP;
    //[SerializeField] protected int EP; //Energy Points
    [SerializeField] protected int Speed;

    //Type
    //[SerializeField] protected UnitType unitType = 0;


    public Player(int HP, float rotationSpeed, UnitType unitType) 
        : base(HP, rotationSpeed, unitType)
    {

    }

    protected void Dash(){}
    protected void BoostEnabled(){}
    protected void BoostDisabled(){}

    private void Start()
    {

    }
}
