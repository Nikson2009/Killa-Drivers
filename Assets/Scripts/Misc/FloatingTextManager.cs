using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField] TextMesh textMeshLink;

    [SerializeField] float timeToDestroy = 1f;

    private void Start()
    {
        Destroy(transform.gameObject, timeToDestroy);
    }

    public void SetText(string text)
    {
        textMeshLink.text = text;
    }
}
