using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] TextMesh textMeshLink;

    [Header("Parameters")]
    [SerializeField] float timeToDestroy = 1f;
    [SerializeField] Vector3 offset;

    Camera playerCamera;

    private void Start()
    {
        transform.localPosition += offset;
        Destroy(transform.gameObject, timeToDestroy);
    }

    private void Update()
    {
        if (playerCamera)
        {
            transform.LookAt(playerCamera.transform);
            transform.RotateAround(transform.position, transform.up, 180f);
        }
    }

    public void SetText(string text)
    {
        textMeshLink.text = text;
    }

    public void SetCamera(Camera camera)
    {
        playerCamera = camera;
    }
}
