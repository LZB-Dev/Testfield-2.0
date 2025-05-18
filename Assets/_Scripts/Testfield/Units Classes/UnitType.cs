using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitType : MonoBehaviour //bap
{
    [SerializeField] protected string _name;
    [SerializeField] protected Weapon _weapon;
    [SerializeField] protected Core _core;
    [SerializeField] protected Legs _legs;

    public UnitType(string name, Weapon weapon, Core core, Legs legs)
    {
        _name = name;
        _weapon = weapon;
        _core = core;
        _legs = legs;
    }
}
