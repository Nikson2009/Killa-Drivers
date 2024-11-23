using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunItem : WeaponItemClass
{
    [Header("Parameters")]
    [SerializeField] float maxDistanceToHit = 500f;
    public override void UseWeapon(Camera playerCamera)
    {
        Debug.Log("I use lazer gun!");
    }
}
