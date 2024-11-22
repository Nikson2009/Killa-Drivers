using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    [Header("Barrel outlets")]
    [SerializeField] GameObject[] shootPrefabs;

    [Header("Maximum shoot distance")]
    [SerializeField] int MaxDistance;

    [Header("Sound Settings")]
    [SerializeField] AudioSource AS;

    [Header("Delay above shoots")]
    [SerializeField] float Delay;
    public void Shoot()
    {
        for(int i = 0; i < shootPrefabs.Length; i++)
        {
            GameObject curent = shootPrefabs[i];
            Ray ray = new Ray(curent.transform.position, curent.transform.forward);
            AS.Stop();
            AS.Play();
            if(Physics.Raycast(ray,out RaycastHit hit,MaxDistance))
            {
                print(hit.collider.gameObject.name);
            }
        }
    }
    private void Start()
    {
        StartCoroutine(Cor());
    }
    IEnumerator Cor()
    {
        Shoot();
        yield return new WaitForSeconds(Delay);
        StartCoroutine(Cor());
    }
}
