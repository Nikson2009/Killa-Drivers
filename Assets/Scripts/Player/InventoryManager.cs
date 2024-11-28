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
        startWeapon.transform.parent = transform;
        inventoryItems[0] = startWeapon;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            WeaponItemClass currentWeaponScript = inventoryItems[0].GetComponent<WeaponItemClass>();
            currentWeaponScript.UseWeapon(playerCamera.transform, transform.gameObject);
        }
    }
}
