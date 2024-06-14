using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Camera")]
    public Transform orientation;
    

    [Header("Movement Speed")]

    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float speedLimit;
    private float currentSpeed;


   [Header("Jump Settings")]

    public LayerMask IsGround;

    public float jumpForce;
    public float jumpCooldown;

    private bool IsreadyToJump;
    private bool Isgrounded;

     private Rigidbody rb;

    private CharacterController characterController ;
    private float horizontalInput;
    private float verticalInput;


    

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
         rb = GetComponent<Rigidbody>();
         rb.freezeRotation = true;
        IsreadyToJump = true;
        Isgrounded = true;
    }

    private void Update()
    {
        Isgrounded = Physics.Raycast(transform.position, Vector3.down, 1f, IsGround);
        MyInput();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        currentSpeed = !Input.GetKey(KeyCode.LeftShift) ? walkSpeed : sprintSpeed;

        horizontalInput = Input.GetAxisRaw("Horizontal") * currentSpeed;
        verticalInput = Input.GetAxisRaw("Vertical") * currentSpeed;

        // when to jump
        if (Input.GetKey(KeyCode.Space) && IsreadyToJump && Isgrounded)
        {
            IsreadyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput);
        characterController.Move(moveDirection * Time.deltaTime);
        /*   if (rb.velocity.magnitude < speedLimit)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f  , ForceMode.Acceleration);
     /*/
    }

    private void Jump()
    {
        // reset y velocity
         rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

          rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        IsreadyToJump = true;
    }
}