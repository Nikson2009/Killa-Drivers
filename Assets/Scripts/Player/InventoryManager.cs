using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] GameObject[] inventoryBg;
    [SerializeField] GameObject[] inventoryIcons;

    bool isAttacked = false;

    int currentWeapon = 0;

    public bool TryAddWeapon(GameObject weapon, Sprite icon)
    {
        if (inventoryItems[0] == null)
        {
            inventoryItems[0] = weapon;
            inventoryIcons[0].GetComponent<Image>().sprite = icon;
            inventoryIcons[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            return true;
        }
        else if (inventoryItems[1] == null)
        {
            inventoryItems[1] = weapon;
            inventoryIcons[1].GetComponent<Image>().sprite = icon;
            inventoryIcons[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            return true;
        }
        else if (inventoryItems[2] == null)
        {
            inventoryItems[2] = weapon;
            inventoryIcons[2].GetComponent<Image>().sprite = icon;
            inventoryIcons[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

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

            int i = 0;
            foreach (GameObject bg in inventoryBg)
            {

                Image bgImage = bg.GetComponent<Image>();
                bgImage.color = new Color32(145, 145, 145, 220);
                if (i == currentWeapon)
                {
                    bgImage.color = new Color32(105, 105, 105, 220);
                }

                i += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentWeapon -= 1;
            currentWeapon = Mathf.Clamp(currentWeapon, 0, 2);

            int i = 0;
            foreach (GameObject bg in inventoryBg)
            {

                Image bgImage = bg.GetComponent<Image>();
                bgImage.color = new Color32(145, 145, 145, 220);
                if (i == currentWeapon)
                {
                    bgImage.color = new Color32(105, 105, 105, 220);
                }

                i += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (inventoryItems[currentWeapon] != null)
            {
                WeaponItemClass currentWeaponScript = inventoryItems[currentWeapon].GetComponent<WeaponItemClass>();

                GameObject newItemToGrab = Instantiate(currentWeaponScript.GetItemToGrab(), playerCamera.transform.position + playerCamera.transform.forward * 1.5f, Quaternion.identity);
                Rigidbody newItemToGrabRb = newItemToGrab.GetComponent<Rigidbody>();
                newItemToGrabRb.AddForce(playerCamera.transform.forward * 50f, ForceMode.Force);

                inventoryIcons[currentWeapon].GetComponent<Image>().sprite = null;
                inventoryIcons[currentWeapon].GetComponent<Image>().color = new Color32(0, 0, 0, 0);

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
