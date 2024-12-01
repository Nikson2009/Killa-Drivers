using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamageOnCollision : MonoBehaviour
{
    [Header("Sound Params")]
    [SerializeField] AudioSource AudioS;
    [Header("Links")]
    [SerializeField] GameObject explosionVFXLink;
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject floatingTextLink;

    [Header("Parameters")]
    [SerializeField] float force;
    [SerializeField] float timer;
    private int damage;
    private int damageRandomness;

    private void Start()
    {
        StartCoroutine(timerRealize(timer));
    }
    public void StartExplosion(int damagee, int damageRandomnesss)
    {
        damage = damagee;
        damageRandomness = damageRandomnesss;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            AudioS.Play();
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            Destroy(gameObject, 1);

            Instantiate(explosionVFXLink, transform.position, Quaternion.identity);

            GameObject newObjectChecker = Instantiate(objectCheckerLink, transform.position, Quaternion.identity);

            CheckObjectsInRadius objectCheckerScript = newObjectChecker.GetComponent<CheckObjectsInRadius>();

            List<GameObject> damagedEnemies = objectCheckerScript.getObjectsInRadius(100, 0, null);

            foreach (GameObject enemy in damagedEnemies)
            {
                if (enemy.tag == "Enemy" || enemy.tag == "Player")
                {
                    Entity entityScript = enemy.GetComponent<Entity>();
                    int damageResult = damage + Random.Range(-damageRandomness, damageRandomness);
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
    IEnumerator timerRealize(float timer)
    {
        yield return new WaitForSeconds(timer);
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
