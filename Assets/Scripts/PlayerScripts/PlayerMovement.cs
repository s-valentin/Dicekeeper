using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 movement;
    
    private void Update()
    {
        movementInput();     
    }

    private void FixedUpdate()
    {
        movementInput();
        rb.velocity = movement * moveSpeed;
    }

    void movementInput()
    {
        float movementx = Input.GetAxisRaw("Horizontal");
        float movementy = Input.GetAxisRaw("Vertical");

        movement = new Vector2(movementx, movementy).normalized;
    }
}
