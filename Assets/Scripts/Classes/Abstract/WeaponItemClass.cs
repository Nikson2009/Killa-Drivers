using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponItemClass : MonoBehaviour
{
    public AudioClip ShotSound;
   public abstract void UseWeapon(Transform viewTransform, GameObject selfObj);
}
