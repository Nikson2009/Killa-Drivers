using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [Header("Links")]
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject floatingTextLink;
    [SerializeField] GameObject weaponLink;
    [SerializeField] Transform playerTransform;
    [SerializeField] NavMeshAgent agent;

    [Header("Misc")]
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    [Header("Parameters")]
    [SerializeField] float attackCooldown;
    [SerializeField] float sightRange, attackRange;
    [SerializeField] bool playerIsInSightRange, playerIsInAttackRange;

    bool alreadyAttacked;
    WeaponItemClass weaponScript;

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
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
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

    }

    private void ChasePlayer()
    {

    }

    private void AttackPlayer()
    {
        print("Hui");

        transform.LookAt(playerTransform);

        weaponScript.UseWeapon(transform);
    }
}
