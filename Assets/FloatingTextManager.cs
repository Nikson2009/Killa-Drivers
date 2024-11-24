using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField] float destroyTime;

    [SerializeField] TextMesh thisTextMesh;
    void Start()
    {
        Destroy(transform.gameObject, destroyTime);
    }

    public void SetText(string text)
    {
        thisTextMesh.text = text;
    }
}
