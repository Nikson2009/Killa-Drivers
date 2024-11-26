using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunItem : WeaponItemClass
{
    [Header("Links")]
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject floatingTextLink;
    [SerializeField] GameObject shootVfxLink;

    [Header("Parameters")]
    [SerializeField] float maxDistanceToHit = 500f;
    [SerializeField] int maxDamagedEnemies = 4;
    [SerializeField] int damage = 5;
    [SerializeField] int damageRandomness = 2;
    public override void UseWeapon(Camera playerCamera)
    {

        Vector3 rayOrigin = playerCamera.transform.position;
        Vector3 rayDirection = playerCamera.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistanceToHit))
        {
            GameObject shootVfx = Instantiate(shootVfxLink, playerCamera.transform.position + new Vector3(0, -2, 0), Quaternion.identity);
            shootVfx.transform.LookAt(hit.point);

            GameObject newObjectChecker = Instantiate(objectCheckerLink, hit.collider.gameObject.transform.position, Quaternion.identity);
            CheckObjectsInRadiusWithVFX objectCheckerScript = newObjectChecker.GetComponent<CheckObjectsInRadiusWithVFX>();
            List<GameObject> enemiesToDamage = objectCheckerScript.getObjectsInRadius(maxDamagedEnemies, 0, hit.collider.gameObject);
            enemiesToDamage.Add(hit.collider.gameObject);

            foreach (GameObject enemy in enemiesToDamage)
            {
                if (enemy.tag == "Enemy" || enemy.tag == "Player")
                {
                    int damageResult = damage + Random.RandomRange(-damageRandomness, damageRandomness);

                    Entity entityScript = enemy.GetComponent<Entity>();

                    entityScript.ApplyDamage(damageResult);
                }
            }
        } else
        {
            GameObject shootVfx = Instantiate(shootVfxLink, playerCamera.transform.position + new Vector3(0, -2, 0), playerCamera.transform.rotation);
        }
    }
}
