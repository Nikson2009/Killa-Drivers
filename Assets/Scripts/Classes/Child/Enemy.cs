using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Links")]
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject floatingTextLink;
    [SerializeField] GameObject weaponLink;

    public override void ApplyDamage(int damage)
    {
        this.currentHealth -= damage;

        ShowFloatingText(transform.position, damage.ToString());

        if (this.currentHealth <= 0)
        {
            Destroy(transform.gameObject);
        }
    }

    protected override void SetUniqueStats() { }
    private void ShowFloatingText(Vector3 position, string text)
    {
        GameObject newFloatingText = Instantiate(floatingTextLink, position, Quaternion.identity);
        FloatingTextManager floatingTextScript = newFloatingText.GetComponent<FloatingTextManager>();
        floatingTextScript.SetCamera(mainCamera);
        floatingTextScript.SetText(text);
    }
}
