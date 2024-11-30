using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Links")]
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject floatingTextLink;
    [SerializeField] GameObject weaponLink;
    [SerializeField] Transform playerTransform;

    [Header("Misc")]
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    [SerializeField] Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField]  float walkPointRange;

    [Header("Parameters")]
    [SerializeField] float attackCooldown;
    [SerializeField] float sightRange, attackRange;
    [SerializeField] bool playerIsInSightRange, playerIsInAttackRange;
    [SerializeField] float speed = 1f;
    [SerializeField] float timeToMiss = 0f;

    bool alreadyAttacked;
    WeaponItemClass weaponScript;
    Rigidbody rb;

    GameObject currentWeapon;

    public override void ApplyDamage(int damage)
    {
        this.currentHealth -= damage;

        ShowFloatingText(transform.position, damage.ToString());

        if (this.currentHealth <= 0)
        {
            Destroy(transform.gameObject);
        }
    }

    protected override void SetUniqueStats() {
        currentWeapon = Instantiate(weaponLink, Vector3.zero, Quaternion.identity);

        playerTransform = GameObject.Find("Player").transform;
        weaponScript = currentWeapon.GetComponent<WeaponItemClass>();
        rb = GetComponent<Rigidbody>();
    }
    private void ShowFloatingText(Vector3 position, string text)
    {
        GameObject newFloatingText = Instantiate(floatingTextLink, position, Quaternion.identity);
        FloatingTextManager floatingTextScript = newFloatingText.GetComponent<FloatingTextManager>();
        floatingTextScript.SetCamera(mainCamera);
        floatingTextScript.SetText(text);
    }

    private void Update()
    {
        playerIsInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerIsInSightRange && !playerIsInAttackRange) Patroling();
        else if (playerIsInSightRange && !playerIsInAttackRange) ChasePlayer();
        else if (playerIsInSightRange && playerIsInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) {
            rb.AddForce((walkPoint - transform.position).normalized * speed, ForceMode.Force);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ);

        walkPointSet = true;
    }

    private void ChasePlayer()
    {
        rb.AddForce((playerTransform.position - transform.position).normalized * speed, ForceMode.Force);
    }

    private void AttackPlayer()
    {
        transform.LookAt(playerTransform);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            StartCoroutine(Shoot(transform));
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    
    IEnumerator Shoot(Transform transformToShoot)
    {
        Transform currentTransform = new GameObject().transform;

        currentTransform.position = transformToShoot.position;
        currentTransform.rotation = transformToShoot.rotation;

        yield return new WaitForSeconds(timeToMiss);

        weaponScript.UseWeapon(transformToShoot, transform.gameObject);
    }
}
