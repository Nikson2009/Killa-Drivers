using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject floatingTextLink;

    [Header("Parameters")]
    [SerializeField] int maxHealth = 100;

    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;

        ShowFloatingText(transform.position, damage.ToString());

        if (currentHealth <= 0)
        {
            Destroy(transform.gameObject);
        }
    }

    private void ShowFloatingText(Vector3 position, string text)
    {
        GameObject newFloatingText = Instantiate(floatingTextLink, position, Quaternion.identity);
        FloatingTextManager floatingTextScript = newFloatingText.GetComponent<FloatingTextManager>();
        floatingTextScript.SetCamera(mainCamera);
        floatingTextScript.SetText(text);
    }
}
