using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float jumpForce = 0f;
    [SerializeField] ContactFilter2D groundFilter;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    void OnJump()
    {
        Jump();
    }

    void Jump()
    {
        if (isGrounded)
        {
           rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }


}
