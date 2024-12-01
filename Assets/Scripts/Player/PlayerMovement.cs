using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float minMoveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public Camera playerCamera;

    bool isRun = false;
    float currentAbstractStamina;

    [SerializeField] Player playerScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        currentAbstractStamina = playerScript.GetMaxParameters()[2];
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        if (playerScript.GetIsDead() != true)
        {
            MovePlayer();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && playerScript.GetCurrentStamina() > 0)
        {
            moveSpeed = maxMoveSpeed;
            isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.LeftShift) && playerScript.GetCurrentStamina() <= 0))
        {
            moveSpeed = minMoveSpeed;
            isRun = false;
        }

        if (isRun && rb.velocity.magnitude > 0f)
        {
            if (playerScript.GetCurrentStamina() > 0)
            {
                currentAbstractStamina -= 12f * Time.deltaTime;
                playerScript.SetCurrentStamina(Mathf.RoundToInt(currentAbstractStamina));
            }
        }
        else
        {
            if (playerScript.GetCurrentStamina() < playerScript.GetMaxParameters()[2]) {
                currentAbstractStamina += 12f * Time.deltaTime;
                playerScript.SetCurrentStamina(Mathf.RoundToInt(currentAbstractStamina));
            }
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.right * horizontalInput - playerCamera.transform.forward * -verticalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
