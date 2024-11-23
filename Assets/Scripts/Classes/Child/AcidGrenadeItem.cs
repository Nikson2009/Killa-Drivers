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
    [SerializeField] float damage = 1f;
    public override void UseWeapon(Camera playerCamera)
    {
        GameObject weaponResult = Instantiate(grenadeLink, playerCamera.transform.position + playerCamera.transform.forward * spawnDistance, Quaternion.identity);
        weaponResult.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * spawnForce, ForceMode.Force);
    }
}
