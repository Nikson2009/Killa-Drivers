using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Player Parameters")]
    [SerializeField] int maxOxygenLevel;
    [SerializeField] int maxStamina;

    protected int currentOxygenLevel;
    protected int currentStamina;

    protected override void SetUniqueStats()
    {
        currentOxygenLevel = maxOxygenLevel;
        currentStamina = maxStamina;
        this.currentHealth = maxHealth;
    }
    public override void ApplyDamage(int damage)
    {
        this.currentHealth -= damage;

        if (this.currentHealth <= 0)
        {
            Destroy(transform.gameObject);
        }
    }

    // GetCurent... Events
    public int GetCurrentHealth(){return this.currentHealth;}
    public int GetCurrentStamina() { return this.currentStamina; }
    public int GetCurrentOxygenLevel() { return this.currentOxygenLevel; }
    // GetMax... Events
    public List<int> GetMaxParameters()
    {
        return new List<int> { this.maxHealth, maxOxygenLevel, maxStamina };
    }
}
