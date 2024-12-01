using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooterItem : WeaponItemClass
{
    [Header("Links")]
    [SerializeField] GameObject grenadeLink;

    [Header("Parameters")]
    [SerializeField] float spawnDistance = 1.5f;
    [SerializeField] float spawnForce = 725f;
    [SerializeField] int damage = 1;
    [SerializeField] int damageRandomness = 1;
    public override void UseWeapon(Transform viewTransform, GameObject selfObj)
    {
        GameObject weaponResult = Instantiate(grenadeLink, viewTransform.position + viewTransform.forward * spawnDistance, Quaternion.identity);
        weaponResult.GetComponent<Rigidbody>().AddForce(viewTransform.forward * spawnForce, ForceMode.Force);
        ExplosionDamageOnCollision weaponScript = weaponResult.GetComponent<ExplosionDamageOnCollision>();
        weaponScript.StartExplosion(damage, damageRandomness);
    }
}
