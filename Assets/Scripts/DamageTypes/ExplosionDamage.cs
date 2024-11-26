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
    [SerializeField] float force;

    public void StartExplosion(int damage, int damageRandomness)
    {
        StartCoroutine(Explosion(damage, damageRandomness));
    }

    IEnumerator Explosion(int damage, int damageRandomness)
    {
        yield return new WaitForSeconds(timer);

        Destroy(gameObject);

        Instantiate(explosionVFXLink, transform.position, Quaternion.identity);

        GameObject newObjectChecker = Instantiate(objectCheckerLink, transform.position, Quaternion.identity);

        CheckObjectsInRadius objectCheckerScript = newObjectChecker.GetComponent<CheckObjectsInRadius>();

        List<GameObject> damagedEnemies = objectCheckerScript.getObjectsInRadius(100, 0, null);

        foreach (GameObject enemy in damagedEnemies)
        {
            if (enemy.tag == "Enemy" || enemy.tag == "Player")
            {
                Entity entityScript = enemy.GetComponent<Entity>();
                int damageResult = damage + Random.RandomRange(-damageRandomness, damageRandomness);
                entityScript.ApplyDamage(damageResult);

                if (enemy.tag != "Player")
                {
                    Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                    enemyRigidbody.AddForce((enemy.transform.position - transform.position).normalized * force, ForceMode.Force);
                }
            }
        }
    }
}
