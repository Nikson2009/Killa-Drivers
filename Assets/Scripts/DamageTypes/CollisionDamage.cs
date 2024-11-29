using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] GameObject objectCheckerLink;
    [SerializeField] GameObject onCollisionVfx;
    [SerializeField] LineRenderer linerendererLink;

    [Header("Parameters")]
    [SerializeField] float timeToDestroy = 1f;
    [SerializeField] float force = 1000f;

    int thisDamage = 0;
    int thisDamageRandomness = 0;
    GameObject thisSelfObject;

    Rigidbody selfRb;

    bool isCollided = false;

    private void Start()
    {
        selfRb = thisSelfObject.GetComponent<Rigidbody>();
        StartCoroutine(DestroySelf());
    }

    private void Update()
    {
        if (thisSelfObject != null)
        {
            linerendererLink.SetPosition(0, transform.position);
            linerendererLink.SetPosition(1, thisSelfObject.transform.position);
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isCollided)
        {
            selfRb.AddForce((transform.position - thisSelfObject.transform.position).normalized * force, ForceMode.Force);

            if ((thisSelfObject.transform.position - transform.position).magnitude <= 4f)
            {
                Destroy(transform.gameObject);
            }
        }
        else
        {
            if ((thisSelfObject.transform.position - transform.position).magnitude >= 50f)
            {
                Destroy(transform.gameObject);
            }
        }
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
            if (collision.gameObject.tag == "Player")
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }

            isCollided = true;

            Instantiate(onCollisionVfx, collision.transform.position, Quaternion.identity);

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
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(4f);

        if (!isCollided)
        {
            Destroy(transform.gameObject);
        }
    }
}
