using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabItem : MonoBehaviour
{
    [SerializeField] GameObject weaponItemLink;
    [SerializeField] Sprite icon;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InventoryManager playerInventoryScript = collision.gameObject.GetComponent<InventoryManager>();

            GameObject newWeapon = Instantiate(weaponItemLink, Vector3.zero, Quaternion.identity);
            newWeapon.transform.parent = collision.gameObject.transform;

            if (playerInventoryScript.TryAddWeapon(newWeapon, icon))
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
