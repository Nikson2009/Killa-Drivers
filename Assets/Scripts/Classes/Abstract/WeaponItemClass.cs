using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponItemClass : MonoBehaviour
{
    public AudioClip ShotSound;

    [SerializeField] GameObject itemToGrab;
   public abstract void UseWeapon(Transform viewTransform, GameObject selfObj);

   public GameObject GetItemToGrab()
    {
        return itemToGrab;
    }
}
