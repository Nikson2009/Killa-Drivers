using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubblesSpawner : MonoBehaviour
{
    [SerializeField] GameObject oxygenBubbleLink;

    [SerializeField] float cooldownToSpawn = 1f;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(cooldownToSpawn);

        Instantiate(oxygenBubbleLink, transform.position, Quaternion.identity);

        StartCoroutine(Spawner());
    }
}
