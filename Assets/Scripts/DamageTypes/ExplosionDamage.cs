using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public GameObject explosionVFX;
    public float timer;
    void Start()
    {
        StartCoroutine(Explosion());
    }


    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timer);

        Destroy(gameObject);

        Instantiate(explosionVFX, transform.position, Quaternion.identity);
    }
}
