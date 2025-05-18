using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : Unit //bap
{
    [SerializeField] protected float rotationSpeed; //7f;
    [SerializeField] protected UnitType unitType;

    protected Mech(int HP,float rotationSpeed, UnitType unitType) 
        : base(HP)
    {
        this.rotationSpeed = rotationSpeed;
        this.unitType = unitType;
    }

    protected void Move() {}
    protected void Shoot() {}
    protected void Reload() {}
    protected void Melee() {}
}
