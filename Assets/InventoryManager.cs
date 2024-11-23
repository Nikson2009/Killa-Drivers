using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject startWeaponLink;

    [SerializeField] Camera playerCamera;

    GameObject[] inventoryItems = new GameObject[1];

    void Start()
    {
        GameObject startWeapon = Instantiate(startWeaponLink, Vector3.zero, Quaternion.identity);
        inventoryItems[0] = startWeapon;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            WeaponItemClass currentWeaponScript = inventoryItems[0].GetComponent<WeaponItemClass>();
            currentWeaponScript.UseWeapon(playerCamera);

            //GameObject weaponResult = Instantiate(currentWeapon, playerCamera.transform.position + playerCamera.transform.forward * spawnDistance, Quaternion.identity);
            //weaponResult.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * spawnForce, ForceMode.Force);
        }
    }
}
