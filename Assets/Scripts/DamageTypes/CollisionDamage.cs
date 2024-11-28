using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject onCollisionVfx;

    [Header("Parameters")]
    [SerializeField] float timeToDestroy = 1f;
    [SerializeField] float force = 1000f;

    int thisDamage = 0;
    int thisDamageRandomness = 0;
    GameObject thisSelfObject;

    bool isCollided = false;

    private void Start()
    {
        Destroy(transform.gameObject, 10f);
    }
    public void SetParameters(int damage, int damageRandomness, GameObject selfObject)
    {
        thisDamage = damage;
        thisDamageRandomness = damageRandomness;
        thisSelfObject = selfObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isCollided && collision.gameObject != thisSelfObject)
        {
            isCollided = true;

            Instantiate(onCollisionVfx, collision.transform.position, Quaternion.identity);

            Rigidbody selfRb = thisSelfObject.GetComponent<Rigidbody>();
            selfRb.AddForce((transform.position - thisSelfObject.transform.position).normalized * force, ForceMode.Force);

            Rigidbody thisRb = GetComponent<Rigidbody>();
            Destroy(thisRb);

            BoxCollider thisBoxCollider = GetComponent<BoxCollider>();
            Destroy(thisBoxCollider);

            gameObject.transform.parent = collision.gameObject.transform;

            GameObject newObjectChecker = Instantiate(objectCheckerLink, collision.transform.position, Quaternion.identity);
            CheckObjectsInRadius objectCheckerScript = newObjectChecker.GetComponent<CheckObjectsInRadius>();
            List<GameObject> enemiesToDamage = objectCheckerScript.getObjectsInRadius(100, 0, collision.gameObject);
            enemiesToDamage.Add(collision.gameObject);

            foreach (GameObject enemy in enemiesToDamage)
            {
                if (enemy.tag == "Enemy" || enemy.tag == "Player" && enemy != thisSelfObject)
                {
                    int damageResult = thisDamage + Random.RandomRange(-thisDamageRandomness, thisDamageRandomness);

                    Entity entityScript = enemy.GetComponent<Entity>();

                    entityScript.ApplyDamage(damageResult);
                }
            }

            Destroy(transform.gameObject, timeToDestroy);
        }
    }
}
