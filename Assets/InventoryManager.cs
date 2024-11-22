using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject currentWeapon;

    float spawnDistance = 2.5f;
    float spawnForce = 5.25f;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            GameObject weaponResult = Instantiate(currentWeapon, transform.position + transform.forward * spawnDistance, Quaternion.identity);
            weaponResult.GetComponent<Rigidbody>().AddForce(transform.forward * spawnForce, ForceMode.Force);
        }
    }
}
