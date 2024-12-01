using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("SoundsValue")]
    [SerializeField] AudioSource AudioS;
    [Header("Other Values")]
    [SerializeField] GameObject startWeaponLink;

    [SerializeField] Camera playerCamera;

    List<GameObject> inventoryItems;

    [SerializeField] Player playerScript;
    [SerializeField] float attackCooldown;

    bool isAttacked = false;

    [SerializeField] GameObject tropheyWeaponSlot;
    [SerializeField] GameObject throwingWeaponSlot;

    int currentWeapon = 0;

    public bool TryAddWeapon(GameObject weapon)
    {
        bool isAdded;

        if (inventoryItems.Count < 3)
        {
            inventoryItems.Add(weapon);

            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        GameObject startWeapon = Instantiate(startWeaponLink, Vector3.zero, Quaternion.identity);
        startWeapon.transform.parent = transform;
        inventoryItems.Add(startWeapon);
        print(inventoryItems);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerScript.GetIsDead() != true && !isAttacked)
        {
            isAttacked = true;

            WeaponItemClass currentWeaponScript = inventoryItems[currentWeapon].GetComponent<WeaponItemClass>();
            AudioS.clip = currentWeaponScript.ShotSound;
            AudioS.Play();
            currentWeaponScript.UseWeapon(playerCamera.transform, transform.gameObject);

            Invoke(nameof(ResetCooldown), attackCooldown);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentWeapon += 1;
            currentWeapon = Mathf.Clamp(currentWeapon, 0, 2);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentWeapon -= 1;
            currentWeapon = Mathf.Clamp(currentWeapon, 0, 2);
        }

    }

    void ResetCooldown()
    {
        isAttacked = false;
    }
}
