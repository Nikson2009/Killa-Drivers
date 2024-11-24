using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunItem : WeaponItemClass
{
    [Header("Links")]
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject floatingTextLink;

    [Header("Parameters")]
    [SerializeField] float maxDistanceToHit = 500f;
    [SerializeField] int maxDamagedEnemies = 4;
    [SerializeField] int damage = 1;
    [SerializeField] int damageRandomness = 5;
    public override void UseWeapon(Camera playerCamera)
    {
        Vector3 rayOrigin = playerCamera.transform.position;
        Vector3 rayDirection = playerCamera.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistanceToHit))
        {
            GameObject newObjectChecker = Instantiate(objectCheckerLink, hit.collider.gameObject.transform.position, Quaternion.identity);
            CheckObjectsInRadiusWithVFX objectCheckerScript = newObjectChecker.GetComponent<CheckObjectsInRadiusWithVFX>();
            List<GameObject> enemiesToDamage = objectCheckerScript.getObjectsInRadius(maxDamagedEnemies, 0, hit.collider.gameObject);
            enemiesToDamage.Add(hit.collider.gameObject);

            foreach (GameObject enemy in enemiesToDamage)
            {
                if (enemy.tag == "Enemy")
                {
                    enemy.GetComponent<MeshRenderer>().material.color = Color.yellow;

                    int damageResult = damage + Random.RandomRange(-damageRandomness, damageRandomness);

                    SpawnFloatingText(enemy.transform.position, damageResult.ToString());
                }
            }
        }
    }

    private void SpawnFloatingText(Vector3 spawnPos, string text)
    {
        GameObject floatingText = Instantiate(floatingTextLink, spawnPos, Quaternion.identity);
        FloatingTextManager floatingTextScript = floatingText.GetComponent<FloatingTextManager>();
        floatingTextScript.SetText(text);
    }
}
