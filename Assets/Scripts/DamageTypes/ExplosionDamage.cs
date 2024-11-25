using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] GameObject explosionVFXLink;
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject floatingTextLink;

    [Header("Parameters")]
    [SerializeField] float timer;

    IEnumerator Explosion(int damage, int damageRandomness)
    {
        yield return new WaitForSeconds(timer);

        Destroy(gameObject);

        Instantiate(explosionVFXLink, transform.position, Quaternion.identity);
    }
}
