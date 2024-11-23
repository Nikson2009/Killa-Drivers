using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunItem : WeaponItemClass
{
    [Header("Misc")]
    [SerializeField] GameObject objectCheckerLink;

    [Header("Parameters")]
    [SerializeField] float maxDistanceToHit = 500f;
    [SerializeField] int maxDamagedEnemies = 4;
    [SerializeField] float damage = 1f;
    public override void UseWeapon(Camera playerCamera)
    {
        Vector3 rayOrigin = playerCamera.transform.position;
        Vector3 rayDirection = playerCamera.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistanceToHit))
        {
            GameObject newObjectChecker = Instantiate(objectCheckerLink, hit.collider.gameObject.transform.position, Quaternion.identity);
            CheckObjectsInRadius objectCheckerScript = newObjectChecker.GetComponent<CheckObjectsInRadius>();
            List<GameObject> enemiesToDamage/* = objectCheckerScript.getObjectsInRadius(maxDamagedEnemies, 0, hit.collider.gameObject)*/ = new List<GameObject>();
            enemiesToDamage.Add(hit.collider.gameObject);

            foreach (GameObject enemy in enemiesToDamage)
            {
                if (enemy.tag == "Enemy")
                {
                    enemy.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
            }
        }
    }
}
