using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] shootPrefabs;
    public void Shoot()
    {
        for(int i = 0; i < shootPrefabs.Length; i++)
        {

        }
    }
}
