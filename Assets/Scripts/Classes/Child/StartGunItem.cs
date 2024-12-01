using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGunItem : WeaponItemClass
{
    [Header("Sound Params")]
    [SerializeField] AudioSource AudioS;
    [SerializeField] AudioClip Shot;
    [SerializeField] AudioClip Hit;

    [Header("Links")]
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject floatingTextLink;
    [SerializeField] GameObject shootVfxLink;

    [Header("Parameters")]
    [SerializeField] float maxDistanceToHit = 500f;
    [SerializeField] int damage = 5;
    [SerializeField] int damageRandomness = 2;

    public override void UseWeapon(Transform viewTransform, GameObject selfObj)
    {
        Vector3 rayOrigin = viewTransform.position;
        Vector3 rayDirection = viewTransform.forward;

        RaycastHit hit;
        AudioS.clip = Shot;
        AudioS.Play();
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistanceToHit) && (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Enemy"))
        {
            AudioS.clip = Hit;
            AudioS.Play();
            GameObject shootVfx = Instantiate(shootVfxLink, viewTransform.position + new Vector3(0, -2, 0), Quaternion.identity);
            shootVfx.transform.LookAt(hit.point);
            int damageResult = damage + Random.Range(-damageRandomness, damageRandomness);
            Entity entityScript = hit.collider.gameObject.GetComponent<Entity>();
            entityScript.ApplyDamage(damageResult);
        } else
        {
            Instantiate(shootVfxLink, viewTransform.position + new Vector3(0, -2, 0), viewTransform.rotation);
        }
    }
}
