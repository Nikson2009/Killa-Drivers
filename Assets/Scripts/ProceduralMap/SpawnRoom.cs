using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(transform.gameObject);
        }
    }
}
