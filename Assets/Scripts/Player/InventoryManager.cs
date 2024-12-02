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

    GameObject[] inventoryItems = new GameObject[3];

    [SerializeField] Player playerScript;
    [SerializeField] float attackCooldown;

    bool isAttacked = false;

    int currentWeapon = 0;

    public bool TryAddWeapon(GameObject weapon)
    {
        if (inventoryItems[1] == null)
        {
            inventoryItems[1] = weapon;

            return true;
        }
        else if (inventoryItems[2] == null)
        {
            inventoryItems[2] = weapon;

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
        inventoryItems[0] = startWeapon;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerScript.GetIsDead() != true && !isAttacked)
        {
            if (inventoryItems[currentWeapon] != null)
            {
                isAttacked = true;

                WeaponItemClass currentWeaponScript = inventoryItems[currentWeapon].GetComponent<WeaponItemClass>();
                print(inventoryItems[currentWeapon]);
                AudioS.clip = currentWeaponScript.ShotSound;
                AudioS.Play();
                currentWeaponScript.UseWeapon(playerCamera.transform, transform.gameObject);

                Invoke(nameof(ResetCooldown), attackCooldown);
            }
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (inventoryItems[currentWeapon] != null)
            {
                WeaponItemClass currentWeaponScript = inventoryItems[currentWeapon].GetComponent<WeaponItemClass>();

                GameObject newItemToGrab = Instantiate(currentWeaponScript.GetItemToGrab(), playerCamera.transform.position + playerCamera.transform.forward * 1.5f, Quaternion.identity);
                Rigidbody newItemToGrabRb = newItemToGrab.GetComponent<Rigidbody>();
                newItemToGrabRb.AddForce(playerCamera.transform.forward * 50f, ForceMode.Force);

                Destroy(inventoryItems[currentWeapon]);
                inventoryItems[currentWeapon] = null;
            }
        }

    }

    void ResetCooldown()
    {
        isAttacked = false;
    }
}
