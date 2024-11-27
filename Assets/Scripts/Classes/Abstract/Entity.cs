using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] GameObject playerObject;

    [Header("Parameters")]
    [SerializeField] protected int maxHealth = 100;

    protected int currentHealth;
    void Awake()
    {
        this.currentHealth = maxHealth;

        SetUniqueStats();
    }

    abstract public void ApplyDamage(int damage);

    abstract protected void SetUniqueStats();
}
