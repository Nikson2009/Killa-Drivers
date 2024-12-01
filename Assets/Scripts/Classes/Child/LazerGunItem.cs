using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunItem : WeaponItemClass
{
    [Header("Sound Params")]
    [SerializeField] AudioSource AudioS;

    [Header("Links")]
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject floatingTextLink;
    [SerializeField] GameObject shootVfxLink;

    [Header("Parameters")]
    [SerializeField] float maxDistanceToHit = 500f;
    [SerializeField] int maxDamagedEnemies = 4;
    [SerializeField] int damage = 5;
    [SerializeField] int damageRandomness = 2;

    public override void UseWeapon(Transform viewTransform, GameObject selfObj)
    {

        Vector3 rayOrigin = viewTransform.position;
        Vector3 rayDirection = viewTransform.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistanceToHit))
        {
            GameObject shootVfx = Instantiate(shootVfxLink, viewTransform.position + new Vector3(0, -2, 0), Quaternion.identity);
            shootVfx.transform.LookAt(hit.point);

            GameObject newObjectChecker = Instantiate(objectCheckerLink, hit.collider.gameObject.transform.position, Quaternion.identity);
            CheckObjectsInRadiusWithVFX objectCheckerScript = newObjectChecker.GetComponent<CheckObjectsInRadiusWithVFX>();
            List<GameObject> enemiesToDamage = objectCheckerScript.getObjectsInRadius(maxDamagedEnemies, 0, hit.collider.gameObject);
            enemiesToDamage.Add(hit.collider.gameObject);

            foreach (GameObject enemy in enemiesToDamage)
            {
                if (enemy.tag == "Enemy" || enemy.tag == "Player")
                {
                    AudioS.Play();
                    int damageResult = damage + Random.Range(-damageRandomness, damageRandomness);

                    Entity entityScript = enemy.GetComponent<Entity>();

                    entityScript.ApplyDamage(damageResult);
                }
            }
        } else
        {
            Instantiate(shootVfxLink, viewTransform.position + new Vector3(0, -2, 0), viewTransform.rotation);
        }
    }
}
