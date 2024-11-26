using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] protected int maxHealth = 100;

    protected int currentHealth;
    void Start()
    {
        this.currentHealth = maxHealth;

        SetUniqueStats();
    }

    abstract public void ApplyDamage(int damage);

    abstract protected void SetUniqueStats();
}
