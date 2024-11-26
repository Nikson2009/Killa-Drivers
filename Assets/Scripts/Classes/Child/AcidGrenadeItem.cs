using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidGrenadeItem : WeaponItemClass
{
    [Header("Links")]
    [SerializeField] GameObject grenadeLink;

    [Header("Parameters")]
    [SerializeField] float spawnDistance = 1.5f;
    [SerializeField] float spawnForce = 725f;
    [SerializeField] int damage = 1;
    [SerializeField] int damageRandomness = 1;
    public override void UseWeapon(Camera playerCamera)
    {
        GameObject weaponResult = Instantiate(grenadeLink, playerCamera.transform.position + playerCamera.transform.forward * spawnDistance, Quaternion.identity);
        weaponResult.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * spawnForce, ForceMode.Force);
        ExplosionDamage weaponScript = weaponResult.GetComponent<ExplosionDamage>();
        weaponScript.StartExplosion(damage, damageRandomness);
    }
}
