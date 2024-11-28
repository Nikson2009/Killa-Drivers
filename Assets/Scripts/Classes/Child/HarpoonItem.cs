using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonItem : WeaponItemClass
{
    [Header("Links")]
    [SerializeField] GameObject harpoonLink;

    [Header("Parameters")]
    [SerializeField] float maxDistanceToHit = 500f;
    [SerializeField] float spawnDistance = 1.5f;
    [SerializeField] float spawnForce = 725f;
    [SerializeField] int damage = 5;
    [SerializeField] int damageRandomness = 2;
    public override void UseWeapon(Transform viewTransform, GameObject selfObj)
    {

        Vector3 rayOrigin = viewTransform.position;
        Vector3 rayDirection = viewTransform.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistanceToHit))
        {
            GameObject weaponResult = Instantiate(harpoonLink, viewTransform.position + viewTransform.forward * spawnDistance, Quaternion.identity);
            weaponResult.GetComponent<Rigidbody>().AddForce(viewTransform.forward * spawnForce, ForceMode.Force);
            weaponResult.transform.rotation = viewTransform.rotation * Quaternion.Euler(0, 180f, 0);

            CollisionDamage weaponScript = weaponResult.GetComponent<CollisionDamage>();
            weaponScript.SetParameters(damage, damageRandomness, selfObj);
        }
    }
}
