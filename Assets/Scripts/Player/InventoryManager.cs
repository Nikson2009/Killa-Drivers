using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject startWeaponLink;

    [SerializeField] Camera playerCamera;

    GameObject[] inventoryItems = new GameObject[2];

    [SerializeField] Player playerScript;
    [SerializeField] float attackCooldown;

    bool isAttacked = false;

    [SerializeField] GameObject tropheyWeaponSlot;
    [SerializeField] GameObject throwingWeaponSlot;

    void Start()
    {
        GameObject startWeapon = Instantiate(startWeaponLink, Vector3.zero, Quaternion.identity);
        startWeapon.transform.parent = transform;
        inventoryItems[0] = startWeapon;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerScript.GetIsDead() != true && !isAttacked)
        {
            isAttacked = true;

            WeaponItemClass currentWeaponScript = inventoryItems[0].GetComponent<WeaponItemClass>();
            currentWeaponScript.UseWeapon(playerCamera.transform, transform.gameObject);

            Invoke(nameof(ResetCooldown), attackCooldown);
        }
    }

    void ResetCooldown()
    {
        isAttacked = false;
    }
}
