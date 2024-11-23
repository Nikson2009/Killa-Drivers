using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject currentWeapon;

    [SerializeField] Camera playerCamera;

    float spawnDistance = 1.5f;
    float spawnForce = 725f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject weaponResult = Instantiate(currentWeapon, transform.position + transform.forward * spawnDistance, Quaternion.identity);
            weaponResult.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * spawnForce, ForceMode.Force);
        }
    }
}
