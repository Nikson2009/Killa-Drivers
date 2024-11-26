using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDestroyer : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] float time = 1f;
    public void Start()
    {
        StartCoroutine(TimerToDestroy());
    }

    IEnumerator TimerToDestroy()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
