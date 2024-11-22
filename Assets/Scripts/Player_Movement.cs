using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Quaternion mainRotation = Quaternion.Euler(0, 0, 0);

    Camera playerCamera;

    float xRotation;
    float yRotation;

    public float sensetivityX;
    public float sensetivityY;

    public float speed = 1f;
    void Start()
    {
        playerCamera = Camera.current;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensetivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensetivityY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
