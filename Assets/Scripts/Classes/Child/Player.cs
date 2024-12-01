using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Links")]
    [SerializeField] GameObject deadScreen;
    [SerializeField] CameraRotation CameraMovementScript;
    [SerializeField] PauseMenu PauseScript;

    [Header("Player Parameters")]
    [SerializeField] int maxOxygenLevel;
    [SerializeField] int maxStamina;

    protected int currentOxygenLevel;
    protected int currentStamina;

    bool isDead = false;

    protected override void SetUniqueStats()
    {
        currentOxygenLevel = maxOxygenLevel;
        currentStamina = maxStamina;
        this.currentHealth = maxHealth;

        StartCoroutine(EverySecondAction());
    }
    public override void ApplyDamage(int damage)
    {
        this.currentHealth -= damage;

        CheckIsDead();
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    private void CheckIsDead()
    {
        if (this.currentHealth <= 0)
        {
            isDead = true;
            deadScreen.SetActive(true);
            CameraMovementScript.enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1f;
            PauseScript.enabled = false;
        }
    }

    IEnumerator EverySecondAction()
    {
        yield return new WaitForSeconds(1f);

        if (!isDead)
        {
            if (currentOxygenLevel > 0)
            {
                this.currentOxygenLevel -= 1;
            } else
            {
                this.currentHealth -= 3;

                CheckIsDead();
            }

            StartCoroutine(EverySecondAction());
        }
    }

    // SetCurent... Events
    public void SetCurrentOxygenLevel(int value)
    {
        this.currentOxygenLevel = value;
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
