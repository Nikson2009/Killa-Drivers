using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(transform.gameObject);
    }
}
